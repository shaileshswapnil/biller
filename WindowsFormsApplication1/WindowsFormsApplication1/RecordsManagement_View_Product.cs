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
            load_product_data();
            load_company_data();
            load_attribute_data();
            DateTime toDate = DateTime.Today.Date;
            DateTime fromDate = toDate.AddDays(-30);
            dp_from.Value = fromDate;
            chk_stock.Checked = true;
            chart_unchecked("Profit");
            chart_unchecked("Sales");
            chart_unchecked("Prediction");
        }

        private void load_attribute_data()
        {
            String connectionString =
            "Data Source=avi-test-db.cbg17hlkwa4g.ap-south-1.rds.amazonaws.com;" +
            "Initial Catalog=shop_erp;" +
            "User id=admin;" +
            "Password=12345678;";

            String SqlString = @"SELECT AttributeName FROM Attribute";
            tb_salts.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_salts.AutoCompleteSource = AutoCompleteSource.CustomSource;
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

                        }

                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error!");
                }
                finally
                {
                    tb_salts.AutoCompleteCustomSource = coll;
                    connection.Close();

                }


            }

        }

        private void load_company_data()
        {
            String connectionString =
            "Data Source=avi-test-db.cbg17hlkwa4g.ap-south-1.rds.amazonaws.com;" +
            "Initial Catalog=shop_erp;" +
            "User id=admin;" +
            "Password=12345678;";

            String SqlString = @"SELECT CompanyName FROM Company";
            tb_company.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_company.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
                        }

                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error!");
                }
                finally
                {
                    tb_company.AutoCompleteCustomSource = coll;
                    connection.Close();

                }
            }

        }
        void load_product_data()
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

            cb_product.Items.Clear();
            for (int i = 0; i < coll.Count; i++)
            {
                coll.RemoveAt(0);
            }


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
            this.FormBorderStyle = FormBorderStyle.Sizable;
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
            reset_form();
            cb_product.Text = "";
        }

        private void reset_form()
        {
            DateTime toDate = DateTime.Today.Date;
            DateTime fromDate = toDate.AddDays(-30);
            dp_from.Value = fromDate;
            dp_to.Value = toDate;
            //foreach (var series in chart_sales.Series) { series.Points.Clear(); }
            //foreach (var series in chart_profit.Series) { series.Points.Clear(); }
            //foreach (var series in chart_stock.Series) { series.Points.Clear(); }
            //foreach (var series in chart_salesprediction.Series) { series.Points.Clear(); }
            tb_company.Text = "";
            tb_description.Text = "";
            tb_catagory.Text = "";
            tb_msrp.Text = "";
            tb_orderquantity.Text = "";
            tb_punit.Text = "";
            tb_qunit.Text = "";
            tb_salts.Text = "";
            tb_stock.Text = "";
            tb_unitprice.Text = "";
            cb_h.Checked = false;
            cb_h1.Checked = false;
            cb_narcotics.Checked = false;
        }



        private void cb_product_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_product.SelectedIndex > -1)
            {
                reset_form();
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
                            tb_stock.ReadOnly = true;

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
            if (chk_sales.Checked == true)
            {
                chart_unchecked("Sales");
                chart_checked("Sales");
            }
            if (chk_profit.Checked == true)
            {
                chart_unchecked("Profit");
                chart_checked("Profit");
            }
            if (chk_stock.Checked == true)
            {
                chart_unchecked("Stock");
                chart_checked("Stock");
            }
            if (chk_prediction.Checked == true)
            {
                chart_unchecked("Prediction");
                chart_checked("Prediction");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecordsManagement_Product product = new RecordsManagement_Product();
            product.TopMost = true;
            product.Show();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Are you sure that you want to update product: "+cb_product.Text+" ?", "Warning",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                update_product();
            }
            else if (result == DialogResult.No)
            {
                
            }
            else if (result == DialogResult.Cancel)
            {
                
            }
            
        }

        private void update_product()
        {
            int attributeId = 0, companyId = 0;
            String connectionString =
            "Data Source=avi-test-db.cbg17hlkwa4g.ap-south-1.rds.amazonaws.com;" +
            "Initial Catalog=shop_erp;" +
            "User id=admin;" +
            "Password=12345678;";


            String SqlString = @"Select CompanyId from Company Where CompanyName='"+tb_company.Text+"';";

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
                            companyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
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

            SqlString = @"Select AttributeId from Attribute Where AttributeName='" + tb_salts.Text + "';";

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
                            attributeId = dr.GetInt32(dr.GetOrdinal("AttributeId"));
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
            SqlString = @"Update Product SET ProductDescription=@ProductDescription,AttributeId=@AttributeId,CompanyId=@CompanyId,PackUnit=@PackUnit,QuantityUnit=@QuantityUnit,UnitPrice=@UnitPrice,MSRP=@MSRP,ReOrderQuantity=@ReOrderQuantity Where ProductName=@ProductName;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SqlString, connection);

                command.Parameters.AddWithValue("@CompanyId", companyId);
                command.Parameters.AddWithValue("@AttributeId", attributeId);
                command.Parameters.AddWithValue("@ProductName", cb_product.Text);
                if (tb_description.Text == "")
                {
                    command.Parameters.AddWithValue("@ProductDescription", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@ProductDescription", tb_description.Text);

                if (tb_punit.Text == "")
                {
                    command.Parameters.AddWithValue("@PackUnit", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@PackUnit", tb_punit.Text);

                if (tb_qunit.Text == "")
                {
                    command.Parameters.AddWithValue("@QuantityUnit", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@QuantityUnit", tb_qunit.Text);

                if (tb_unitprice.Text == "")
                {
                    command.Parameters.AddWithValue("@UnitPrice", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@UnitPrice", Decimal.Parse(tb_unitprice.Text));

                if (tb_msrp.Text == "")
                {
                    command.Parameters.AddWithValue("@MSRP", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@MSRP", Decimal.Parse(tb_msrp.Text));

                if (tb_orderquantity.Text == "")
                {
                    command.Parameters.AddWithValue("@ReOrderQuantity", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@ReOrderQuantity", int.Parse(tb_orderquantity.Text));
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("You have updated Product: " + cb_product.Text);
                    reset_form();
                    cb_product.Text = "";
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Are you sure that you want to parmanently delete product: " + cb_product.Text + " ?", "Warning",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                remove_product();
            }
            else if (result == DialogResult.No)
            {

            }
            else if (result == DialogResult.Cancel)
            {

            }
        }

        private void remove_product()
        {
            String connectionString =
            "Data Source=avi-test-db.cbg17hlkwa4g.ap-south-1.rds.amazonaws.com;" +
            "Initial Catalog=shop_erp;" +
            "User id=admin;" +
            "Password=12345678;";


            String SqlString = @"Delete from Product Where ProductName=@ProductName;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SqlString, connection);
                command.Parameters.AddWithValue("ProductName", cb_product.Text);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("You have deleted Product: " + cb_product.Text);
                    reset_form();
                    load_product_data();
                    cb_product.Text = "";
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

        private void chk_sales_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_sales.Checked == true)
            {
                chart_checked("Sales");
            }
            else
            {
                chart_unchecked("Sales");
            }
        }



        private void chk_profit_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_profit.Checked == true)
            {
                chart_checked("Profit");
            }
            else
            {
                chart_unchecked("Profit");
            }
        }

        private void chk_stock_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_stock.Checked == true)
            {
                chart_checked("Stock");
            }
            else
            {
                chart_unchecked("Stock");
            }
        }

        private void chk_prediction_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_prediction.Checked == true)
            {
                chart_checked("Prediction");
            }
            else
            {
                chart_unchecked("Prediction");
            }
        }
        private void chart_checked(String check_name)
        {
            chart1.Series[check_name].Enabled = true;
            chart1.Series[check_name].Points.Clear();
            DateTime toDate, fromDate;
            toDate = dp_to.Value;
            fromDate = dp_from.Value;
            TimeSpan totoalDays = (toDate - fromDate);
            int dayCount = totoalDays.Days;
            if (dayCount > 0 && dayCount < 60)
            {
                Random random = new Random();
                for (int i = 1; i <= dayCount; i++)
                {
                    int randomNumber = random.Next(0, 200);
                    this.chart1.Series[check_name].Points.AddXY(i, randomNumber);
                }
            }
        }

        private void chart_unchecked(String check_name)
        {
            chart1.Series[check_name].Enabled = false;
        }

    }

}
