namespace GameLogger
{
    partial class GameView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameViewName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameViewName
            // 
            this.GameViewName.AutoSize = true;
            this.GameViewName.Location = new System.Drawing.Point(269, 49);
            this.GameViewName.Name = "GameViewName";
            this.GameViewName.Size = new System.Drawing.Size(35, 13);
            this.GameViewName.TabIndex = 0;
            this.GameViewName.Text = "label1";
            this.GameViewName.Click += new System.EventHandler(this.label1_Click);
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 628);
            this.Controls.Add(this.GameViewName);
            this.Name = "GameView";
            this.Text = "GameView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GameViewName;
    }
}