using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.numRange = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbMin = new System.Windows.Forms.TrackBar();
            this.rtbMin = new System.Windows.Forms.RichTextBox();
            this.tbMax = new System.Windows.Forms.TrackBar();
            this.rtbMax = new System.Windows.Forms.RichTextBox();
            this.tbGuess = new System.Windows.Forms.TrackBar();
            this.rtbGuess = new System.Windows.Forms.RichTextBox();
            this.btnGuess = new System.Windows.Forms.Button();
            this.btnMessage = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGuess)).BeginInit();
            this.SuspendLayout();
            // 
            // numRange
            // 
            this.numRange.Location = new System.Drawing.Point(27, 25);
            this.numRange.Margin = new System.Windows.Forms.Padding(4);
            this.numRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRange.Name = "numRange";
            this.numRange.Size = new System.Drawing.Size(79, 22);
            this.numRange.TabIndex = 0;
            this.numRange.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(160, 18);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(107, 37);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            // 
            // tbMin
            // 
            this.tbMin.Location = new System.Drawing.Point(27, 86);
            this.tbMin.Margin = new System.Windows.Forms.Padding(4);
            this.tbMin.Maximum = 99;
            this.tbMin.Minimum = 1;
            this.tbMin.Name = "tbMin";
            this.tbMin.Size = new System.Drawing.Size(400, 56);
            this.tbMin.TabIndex = 2;
            this.tbMin.Value = 1;
            // 
            // rtbMin
            // 
            this.rtbMin.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.rtbMin.Location = new System.Drawing.Point(453, 86);
            this.rtbMin.Margin = new System.Windows.Forms.Padding(4);
            this.rtbMin.Multiline = false;
            this.rtbMin.Name = "rtbMin";
            this.rtbMin.ReadOnly = true;
            this.rtbMin.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbMin.Size = new System.Drawing.Size(80, 50);
            this.rtbMin.TabIndex = 3;
            this.rtbMin.Text = "";
            // 
            // tbMax
            // 
            this.tbMax.Location = new System.Drawing.Point(27, 172);
            this.tbMax.Margin = new System.Windows.Forms.Padding(4);
            this.tbMax.Maximum = 100;
            this.tbMax.Minimum = 2;
            this.tbMax.Name = "tbMax";
            this.tbMax.Size = new System.Drawing.Size(400, 56);
            this.tbMax.TabIndex = 4;
            this.tbMax.Value = 2;
            // 
            // rtbMax
            // 
            this.rtbMax.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.rtbMax.Location = new System.Drawing.Point(453, 172);
            this.rtbMax.Margin = new System.Windows.Forms.Padding(4);
            this.rtbMax.Multiline = false;
            this.rtbMax.Name = "rtbMax";
            this.rtbMax.ReadOnly = true;
            this.rtbMax.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbMax.Size = new System.Drawing.Size(80, 50);
            this.rtbMax.TabIndex = 5;
            this.rtbMax.Text = "";
            // 
            // tbGuess
            // 
            this.tbGuess.Enabled = false;
            this.tbGuess.Location = new System.Drawing.Point(27, 258);
            this.tbGuess.Margin = new System.Windows.Forms.Padding(4);
            this.tbGuess.Maximum = 100;
            this.tbGuess.Minimum = 1;
            this.tbGuess.Name = "tbGuess";
            this.tbGuess.Size = new System.Drawing.Size(400, 56);
            this.tbGuess.TabIndex = 6;
            this.tbGuess.Value = 1;
            // 
            // rtbGuess
            // 
            this.rtbGuess.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.rtbGuess.Location = new System.Drawing.Point(453, 258);
            this.rtbGuess.Margin = new System.Windows.Forms.Padding(4);
            this.rtbGuess.Multiline = false;
            this.rtbGuess.Name = "rtbGuess";
            this.rtbGuess.ReadOnly = true;
            this.rtbGuess.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbGuess.Size = new System.Drawing.Size(80, 50);
            this.rtbGuess.TabIndex = 7;
            this.rtbGuess.Text = "";
            // 
            // btnGuess
            // 
            this.btnGuess.Location = new System.Drawing.Point(27, 369);
            this.btnGuess.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuess.Name = "btnGuess";
            this.btnGuess.Size = new System.Drawing.Size(107, 37);
            this.btnGuess.TabIndex = 8;
            this.btnGuess.Text = "Guess";
            // 
            // btnMessage
            // 
            this.btnMessage.Enabled = false;
            this.btnMessage.Location = new System.Drawing.Point(160, 343);
            this.btnMessage.Margin = new System.Windows.Forms.Padding(4);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(267, 63);
            this.btnMessage.TabIndex = 9;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(453, 369);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(107, 37);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "New";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 521);
            this.Controls.Add(this.numRange);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbMin);
            this.Controls.Add(this.rtbMin);
            this.Controls.Add(this.tbMax);
            this.Controls.Add(this.rtbMax);
            this.Controls.Add(this.tbGuess);
            this.Controls.Add(this.rtbGuess);
            this.Controls.Add(this.btnGuess);
            this.Controls.Add(this.btnMessage);
            this.Controls.Add(this.btnNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guess the Number!";
            ((System.ComponentModel.ISupportInitialize)(this.numRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGuess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Control declarations
        private NumericUpDown numRange;
        private Button btnStart;
        private TrackBar tbMin;
        private RichTextBox rtbMin;
        private TrackBar tbMax;
        private RichTextBox rtbMax;
        private TrackBar tbGuess;
        private RichTextBox rtbGuess;
        private Button btnGuess;
        private Button btnMessage;
        private Button btnNew;
    }
}
