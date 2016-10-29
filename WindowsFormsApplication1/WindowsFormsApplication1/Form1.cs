using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
            RecordsManagement_Company p1 = new RecordsManagement_Company();
            p1.Show();
        }

        private void priceListDiscountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
