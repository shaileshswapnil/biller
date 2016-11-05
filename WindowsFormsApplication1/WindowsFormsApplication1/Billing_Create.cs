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
    public partial class Billing_Create : Form
    {
        public Billing_Create()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void Billing_Create_Load(object sender, EventArgs e)
        {
            tb_orderdate.Text = DateTime.Now.ToShortDateString();
            tb_ordertime.Text = DateTime.Now.ToShortTimeString();
            //dataGridView2.ColumnCount = 6;
            //dataGridView2.Columns[0].Name = "Product ID";
            //dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView2.Columns[1].Name = "Product Name";
            //dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView2.Columns[2].Name = "Strip";
            //dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView2.Columns[3].Name = "Pcs";
            //dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView2.Columns[4].Name = "Price";
            //dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView2.Columns[5].Name = "Tax";
            //dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
