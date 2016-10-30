using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void mRPBillingTaxToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salesTaxAccountRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void payRecieveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecordsManagement_Company company = new RecordsManagement_Company();
            company.Show();
        }

        private void priceListDiscountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vatInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecordsManagement_Product p3 = new RecordsManagement_Product();
            p3.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_mainpagetimer.Text =  DateTime.Now.ToLongTimeString(); 
        }

        private void lb_mainpagetimer_Click(object sender, EventArgs e)
        {
            speechSynthesizer.Dispose();
            speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.SpeakAsync("Time is now: " + lb_mainpagetimer.Text);
        }

        //private void button10_Click(object sender, EventArgs e)
        //{
        //    Choices sList = new Choices();
        //    SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();
        //    sList.Add(new string[] { "hello", "test", "it works", "add", "product", "how", "are", "you", "today", "i", "am", "fine", "exit", "close", "quit", "so" });
        //    Grammar gr = new Grammar(new GrammarBuilder(sList));
        //    try
        //    {
        //        sRecognize.RequestRecognizerUpdate();
        //        sRecognize.LoadGrammar(gr);
        //        sRecognize.SpeechRecognized += sRecognize_SpeechRecognized;
        //        sRecognize.SetInputToDefaultAudioDevice();
        //        sRecognize.RecognizeAsync(RecognizeMode.Multiple);
        //        sRecognize.Recognize();
        //    }

        //    catch
        //    {
        //        return;
        //    }
        //}
        //private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        //{
        //    MessageBox.Show(e.Result.Text.ToString());
        //    if (e.Result.Text == "exit")
        //    {
        //        Application.Exit();
        //    }
        //    else if (e.Result.Text == "add product")
        //    {
        //        RecordsManagement_Product p3 = new RecordsManagement_Product();
        //        p3.Show();
        //    }

        //}
    }
}
