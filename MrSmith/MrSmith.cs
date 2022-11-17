using System;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.DirectoryServices.ActiveDirectory;

namespace MrSmith
{
    public partial class MrSmith : Form
    {
        Commands cmds = new Commands();
        SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
        SpeechSynthesizer smith = new SpeechSynthesizer();
        SpeechRecognitionEngine startlist = new SpeechRecognitionEngine();
        int RecTimeOut = 0;


        public MrSmith()
        {
            InitializeComponent();
            LB_COMMANDS.Visible = true;
            LB_COMMANDS.SelectedIndex = LB_COMMANDS.Items.Count - 1;
            for (int i = 0; i < cmds.count("Commands"); i++)
            {
                LB_COMMANDS.Items.Add(cmds.getCommands("Commands")[i]);
            }
            smith.SpeakAsync("Hallo, ich bin Mrs. Smiff und " + cmds.feedback("Commands", "Welcher Tag ist heute?") + " " + cmds.feedback("Commands", "Wie spät ist es?")+" Was kann ich für dich tun?");
        }
        private void Default_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            try
            {
                string speech = e.Result.Text;

                LB_OUTPUT.Items.Add("---Sie:---");
                LB_OUTPUT.Items.Add(speech);

                if (speech == "Schlafmodus")
                {
                    smith.SpeakAsync(cmds.feedback("Commands", speech));
                    LB_OUTPUT.Items.Add("---Smith:---");
                    LB_OUTPUT.Items.Add(cmds.feedback("Commands", speech));
                    LB_OUTPUT.SelectedIndex = LB_OUTPUT.Items.Count - 1;
                    LB_COMMANDS.Items.Clear();
                    for (int i = 0; i < cmds.count("Idle"); i++)
                    {
                        LB_COMMANDS.Items.Add(cmds.getCommands("Idle")[i]);
                    }
                    rec.RecognizeAsyncCancel();
                    startlist.RecognizeAsync(RecognizeMode.Multiple);
                }
                else if (speech == "Stop")
                {
                    smith.SpeakAsyncCancelAll();
                    smith.SpeakAsync(cmds.feedback("Commands", speech));
                    LB_OUTPUT.Items.Add("---Smith:---");
                    LB_OUTPUT.Items.Add(cmds.feedback("Commands", speech));
                    LB_OUTPUT.SelectedIndex = LB_OUTPUT.Items.Count - 1;

                }
                else if (speech == "Commands")
                {
                    if (LB_COMMANDS.Visible == false)
                    {
                        smith.SpeakAsync(cmds.feedback("Commands", speech));
                        LB_OUTPUT.Items.Add("---Smith:---");
                        LB_OUTPUT.Items.Add(cmds.feedback("Commands", speech));
                        LB_OUTPUT.SelectedIndex = LB_OUTPUT.Items.Count - 1;
                        LB_COMMANDS.SelectedIndex = LB_COMMANDS.Items.Count - 1;
                        LB_COMMANDS.Visible = true;

                    }
                    else
                    {
                        smith.SpeakAsync("Befehle werden versteckt!");
                        LB_OUTPUT.Items.Add("Smith:\tBefehle werden versteckt!");
                        LB_OUTPUT.SelectedIndex = LB_OUTPUT.Items.Count - 1;
                        LB_COMMANDS.Visible = false;
                    }
                }
                else
                {
                    smith.SpeakAsync(cmds.feedback("Commands", speech));
                    LB_OUTPUT.Items.Add("---Smith:---");
                    LB_OUTPUT.Items.Add(cmds.feedback("Commands", speech));
                    LB_OUTPUT.SelectedIndex = LB_OUTPUT.Items.Count - 1;
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void rec_SpeechRecognized(object? sender, SpeechDetectedEventArgs e)
        {
            RecTimeOut = 0;
        }

        private void Startlist_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            try
            {
                string speech = e.Result.Text;
                LB_OUTPUT.Items.Add("---Sie:---+");
                LB_OUTPUT.Items.Add(speech);
                if (speech == "Aufwachen")
                {
                    smith.SpeakAsync(cmds.feedback("Idle", speech));
                    LB_OUTPUT.Items.Add("---Smith:---");
                    LB_OUTPUT.Items.Add(cmds.feedback("Idle", speech));
                    LB_OUTPUT.SelectedIndex = LB_OUTPUT.Items.Count - 1;
                    LB_COMMANDS.Items.Clear();
                    for (int i = 0; i < cmds.count("Commands"); i++)
                    {
                        LB_COMMANDS.Items.Add(cmds.getCommands("Commands")[i]);
                    }
                    startlist.RecognizeAsyncCancel();
                    rec.RecognizeAsync(RecognizeMode.Multiple);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void TimerSpk_Tick(object sender, EventArgs e)
        {
            try
            {
                if (RecTimeOut == 10)
                {
                    rec.RecognizeAsyncCancel();
                }
                else if (RecTimeOut == 11)
                {
                    TimerSpk.Stop();
                    startlist.RecognizeAsync(RecognizeMode.Multiple);
                    RecTimeOut = 0;
                }
                cmds.actualizeTime();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MrSmith_Load(object sender, EventArgs e)
        {
           
                rec.SetInputToDefaultAudioDevice();
                rec.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(cmds.getCommands("Commands")))));
                rec.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
                rec.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(rec_SpeechRecognized);
                rec.RecognizeAsync(RecognizeMode.Multiple);

                startlist.SetInputToDefaultAudioDevice();
                startlist.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(cmds.getCommands("Idle")))));
                startlist.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Startlist_SpeechRecognized);
        }

        private void LB_COMMANDS_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                          Brushes.Black : new SolidBrush(e.BackColor);
            g.FillRectangle(brush, e.Bounds);
            e.Graphics.DrawString(LB_COMMANDS.Items[e.Index].ToString(), e.Font,
                     new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
            
        }

        private void LB_OUTPUT_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (LB_OUTPUT.Items.Count > 0)
            {
                e.DrawBackground();
                Graphics g = e.Graphics;
                Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                              Brushes.Black : new SolidBrush(e.BackColor);
                g.FillRectangle(brush, e.Bounds);
                e.Graphics.DrawString(LB_OUTPUT.Items[e.Index].ToString(), e.Font,
                         new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
        }
    } 
}