using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private int secret;
        private int attempts;
        private readonly Random rng = new Random();

        public Form1()
        {
            InitializeComponent();
            InitUi();
            WireEvents();
        }

        // ===============================
        //   INITIAL SETTINGS / UI STATE
        // ===============================
        private void InitUi()
        {
            // Range sliders
            tbMin.Minimum = 1;
            tbMin.Maximum = 99;
            tbMin.Value = 1;

            tbMax.Minimum = 2;
            tbMax.Maximum = 100;
            tbMax.Value = 100;

            // Guess slider follows range; disabled until Start
            tbGuess.Minimum = tbMin.Value;
            tbGuess.Maximum = tbMax.Value;
            tbGuess.Value = tbMin.Value;
            tbGuess.Enabled = false;

            // Buttons / message
            btnStart.Enabled = true;
            btnGuess.Enabled = false;
            btnMessage.Enabled = false;             // used as a label
            btnMessage.Text = "";
            btnMessage.BackColor = SystemColors.Control;
            btnMessage.ForeColor = Color.White;

            // NumericUpDown mirrors the current maximum (and is editable before Start)
            numRange.Minimum = 1;
            numRange.Maximum = 100;
            numRange.Value = tbMax.Value;
            numRange.Enabled = true;               // ← editable before the game

            attempts = 0;

            // Display starting numbers
            PutNumber(rtbMin, tbMin.Value);
            PutNumber(rtbMax, tbMax.Value);
            PutNumber(rtbGuess, tbGuess.Value);

            // Range controls editable before Start
            tbMin.Enabled = tbMax.Enabled = true;
        }

        // Helper: show centered big number in RichTextBox
        private void PutNumber(RichTextBox box, int value)
        {
            box.Text = value.ToString();
            box.SelectAll();
            box.SelectionAlignment = HorizontalAlignment.Center;
            box.DeselectAll();
        }

        // ===============================
        //            EVENTS
        // ===============================
        private void WireEvents()
        {
            // MIN slider
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

            // MAX slider (keeps NumericUpDown in sync)
            tbMax.Scroll += (s, e) =>
            {
                if (tbMax.Value <= tbMin.Value)
                    tbMax.Value = tbMin.Value + 1;

                tbGuess.Maximum = tbMax.Value;
                if (tbGuess.Value > tbGuess.Maximum)
                    tbGuess.Value = tbGuess.Maximum;

                // sync numRange to tbMax
                if (numRange.Value != tbMax.Value)
                {
                    int v = Math.Max((int)numRange.Minimum, Math.Min((int)numRange.Maximum, tbMax.Value));
                    numRange.Value = v;
                }

                PutNumber(rtbMax, tbMax.Value);
                PutNumber(rtbGuess, tbGuess.Value);
            };

            // GUESS slider
            tbGuess.Scroll += (s, e) =>
            {
                PutNumber(rtbGuess, tbGuess.Value);
            };

            // NUMERIC UP/DOWN → updates MAX & displays (two-way binding)
            numRange.ValueChanged += (s, e) =>
            {
                int newMax = (int)numRange.Value;

                // Ensure newMax is always > min
                if (newMax <= tbMin.Value)
                {
                    newMax = tbMin.Value + 1;
                    numRange.Value = newMax; // reflect corrected value
                }

                // Update Max slider range/value and displays
                tbMax.Maximum = Math.Max(tbMax.Maximum, newMax); // ensure we can set Value
                tbMax.Value = newMax;

                tbGuess.Maximum = newMax;
                if (tbGuess.Value > newMax)
                    tbGuess.Value = newMax;

                PutNumber(rtbMax, newMax);
                PutNumber(rtbGuess, tbGuess.Value);
            };

            // START
            btnStart.Click += (s, e) =>
            {
                // lock range controls during the round
                tbMin.Enabled = tbMax.Enabled = false;
                numRange.Enabled = false;       // 🔒 lock NumericUpDown
                tbGuess.Enabled = true;
                btnGuess.Enabled = true;
                btnStart.Enabled = false;

                secret = rng.Next(tbMin.Value, tbMax.Value + 1);
                attempts = 0;

                btnMessage.Text = "Game started! Make a guess.";
                btnMessage.BackColor = SystemColors.ControlDark;
            };

            // GUESS
            btnGuess.Click += (s, e) =>
            {
                attempts++;
                int g = tbGuess.Value;

                if (g < secret)
                {
                    btnMessage.Text = "The number is higher!";
                    btnMessage.BackColor = Color.Red;
                }
                else if (g > secret)
                {
                    btnMessage.Text = "The number is lower!";
                    btnMessage.BackColor = Color.RoyalBlue;
                }
                else
                {
                    btnMessage.Text = $"Correct! Attempts: {attempts}";
                    btnMessage.BackColor = Color.SeaGreen;

                    // end of round
                    tbGuess.Enabled = false;
                    btnGuess.Enabled = false;

                    // unlock range controls for next round
                    tbMin.Enabled = tbMax.Enabled = true;
                    numRange.Enabled = true;     // 🔓 unlock NumericUpDown
                    btnStart.Enabled = true;
                }
            };

            // NEW / RESET
            btnNew.Click += (s, e) => InitUi();
        }
    }
}
