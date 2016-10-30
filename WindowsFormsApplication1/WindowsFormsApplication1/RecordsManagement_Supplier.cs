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
    public partial class RecordsManagement_Supplier : Form
    {
        public RecordsManagement_Supplier()
        {
            InitializeComponent();
            add_data_listbox();
        }
        void add_data_listbox()
        {
            String connectionString =
            "Data Source=avi-test-db.cbg17hlkwa4g.ap-south-1.rds.amazonaws.com;" +
            "Initial Catalog=shop_erp;" +
            "User id=admin;" +
            "Password=12345678;";

            String SqlString = @"SELECT CompanyName FROM Company";

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
                            cb_company.Items.Add(Sname);
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

        private void RecordsManagement_Supplier_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecordsManagement_Company p1 = new RecordsManagement_Company();
            p1.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int compnayId=0;
            String connectionString =
            "Data Source=avi-test-db.cbg17hlkwa4g.ap-south-1.rds.amazonaws.com;" +
            "Initial Catalog=shop_erp;" +
            "User id=admin;" +
            "Password=12345678;";

            String SqlString = @"SELECT CompanyId FROM Company WHERE CompanyName='"+cb_company.Text+"'";
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
            //compnayId = 7;
            SqlString = @"INSERT INTO Supplier (CompanyId,SupplierFName,SupplierLName,EmailId,PhoneNo,AddressDetails,CityName,StateName,CountryName,PostalCode,OfficePhonePrimary,OfficePhoneSecondary,FaxNo,OfficeEmailId,Discount,DiscountIsActive,CreditDays) 
            VALUES (@compnayId,@SupplierFName,@SupplierLName,@EmailId,@PhoneNo,@AddressDetails,@CityName,@StateName,@CountryName,@PostalCode,@OfficePhonePrimary,@OfficePhoneSecondary,@FaxNo,@OfficeEmailId,@Discount,@DiscountIsActive,@CreditDays); ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Create a SqlCommand instance
                SqlCommand command = new SqlCommand(SqlString, connection);
                //Add the parameter
                command.Parameters.AddWithValue("@compnayId", compnayId);
                command.Parameters.AddWithValue("@SupplierFName", tb_fname.Text);
                command.Parameters.AddWithValue("@SupplierLName", tb_lname.Text);
                command.Parameters.AddWithValue("@EmailId", tb_c_email.Text);
                command.Parameters.AddWithValue("@PhoneNo", tb_mobile.Text);
                command.Parameters.AddWithValue("@AddressDetails", tb_address.Text);
                command.Parameters.AddWithValue("@CityName", tb_city.Text);
                command.Parameters.AddWithValue("@StateName", tb_state.Text);
                command.Parameters.AddWithValue("@CountryName", tb_country.Text);
                command.Parameters.AddWithValue("@PostalCode", tb_pin.Text);
                command.Parameters.AddWithValue("@OfficePhonePrimary", tb_pnumber.Text);
                command.Parameters.AddWithValue("@OfficePhoneSecondary", tb_snumber.Text);
                command.Parameters.AddWithValue("@FaxNo", tb_fax.Text);
                command.Parameters.AddWithValue("@OfficeEmailId", tb_email.Text);
                command.Parameters.AddWithValue("@Discount", tb_discount.Text);
                command.Parameters.AddWithValue("@DiscountIsActive", cb_discount.Checked.ToString());
                command.Parameters.AddWithValue("@CreditDays", tb_creditdays.Text);
                //command.Parameters.AddWithValue("@catagory", int.Parse(tb_catagory.ToString()));
                //command.Parameters.AddWithValue("@image", ImageToByte2(pictureBox1.Image));
                //Execute the query
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("You have updated Supplier: " + tb_fname.Text + " " + tb_lname.Text+ " as a supplier of the Company: " +cb_company.Text);
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

    }
}
