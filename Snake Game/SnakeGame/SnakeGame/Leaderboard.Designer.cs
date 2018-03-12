namespace SnakeGame
{
    partial class Leaderboard
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
            this.top100List = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // top100List
            // 
            this.top100List.FormattingEnabled = true;
            this.top100List.ItemHeight = 20;
            this.top100List.Location = new System.Drawing.Point(35, 120);
            this.top100List.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.top100List.Name = "top100List";
            this.top100List.Size = new System.Drawing.Size(481, 524);
            this.top100List.TabIndex = 0;
            this.top100List.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Leaderboard Top 100";
            // 
            // Leaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 675);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.top100List);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Leaderboard";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox top100List;
        private System.Windows.Forms.Label label1;
    }
}