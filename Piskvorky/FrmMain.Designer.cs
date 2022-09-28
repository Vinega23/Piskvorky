namespace Piskvorky
{
    partial class FrmMain
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
            this.playBoard1 = new Piskvorky.PlayBoard();
            this.SuspendLayout();
            // 
            // playBoard1
            // 
            this.playBoard1.BoardSize = 19;
            this.playBoard1.ColorGrid = System.Drawing.SystemColors.GrayText;
            this.playBoard1.FieldSize = 20;
            this.playBoard1.Location = new System.Drawing.Point(77, 12);
            this.playBoard1.Name = "playBoard1";
            this.playBoard1.Size = new System.Drawing.Size(405, 397);
            this.playBoard1.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 451);
            this.Controls.Add(this.playBoard1);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private PlayBoard playBoard1;
    }
}

