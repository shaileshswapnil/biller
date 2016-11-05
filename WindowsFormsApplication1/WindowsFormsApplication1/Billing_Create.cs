using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            dataGridView2.ColumnCount = 8;
            dataGridView2.Columns[0].Name = "Sl no";
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView2.Columns[1].Name = "Product Name";
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[2].Name = "Price";
            dataGridView2.Columns[2].Width = 150;
            dataGridView2.Columns[3].Name = "Quantity";
            dataGridView2.Columns[3].Width = 150;
            dataGridView2.Columns[4].Name = "Unit";
            dataGridView2.Columns[4].Width = 150;
            dataGridView2.Columns[5].Name = "Discount";
            dataGridView2.Columns[5].Width = 150;
            dataGridView2.Columns[6].Name = "Tax";
            dataGridView2.Columns[6].Width = 150;
            dataGridView2.Columns[7].Name = "Total Amount";
            dataGridView2.Columns[7].Width = 200;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            String header = dataGridView2.Columns[1].HeaderText;
            if (header.Equals("Product Name"))
            {
                TextBox productName = e.Control as TextBox;

                if (productName != null)
                {
                    productName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
                    FillItems(stringCollection);
                    productName.AutoCompleteCustomSource = stringCollection;
                    productName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    setRowNumber(dataGridView2);
                }
            }


        }

        private void FillItems(AutoCompleteStringCollection stringCollection)
        {
            String connectionString =
            "Data Source=avi-test-db.cbg17hlkwa4g.ap-south-1.rds.amazonaws.com;" +
            "Initial Catalog=shop_erp;" +
            "User id=admin;" +
            "Password=12345678;";

            String SqlString = @"SELECT ProductName FROM Product";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SqlString, connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            String Sname = dr.GetString(0);
                            stringCollection.Add(Sname);

                        }

                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error!");
                }
                finally
                {
                    connection.Close();
                }


            }
        }
        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells[0].Value = (row.Index + 1).ToString();
            }
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            setRowNumber(dataGridView2);
        }
    }
}
