
namespace Démineur
{
    partial class Démineur
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRestart = new System.Windows.Forms.Button();
            this.panContainer = new System.Windows.Forms.Panel();
            this.btnStartGenerations = new System.Windows.Forms.Button();
            this.pbGenerations = new System.Windows.Forms.ProgressBar();
            this.bwkGenerations = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(14, 825);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(233, 80);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // panContainer
            // 
            this.panContainer.Location = new System.Drawing.Point(14, 16);
            this.panContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panContainer.Name = "panContainer";
            this.panContainer.Size = new System.Drawing.Size(700, 800);
            this.panContainer.TabIndex = 0;
            // 
            // btnStartGenerations
            // 
            this.btnStartGenerations.Location = new System.Drawing.Point(253, 824);
            this.btnStartGenerations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStartGenerations.Name = "btnStartGenerations";
            this.btnStartGenerations.Size = new System.Drawing.Size(233, 80);
            this.btnStartGenerations.TabIndex = 2;
            this.btnStartGenerations.Text = "Start Generations";
            this.btnStartGenerations.UseVisualStyleBackColor = true;
            this.btnStartGenerations.Click += new System.EventHandler(this.btnStartGenerations_Click);
            // 
            // pbGenerations
            // 
            this.pbGenerations.Location = new System.Drawing.Point(492, 825);
            this.pbGenerations.Name = "pbGenerations";
            this.pbGenerations.Size = new System.Drawing.Size(222, 79);
            this.pbGenerations.TabIndex = 3;
            // 
            // Démineur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 924);
            this.Controls.Add(this.pbGenerations);
            this.Controls.Add(this.btnStartGenerations);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.panContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Démineur";
            this.Text = "Démineur";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Panel panContainer;
        private System.Windows.Forms.Button btnStartGenerations;
        private System.Windows.Forms.ProgressBar pbGenerations;
        private System.ComponentModel.BackgroundWorker bwkGenerations;
    }
}

