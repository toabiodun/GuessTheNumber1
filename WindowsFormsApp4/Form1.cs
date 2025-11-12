using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        // Random number, number of attempts, and random generator
        private int secret;
        private int attempts;
        private readonly Random rng = new Random();

        public Form1()
        {
            InitializeComponent();
            InitUi();       // Set initial look and enabled states
            WireEvents();   // Attach all the button/slider event handlers
        }

        // ===============================
        //   INITIAL SETTINGS / UI STATE
        // ===============================
        private void InitUi()
        {
            // TrackBars for minimum and maximum values
            tbMin.Minimum = 1;
            tbMin.Maximum = 99;
            tbMin.Value = 1;

            tbMax.Minimum = 2;
            tbMax.Maximum = 100;
            tbMax.Value = 100;

            // Guess TrackBar setup
            tbGuess.Minimum = tbMin.Value;
            tbGuess.Maximum = tbMax.Value;
            tbGuess.Value = tbMin.Value;
            tbGuess.Enabled = false; // disabled until Start is pressed

            // Buttons setup
            btnStart.Enabled = true;
            btnGuess.Enabled = false;
            btnMessage.Enabled = false;   // used as message display only
            btnMessage.Text = "";
            btnMessage.BackColor = SystemColors.Control;
            btnMessage.ForeColor = Color.White;

            // NumericUpDown setup
            numRange.Minimum = 1;
            numRange.Maximum = 100;
            numRange.Value = 100;

            attempts = 0;

            // Display starting values
            PutNumber(rtbMin, tbMin.Value);
            PutNumber(rtbMax, tbMax.Value);
            PutNumber(rtbGuess, tbGuess.Value);

            tbMin.Enabled = tbMax.Enabled = true;
        }

        // Helper: show a number in a RichTextBox (centered and bold)
        private void PutNumber(RichTextBox box, int value)
        {
            box.Text = value.ToString();
            box.SelectAll();
            box.SelectionAlignment = HorizontalAlignment.Center;
            box.DeselectAll();
        }

        // ===============================
        //          EVENT WIRING
        // ===============================
        private void WireEvents()
        {
            // TrackBar: Minimum value changed
            tbMin.Scroll += (s, e) =>
            {
                if (tbMin.Value >= tbMax.Value)
                    tbMin.Value = tbMax.Value - 1;

                tbGuess.Minimum = tbMin.Value;
                if (tbGuess.Value < tbGuess.Minimum)
                    tbGuess.Value = tbGuess.Minimum;

                PutNumber(rtbMin, tbMin.Value);
                PutNumber(rtbGuess, tbGuess.Value);
            };

            // TrackBar: Maximum value changed
            tbMax.Scroll += (s, e) =>
            {
                if (tbMax.Value <= tbMin.Value)
                    tbMax.Value = tbMin.Value + 1;

                tbGuess.Maximum = tbMax.Value;
                if (tbGuess.Value > tbGuess.Maximum)
                    tbGuess.Value = tbGuess.Maximum;

                PutNumber(rtbMax, tbMax.Value);
                PutNumber(rtbGuess, tbGuess.Value);
            };

            // TrackBar: Guess value changed
            tbGuess.Scroll += (s, e) =>
            {
                PutNumber(rtbGuess, tbGuess.Value);
            };

            // Start button
            btnStart.Click += (s, e) =>
            {
                tbMin.Enabled = tbMax.Enabled = false;
                tbGuess.Enabled = true;
                btnGuess.Enabled = true;

                secret = rng.Next(tbMin.Value, tbMax.Value + 1);
                attempts = 0;

                btnMessage.Text = "Game started! Make a guess.";
                btnMessage.BackColor = SystemColors.ControlDark;
            };

            // Guess button
            btnGuess.Click += (s, e) =>
            {
                attempts++;
                int guess = tbGuess.Value;

                if (guess < secret)
                {
                    btnMessage.Text = "The number is higher!";
                    btnMessage.BackColor = Color.Red;
                }
                else if (guess > secret)
                {
                    btnMessage.Text = "The number is lower!";
                    btnMessage.BackColor = Color.RoyalBlue;
                }
                else
                {
                    btnMessage.Text = $"Correct! Attempts: {attempts}";
                    btnMessage.BackColor = Color.SeaGreen;

                    tbGuess.Enabled = false;
                    btnGuess.Enabled = false;
                    tbMin.Enabled = tbMax.Enabled = true;
                }
            };

            // New / Reset button
            btnNew.Click += (s, e) => InitUi();
        }
    }
}
