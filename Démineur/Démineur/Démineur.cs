using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Démineur
{
    public partial class Démineur : Form
    {
        //Constants
        private const int GRID_WIDTH = 25;
        private const int GRID_HEIGHT = 25;
        private const int PERCENTAGE_OF_MINES = 15;
        private const string MINED_CELL_TAG = "mined";
        private const string SAFE_CELL_TAG = "safe";
        private const string DEMINED_CELL_TAG = "demined";
        private readonly Color MINED_CELL_COLOR = Color.Yellow;
        private readonly Color SAFE_CELL_COLOR = Color.Gray;
        private readonly Color DEMINED_CELL_COLOR = Color.LightGray;
        private const string FLAG_CELL_TEXT = "🚩";

        //Variables
        private int buttonWidth = 0;
        private int buttonHeight = 0;
        private int fontSize = 0;
        private int nbMines = 0;

        private Button[,] grid;


        public Démineur()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            //Set the buttons width
            buttonWidth = panContainer.Width / GRID_WIDTH;

            //Set the buttons height
            buttonHeight = panContainer.Height / GRID_HEIGHT;

            //Set the font size
            fontSize = (buttonWidth + buttonHeight) / 6;

            //Reset the grid
            panContainer.Controls.Clear();

            //Generate the grid
            grid = new Button[GRID_HEIGHT, GRID_WIDTH];

            for (int y = 0; y < GRID_HEIGHT; y++)
            {
                for (int x = 0; x < GRID_WIDTH; x++)
                {
                    //Create the button
                    Button btn = new Button();

                    //Set the size of the button
                    btn.Width = buttonWidth;
                    btn.Height = buttonHeight;

                    //Set the location of the button
                    btn.Location = new Point(x * buttonWidth, y * buttonHeight);

                    //Set the style of the button
                    btn.BackColor = SAFE_CELL_COLOR;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = SAFE_CELL_COLOR;
                    btn.Font = new Font("Segoe", fontSize, FontStyle.Bold);
                    btn.TextAlign = ContentAlignment.MiddleCenter;

                    //Handle the event
                    btn.MouseDown += new MouseEventHandler(Button_Click);

                    //Set the index
                    btn.TabStop = false;

                    //Add the button to the pannel
                    panContainer.Controls.Add(btn);

                    //Add the control in the array
                    grid[y, x] = btn;
                }
            }

            //Generate the mines
            GenerateMines(false);
        }

        private void Reset()
        {
            panContainer.Invoke(new MethodInvoker(delegate
            {
                foreach (Button btn in panContainer.Controls)
                {
                    btn.Tag = SAFE_CELL_TAG;
                    btn.BackColor = SAFE_CELL_COLOR;
                    btn.FlatAppearance.BorderColor = SAFE_CELL_COLOR;
                    btn.Text = "";
                }
            }));
        }

        private void GenerateMines(bool hide)
        {
            Random rnd = new Random();
            List<int> casesToMine = new List<int>();
            nbMines = PERCENTAGE_OF_MINES * (GRID_WIDTH * GRID_HEIGHT) / 100;


            //Generate the cases to mine
            for (int i = 0; i < nbMines; i++)
            {
                int idToMine;

                do
                {
                    idToMine = rnd.Next(0, GRID_WIDTH * GRID_HEIGHT);
                } while (casesToMine.Contains(idToMine));

                casesToMine.Add(idToMine);
            }

            
            for (int i = 0; i < panContainer.Controls.Count; i++)
            {
                //If the case is mined
                if (casesToMine.Contains(i))
                {
                    Button btn = panContainer.Controls[i] as Button;
                    btn.Tag = MINED_CELL_TAG;
                    
                    if (!hide)
                    {
                        btn.BackColor = MINED_CELL_COLOR;
                        btn.FlatAppearance.BorderColor = MINED_CELL_COLOR;
                    }
                }
                else
                {
                    Button btn = panContainer.Controls[i] as Button;
                    btn.Tag = SAFE_CELL_TAG;
                    
                    if (!hide)
                    {
                        btn.BackColor = SAFE_CELL_COLOR;
                        btn.FlatAppearance.BorderColor = SAFE_CELL_COLOR;
                    }
                }
            }
        }




        private void Button_Click(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;

            //Left click
            if (e.Button == MouseButtons.Left)
            {
                //If the user is on a mine
                if ((string)btn.Tag == MINED_CELL_TAG)
                {
                    MessageBox.Show("Perdu!");
                }
                else if ((string)btn.Tag == SAFE_CELL_TAG)
                {
                    Demine(btn);
                }


            }
            //Right click
            else if (e.Button == MouseButtons.Right && (string)btn.Tag != DEMINED_CELL_TAG)
            {
                if (btn.Text == FLAG_CELL_TEXT)
                {
                    btn.Text = "";
                }
                else
                {
                    btn.Text = FLAG_CELL_TEXT;
                }
            }

            panContainer.Focus();
        }

        private void Demine(Button btnSender)
        {
            List<Button> listToDemine = new List<Button>();
            List<Button> listCorners = new List<Button>();
            List<Button> lastListToDemine = new List<Button>();

            if((string)btnSender.Tag != MINED_CELL_TAG)
            {
                if(GetMinesAround(btnSender) == 0)
                {
                    listToDemine.Add(btnSender);
                }
                else
                {
                    listCorners.Add(btnSender);
                }
            }

            do
            {
                lastListToDemine = listToDemine.ToList();
                //DemineAround(ref listToDemine, ref listCorners);

                //Coords to check (X, Y)
                int[,] possibleCoords = new int[,] { 
                    { -1, -1 }, { 0, -1 }, { 1, -1 }, // Top
                    { -1, 0 },              { 1, 0 }, // Middle
                    { -1, 1 }, { 0, 1 }, { 1, 1 } };

                //Demine all element in the list
                foreach (Button btn in listToDemine.ToList())
                {
                    //X and Y index of the case in the grid
                    (int X, int Y) index = GetIndex(btn);
                    int x = index.X;
                    int y = index.Y;

                    //Browse the coords array
                    for (int i = 0; i < possibleCoords.GetLength(0); i++)
                    {
                        //If the coords aren't outside of the bounds of the array
                        if (y + possibleCoords[i, 1] >= 0 && y + possibleCoords[i, 1] < GRID_HEIGHT && x + possibleCoords[i, 0] >= 0 && x + possibleCoords[i, 0] < GRID_WIDTH)
                        {
                            //If the case at the coords ins't already in the list to demine
                            if (!listToDemine.Contains(grid[y + possibleCoords[i, 1], x + possibleCoords[i, 0]]))
                            {
                                //If there is not mines around the case
                                if (GetMinesAround(grid[y + possibleCoords[i, 1], x + possibleCoords[i, 0]]) == 0)
                                {
                                    listToDemine.Add(grid[y + possibleCoords[i, 1], x + possibleCoords[i, 0]]);
                                }
                                else
                                {
                                    listCorners.Add(grid[y + possibleCoords[i, 1], x + possibleCoords[i, 0]]);
                                }
                            }
                        }
                    }
                }

            } while (listToDemine.Count != lastListToDemine.Count);


            foreach(Button button in listToDemine)
            {
                button.BackColor = DEMINED_CELL_COLOR;
                button.FlatAppearance.BorderColor = DEMINED_CELL_COLOR;
                button.Text = "";
                button.Tag = DEMINED_CELL_TAG;
            }

            foreach(Button button in listCorners)
            {
                button.BackColor = DEMINED_CELL_COLOR;
                button.FlatAppearance.BorderColor = DEMINED_CELL_COLOR;
                button.Text = GetMinesAround(button).ToString();
                button.Tag = DEMINED_CELL_TAG;
            }
        }


        private int GetMinesAround(Button btn)
        {
            //X and Y index of the case in the list
            (int X, int Y) index = GetIndex(btn);
            int x = index.X;
            int y = index.Y;

            int nbMines = 0;

            //Coords to check
            int[,] possibleCoords = new int[,] { { -1, -1 }, { 0, -1 }, { 1, -1 }, { -1, 0 }, { 1, 0 }, { -1, 1 }, { 0, 1 }, { 1, 1 } };

            //Browse the coords array
            for (int i = 0; i < possibleCoords.GetLength(0); i++)
            {
                //If the coords aren't outside of the bounds of the array
                if (y + possibleCoords[i, 1] >= 0 && y + possibleCoords[i, 1] < GRID_HEIGHT && x + possibleCoords[i, 0] >= 0 && x + possibleCoords[i, 0] < GRID_WIDTH)
                {
                    if((string)grid[y + possibleCoords[i, 1], x + possibleCoords[i, 0]].Tag == MINED_CELL_TAG)
                    {
                        nbMines++;
                    }
                }
            }

            return nbMines;
        }

        private (int X, int Y) GetIndex(Button btn)
        {
            for (int y = 0; y < GRID_HEIGHT; y++)
            {
                for (int x = 0; x < GRID_WIDTH; x++)
                {
                    if (grid[y, x] == btn)
                    {
                        return (x, y);
                    }
                }
            }

            return (-1, -1);
        }


        private void btnStartGenerations_Click(object sender, EventArgs e)
        {
            int nbGenerations = 100_000;
            float minMines = Int32.MaxValue;
            float maxMines = 0;

            Stopwatch stopwatch = new Stopwatch();

            pbGenerations.Minimum = 0;
            pbGenerations.Maximum = nbGenerations;
            pbGenerations.Value = 0;
            pbGenerations.Step = 1;

            new Thread(() =>
            {
                panContainer.Invoke(new MethodInvoker(delegate
                {
                    panContainer.Enabled = false;
                }));
                stopwatch.Start();

                Reset();

                //pbGenerations.Invoke(new MethodInvoker(delegate
                //{
                    for (int i = 0; i < nbGenerations - 1; i++)
                    {
                        GenerateMines(true);

                        if (nbMines < minMines)
                        {
                            minMines = nbMines;
                        }

                        if (nbMines > maxMines)
                        {
                            maxMines = nbMines;
                        }

                        pbGenerations.Invoke(new MethodInvoker(delegate
                        {
                            pbGenerations.PerformStep();
                        }));
                    }
                //}));

                GenerateMines(false);

                if (nbMines < minMines)
                {
                    minMines = nbMines;
                }

                if (nbMines > maxMines)
                {
                    maxMines = nbMines;
                }

                stopwatch.Stop();
                panContainer.Invoke(new MethodInvoker(delegate
                {
                    panContainer.Enabled = true;
                }));

                MessageBox.Show(
                $"Nombre de générations : {nbGenerations}\n" +
                $"Temps pour les générations : {Math.Round(stopwatch.Elapsed.TotalSeconds, 3)} secondes\n" +
                $"Nombre min de mines : {minMines}({minMines * 100 / (GRID_HEIGHT * GRID_WIDTH)}%)\n" +
                $"Nombre max de mines : {maxMines}({maxMines * 100 / (GRID_HEIGHT * GRID_WIDTH)}%)\n" +
                $"Générations terminées");


            }).Start();

            
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Reset();
            GenerateMines(false);
        }
    }
}
