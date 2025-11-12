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

        // Game state flag + pending range that we only apply on Start
        private bool gameActive = false;
        private int pendingMin;
        private int pendingMax;

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
            gameActive = false;

            // Range sliders (user can set these before Start)
            tbMin.Minimum = 1;
            tbMin.Maximum = 99;
            tbMin.Value = 1;

            tbMax.Minimum = 2;
            tbMax.Maximum = 100;
            tbMax.Value = 100;

            // Save the user's range choices as "pending"
            pendingMin = tbMin.Value;
            pendingMax = tbMax.Value;

            // Guess slider: do NOT bind its Min/Max to tbMin/tbMax yet
            // Keep a neutral full range so it won't auto-clamp when user edits Min/Max
            tbGuess.Minimum = 1;
            tbGuess.Maximum = 100;
            tbGuess.Value = 1;          // any value you like; it's disabled anyway
            tbGuess.Enabled = false;

            // Buttons / message
            btnStart.Enabled = true;
            btnGuess.Enabled = false;
            btnMessage.Enabled = false;          // used as message label
            btnMessage.Text = "";
            btnMessage.BackColor = SystemColors.Control;
            btnMessage.ForeColor = Color.White;

            // NumericUpDown mirrors the current maximum (editable before Start)
            numRange.Minimum = 1;
            numRange.Maximum = 100;
            numRange.Value = tbMax.Value;
            numRange.Enabled = true;

            attempts = 0;

            // Displays
            PutNumber(rtbMin, tbMin.Value);
            PutNumber(rtbMax, tbMax.Value);
            PutNumber(rtbGuess, tbGuess.Value);

            // Range controls active before Start
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
            // MIN slider — update display and pendingMin only
            tbMin.Scroll += (s, e) =>
            {
                if (tbMin.Value >= tbMax.Value)
                    tbMin.Value = tbMax.Value - 1;

                pendingMin = tbMin.Value;          // remember user's choice
                PutNumber(rtbMin, tbMin.Value);

                // IMPORTANT: do NOT touch tbGuess.Minimum here when gameActive == false
                // That avoids WinForms auto-clamping tbGuess.Value and "moving" the slider.
            };

            // MAX slider — update display, pendingMax, and keep NumericUpDown in sync
            tbMax.Scroll += (s, e) =>
            {
                if (tbMax.Value <= tbMin.Value)
                    tbMax.Value = tbMin.Value + 1;

                pendingMax = tbMax.Value;          // remember user's choice
                PutNumber(rtbMax, tbMax.Value);

                // Keep NumericUpDown synced to Max BEFORE the game
                if (!gameActive && numRange.Value != tbMax.Value)
                {
                    int v = Math.Max((int)numRange.Minimum, Math.Min((int)numRange.Maximum, tbMax.Value));
                    numRange.Value = v;
                }

                // Again: do NOT touch tbGuess.Maximum here pre-start.
            };

            // GUESS slider — only updates its own display on manual move
            tbGuess.Scroll += (s, e) =>
            {
                PutNumber(rtbGuess, tbGuess.Value);
            };

            // NUMERIC UP/DOWN — keep it in sync with Max BEFORE the game
            numRange.ValueChanged += (s, e) =>
            {
                if (gameActive) return; // locked during the game

                int newMax = (int)numRange.Value;

                // Ensure newMax is always > pendingMin
                if (newMax <= pendingMin)
                {
                    newMax = pendingMin + 1;
                    numRange.Value = newMax; // reflect corrected value
                }

                // Update tbMax and display — but still do NOT touch tbGuess yet
                tbMax.Maximum = Math.Max(tbMax.Maximum, newMax);
                tbMax.Value = newMax;
                pendingMax = newMax;

                PutNumber(rtbMax, newMax);
            };

            // START — apply the pending range to tbGuess *now*
            btnStart.Click += (s, e) =>
            {
                gameActive = true;

                // Lock range controls during play
                tbMin.Enabled = tbMax.Enabled = false;
                numRange.Enabled = false;      // 🔒 lock numeric up/down
                tbGuess.Enabled = true;
                btnGuess.Enabled = true;
                btnStart.Enabled = false;

                // Apply the user's chosen range to the Guess slider only at start
                tbGuess.Minimum = pendingMin;
                tbGuess.Maximum = pendingMax;

                // Choose a sensible starting guess (midpoint)
                tbGuess.Value = (pendingMin + pendingMax) / 2;
                PutNumber(rtbGuess, tbGuess.Value);

                // Create the secret in the applied range
                secret = rng.Next(pendingMin, pendingMax + 1);
                attempts = 0;

                btnMessage.Text = "Game started! Make a guess.";
                btnMessage.BackColor = SystemColors.ControlDark;
            };

            // GUESS button
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

                    // End round
                    tbGuess.Enabled = false;
                    btnGuess.Enabled = false;

                    // Unlock controls for new round
                    gameActive = false;
                    tbMin.Enabled = tbMax.Enabled = true;
                    numRange.Enabled = true;   // 🔓 unlock numeric up/down
                    btnStart.Enabled = true;
                }
            };

            // NEW / RESET button
            btnNew.Click += (s, e) => InitUi();
        }
    }
}
