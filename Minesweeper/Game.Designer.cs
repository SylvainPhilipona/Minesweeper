
namespace Minesweeper
{
    partial class Game
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRestart = new System.Windows.Forms.Button();
            this.panContainer = new System.Windows.Forms.Panel();
            this.btnStartGenerations = new System.Windows.Forms.Button();
            this.pbGenerations = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(10, 536);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(175, 52);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.Init);
            // 
            // panContainer
            // 
            this.panContainer.Location = new System.Drawing.Point(10, 10);
            this.panContainer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panContainer.Name = "panContainer";
            this.panContainer.Size = new System.Drawing.Size(525, 520);
            this.panContainer.TabIndex = 0;
            // 
            // btnStartGenerations
            // 
            this.btnStartGenerations.Location = new System.Drawing.Point(190, 536);
            this.btnStartGenerations.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStartGenerations.Name = "btnStartGenerations";
            this.btnStartGenerations.Size = new System.Drawing.Size(175, 52);
            this.btnStartGenerations.TabIndex = 2;
            this.btnStartGenerations.Text = "Start Generations";
            this.btnStartGenerations.UseVisualStyleBackColor = true;
            this.btnStartGenerations.Click += new System.EventHandler(this.btnStartGenerations_Click);
            // 
            // pbGenerations
            // 
            this.pbGenerations.Location = new System.Drawing.Point(369, 536);
            this.pbGenerations.Margin = new System.Windows.Forms.Padding(2);
            this.pbGenerations.Name = "pbGenerations";
            this.pbGenerations.Size = new System.Drawing.Size(166, 51);
            this.pbGenerations.TabIndex = 3;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 601);
            this.Controls.Add(this.pbGenerations);
            this.Controls.Add(this.btnStartGenerations);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.panContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Game";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Panel panContainer;
        private System.Windows.Forms.Button btnStartGenerations;
        private System.Windows.Forms.ProgressBar pbGenerations;
    }
}

