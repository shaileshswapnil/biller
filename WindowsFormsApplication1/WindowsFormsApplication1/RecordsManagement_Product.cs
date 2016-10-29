using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class RecordsManagement_Product : Form

    {
        
        public RecordsManagement_Product()
        {
            InitializeComponent();
            dp_manufacturing.Enabled = false;
            dp_expiary.Enabled = false;
            load_company_data();
            load_attribute_data();
        }
        void load_company_data()
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

        void load_attribute_data()
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
        public static byte[] ImageToByte2(Image img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dp_manufacturing_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true) 
            {
                dp_manufacturing.Enabled = true;
            }
            else dp_manufacturing.Enabled = false;
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox2.Checked==true) 
            {
                dp_expiary.Enabled = true;
            }
            else dp_expiary.Enabled = false;    
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int compnayId = 0,attributeId=0;
            DateTime? ManufacturingDate, ExpiaryDate;
            byte[] image;
            String connectionString =
            "Data Source=avi-test-db.cbg17hlkwa4g.ap-south-1.rds.amazonaws.com;" +
            "Initial Catalog=shop_erp;" +
            "User id=admin;" +
            "Password=12345678;";

            if (pb_image.Image == null)
            {
                image = null;
            }
            else
            {
                image = ImageToByte2(pb_image.Image);
            }

            if (checkBox1.Checked == true)
            {
                ManufacturingDate = dp_manufacturing.Value;
            }
            else ManufacturingDate = null;

            if (checkBox2.Checked == true)
            {
                ExpiaryDate = dp_expiary.Value;
            }
            else ExpiaryDate = null;


            String SqlString = @"SELECT CompanyId FROM Company WHERE CompanyName='" + tb_company.Text + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SqlString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            compnayId = dr.GetInt32(0);
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
            SqlString = @"SELECT AttributeId FROM Attribute WHERE AttributeName='" + tb_salts.Text + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SqlString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            attributeId = dr.GetInt32(0);
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

            SqlString = @"INSERT INTO Product (ProductName,ProductDescription,VendorSKU,AttributeId,CompanyId,CatagoryId,QuantityPerPack,PackUnit,QuantityUnit,UnitPrice,MSRP,ManufacturingDate,ExpiaryDate,UnitInStock,ReOrderQuantity,Discount,DiscountIsActive,ProductImage,Note) 
            VALUES (@ProductName,@ProductDescription,@VendorSKU,@AttributeId,@compnayId,@CatagoryId,@QuantityPerPack,@PackUnit,@QuantityUnit,@UnitPrice,@MSRP,@ManufacturingDate,@ExpiaryDate,@UnitInStock,@ReOrderQuantity,@Discount,@DiscountIsActive,@image,@Note); ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Create a SqlCommand instance
                SqlCommand command = new SqlCommand(SqlString, connection);
                //Add the parameter
                command.Parameters.AddWithValue("@compnayId", compnayId);
                command.Parameters.AddWithValue("@AttributeId", attributeId);
                
                if (ManufacturingDate == null)
                {
                    command.Parameters.AddWithValue("@ManufacturingDate", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@ManufacturingDate", ManufacturingDate);

                if (ExpiaryDate == null)
                {
                    command.Parameters.AddWithValue("@ExpiaryDate", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@ExpiaryDate", ExpiaryDate);

                if (image == null)
                {
                    SqlParameter imageParameter = new SqlParameter("@image", SqlDbType.Image);
                    imageParameter.Value = DBNull.Value;
                    command.Parameters.Add(imageParameter);
                }
                else command.Parameters.AddWithValue("@image", image);

                if (tb_product.Text == "")
                {
                    command.Parameters.AddWithValue("@ProductName", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@ProductName", tb_product.Text);

                if (tb_description.Text == "")
                {
                    command.Parameters.AddWithValue("@ProductDescription", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@ProductDescription", tb_description.Text);

                command.Parameters.AddWithValue("@VendorSKU", tb_sku.Text);
                if (tb_catagory.Text == "")
                {
                    command.Parameters.AddWithValue("@CatagoryId", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@CatagoryId", int.Parse(tb_catagory.Text));

                if (tb_qperpack.Text == "")
                {
                    command.Parameters.AddWithValue("@QuantityPerPack", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@QuantityPerPack", int.Parse(tb_qperpack.Text));

                if (cb_punit.Text == "")
                {
                    command.Parameters.AddWithValue("@PackUnit", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@PackUnit", cb_punit.Text);

                if (cb_qunit.Text == "")
                {
                    command.Parameters.AddWithValue("@QuantityUnit", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@QuantityUnit", cb_qunit.Text);

                if (tb_qperpack.Text == "")
                {
                    command.Parameters.AddWithValue("@UnitPrice", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@UnitPrice", decimal.Parse(tb_unitprice.Text));

                if (tb_msrp.Text == "")
                {
                    command.Parameters.AddWithValue("@MSRP", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@MSRP", decimal.Parse(tb_msrp.Text));

                if (tb_stock.Text == "")
                {
                    command.Parameters.AddWithValue("@UnitInStock", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@UnitInStock", int.Parse(tb_stock.Text));

                if (tb_order.Text == "")
                {
                    command.Parameters.AddWithValue("@ReOrderQuantity", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@ReOrderQuantity", int.Parse(tb_order.Text));

                if (tb_discount.Text == "")
                {
                    command.Parameters.AddWithValue("@Discount", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@Discount", decimal.Parse(tb_discount.Text));

                command.Parameters.AddWithValue("@DiscountIsActive", cb_discount.Checked.ToString());

                if (tb_note.Text == "")
                {
                    command.Parameters.AddWithValue("@Note", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@Note", tb_note.Text);

                //Execute the query
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("You have updated Product: " + tb_product.Text );
                    this.Visible = false;

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

        private void pb_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            //For any other formats
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pb_image.ImageLocation = of.FileName;

            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

    }
}
