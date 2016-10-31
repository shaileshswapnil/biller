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
    public partial class RecordsManagement_View_Product : Form
    {
        public RecordsManagement_View_Product()
        {
            InitializeComponent();
            timer1.Start();
            load_company_data();
            DateTime toDate = DateTime.Today.Date;
            DateTime fromDate = toDate.AddDays(-30);
            dp_from.Value = fromDate;
        }
        void load_company_data()
        {
            String connectionString =
            "Data Source=avi-test-db.cbg17hlkwa4g.ap-south-1.rds.amazonaws.com;" +
            "Initial Catalog=shop_erp;" +
            "User id=admin;" +
            "Password=12345678;";

            String SqlString = @"SELECT ProductName FROM Product";
            cb_product.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_product.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();


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
                            coll.Add(Sname);
                            cb_product.Items.Add(Sname);
                        }

                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error!");
                }
                finally
                {
                    cb_product.AutoCompleteCustomSource = coll;
                    connection.Close();

                }


            }
        }

        private void RecordsManagement_View_Product_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToShortTimeString();
            label3.Text = DateTime.Now.ToLongDateString();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void cb_product_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_product.SelectedIndex > -1)
            {
                String productName = cb_product.Text;
                populate_product_data(productName);

            }
            else if (cb_product.SelectedIndex <= -1) MessageBox.Show("This product is not available at the database, please add the product first");
        }
        void populate_product_data(String productName)
        {
            String connectionString =
            "Data Source=avi-test-db.cbg17hlkwa4g.ap-south-1.rds.amazonaws.com;" +
            "Initial Catalog=shop_erp;" +
            "User id=admin;" +
            "Password=12345678;";

            String SqlString = @"SELECT Product.*, Company.*, Attribute.* FROM Product JOIN Company ON Company.CompanyId = Product.CompanyId JOIN Attribute ON Attribute.AttributeId = Product.AttributeId WHERE Product.ProductName= '" + productName + "';";

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
                            if (dr.IsDBNull(dr.GetOrdinal("CompanyName")))
                            {
                                tb_company.Text = "";
                            } else tb_company.Text = dr.GetString(dr.GetOrdinal("CompanyName"));

                            if (dr.IsDBNull(dr.GetOrdinal("ProductDescription")))
                            {
                                tb_description.Text = "";
                            }
                            else tb_description.Text = dr.GetString(dr.GetOrdinal("ProductDescription"));

                            if (dr.IsDBNull(dr.GetOrdinal("CatagoryId")))
                            {
                                tb_catagory.Text = "";
                            }
                            else tb_catagory.Text = dr.GetString(dr.GetOrdinal("CatagoryId"));

                            if (dr.IsDBNull(dr.GetOrdinal("AttributeName")))
                            {
                                tb_salts.Text = "";
                            }
                            else tb_salts.Text = dr.GetString(dr.GetOrdinal("AttributeName"));

                            if (dr.IsDBNull(dr.GetOrdinal("UnitPrice")))
                            {
                                tb_unitprice.Text = "";
                            }
                            else tb_unitprice.Text = dr.GetDecimal(dr.GetOrdinal("UnitPrice")).ToString("0.00");

                            if (dr.IsDBNull(dr.GetOrdinal("MSRP")))
                            {
                                tb_msrp.Text = "";
                            }
                            else tb_msrp.Text = dr.GetDecimal(dr.GetOrdinal("MSRP")).ToString("0.00");

                            if (dr.IsDBNull(dr.GetOrdinal("QuantityUnit")))
                            {
                                tb_qunit.Text = "";
                            }
                            else tb_qunit.Text = dr.GetString(dr.GetOrdinal("QuantityUnit"));

                            if (dr.IsDBNull(dr.GetOrdinal("PackUnit")))
                            {
                                tb_punit.Text = "";
                            }
                            else tb_punit.Text = dr.GetString(dr.GetOrdinal("PackUnit"));


                            tb_stock.Text = ""; //Stock code will be crated after creation of inventory

                            if (dr.IsDBNull(dr.GetOrdinal("ReorderQuantity")))
                            {
                                tb_orderquantity.Text = "";
                            }
                            else tb_orderquantity.Text = dr.GetInt32(dr.GetOrdinal("ReorderQuantity")).ToString();

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

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var series in chart_sales.Series) { series.Points.Clear(); }
            foreach (var series in chart_profit.Series) { series.Points.Clear(); }
            foreach (var series in chart_stock.Series) { series.Points.Clear(); }
            Random random=new Random();
            for(int i=1;i<=30;i++)
            {
                int randomNumber = random.Next(0, 200);
                this.chart_sales.Series["Sales"].Points.AddXY(i, randomNumber);
                randomNumber = random.Next(0, 200);
                this.chart_profit.Series["Profit"].Points.AddXY(i, randomNumber);
                randomNumber = random.Next(0, 200);
                this.chart_stock.Series["Stock"].Points.AddXY(i, randomNumber);
            }
        }

        private void chart_sales_Click(object sender, EventArgs e)
        {

        }

        private void dp_from_ValueChanged(object sender, EventArgs e)
        {
            calender_change();
        }

        private void dp_to_ValueChanged(object sender, EventArgs e)
        {
            calender_change();
        }
        private void calender_change()
        {
            DateTime toDate, fromDate;
            toDate = dp_to.Value;
            fromDate = dp_from.Value;
            TimeSpan totoalDays = (toDate-fromDate);
            int dayCount = totoalDays.Days;
            if (dayCount > 0 || dayCount < 60)
            {
                foreach (var series in chart_sales.Series) { series.Points.Clear(); }
                foreach (var series in chart_profit.Series) { series.Points.Clear(); }
                foreach (var series in chart_stock.Series) { series.Points.Clear(); }
                foreach (var series in chart_salesprediction.Series) { series.Points.Clear(); }
                Random random = new Random();
                for (int i = 1; i <= dayCount; i++)
                {
                    int randomNumber = random.Next(0, 200);
                    this.chart_sales.Series["Sales"].Points.AddXY(i, randomNumber);
                    randomNumber = random.Next(0, 200);
                    this.chart_profit.Series["Profit"].Points.AddXY(i, randomNumber);
                    randomNumber = random.Next(0, 200);
                    this.chart_stock.Series["Stock"].Points.AddXY(i, randomNumber);
                    randomNumber = random.Next(0, 200);
                    this.chart_salesprediction.Series["Sales Prediction"].Points.AddXY(i, randomNumber);
                }
            }
        }
    }
}
