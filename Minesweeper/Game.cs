﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Game : Form
    {
        private const int GRID_WIDTH = 25;
        private const int GRID_HEIGHT = 25;
        private const byte PERCENTAGE_OF_MINES = 15;
        private const string MINED_CELL_TAG = "mined";
        private const string SAFE_CELL_TAG = "safe";
        private const string DEMINED_CELL_TAG = "demined";
        private readonly Color MINED_CELL_COLOR = Color.Yellow;
        private readonly Color SAFE_CELL_COLOR = Color.Gray;
        private readonly Color DEMINED_CELL_COLOR = Color.LightGray;
        private const string FLAG_CELL_TEXT = "🚩";

        private int buttonWidth = 0;
        private int buttonHeight = 0;
        private int fontSize = 0;
        private int nbMines = 0;

        private Button[,] grid;


        public Game()
        {
            InitializeComponent();
            Init(null, null);
        }

        private void Init(object sender, EventArgs e)
        {
            // Set the buttons width, height and style
            buttonWidth = panContainer.Width / GRID_WIDTH;
            buttonHeight = panContainer.Height / GRID_HEIGHT;
            fontSize = (buttonWidth + buttonHeight) / 6;

            // Reset and generate the grid
            panContainer.Controls.Clear();
            grid = new Button[GRID_HEIGHT, GRID_WIDTH];

            // Go trought all the grid
            for (int y = 0; y < GRID_HEIGHT; y++)
            {
                for (int x = 0; x < GRID_WIDTH; x++)
                {
                    // Create and define the button
                    Button btn = new Button();
                    btn.Width = buttonWidth;
                    btn.Height = buttonHeight;
                    btn.Location = new Point(x * buttonWidth, y * buttonHeight);
                    btn.TabStop = false;
                    btn.Tag = SAFE_CELL_TAG;

                    // Set the style of the button
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = SAFE_CELL_COLOR;
                    btn.FlatAppearance.BorderColor = SAFE_CELL_COLOR;
                    btn.Font = new Font("Segoe", fontSize, FontStyle.Bold);
                    btn.TextAlign = ContentAlignment.MiddleCenter;

                    // Handle the click event
                    btn.MouseDown += new MouseEventHandler(Cell_Click);

                    // Add the button to the pannel and in the grid array
                    panContainer.Controls.Add(btn);
                    grid[y, x] = btn;
                }
            }

            // Generate the mines
            GenerateMines();
        }

        private void GenerateMines()
        {
            // Init the objects
            Random rnd = new Random();
            List<int> cellsMined = new List<int>();

            // Calculate the number of mines to generate (Rule of three)
            nbMines = PERCENTAGE_OF_MINES * (GRID_WIDTH * GRID_HEIGHT) / 100;

            // Repeat while the number of mines isn't reach
            while(cellsMined.Count < nbMines)
            {
                // Generate a random index of the grid
                int index = rnd.Next(0, GRID_WIDTH * GRID_HEIGHT);

                // Check if the index has already be generated
                if (!cellsMined.Contains(index))
                {
                    // Add to the list the generated index
                    cellsMined.Add(index);
                }
            }

            // Go trough all the cells to mine
            foreach(int index in cellsMined)
            {
                // Mine the cell
                Button cell = (Button)panContainer.Controls[index];
                cell.BackColor = MINED_CELL_COLOR;
                cell.FlatAppearance.BorderColor = MINED_CELL_COLOR;
                cell.Tag = MINED_CELL_TAG;
            }
        }



        private void Cell_Click(object sender, MouseEventArgs e)
        {
            // Cast the clicked cell as a button
            Button cell = (Button)sender;


            MessageBox.Show(cell.Tag.ToString());
        }

        private void btnStartGenerations_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10_000; i++)
            {
                GenerateMines();
            }
        }
    }
}
