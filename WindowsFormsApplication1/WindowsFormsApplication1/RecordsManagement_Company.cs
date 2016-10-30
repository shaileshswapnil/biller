using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class RecordsManagement_Company : Form
    {

        public RecordsManagement_Company()
        {
            InitializeComponent();
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

        private void RecordsManagement_Company_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            //For any other formats
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = of.FileName;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            String connectionString =
            "Data Source=avi-test-db.cbg17hlkwa4g.ap-south-1.rds.amazonaws.com;" +
            "Initial Catalog=shop_erp;" +
            "User id=admin;" +
            "Password=12345678;";

            String SqlString = @"INSERT INTO Company (CompanyName, ContactFName, ContactLName, PhoneNo,EmailID,AddressDetails,CityName,StateName,CountryName,PostalCode,FaxNo,OfficeEmailID,OfficePhonePrimary,OfficePhoneSecondary,URL,CompanyLogo) 
            VALUES (@CompnayName,@Fname,@Lname,@mobile,@email,@address,@city,@state,@country,@pin,@pnumber,@snumber,@fax,@cemail,@url,@image); ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Create a SqlCommand instance
                SqlCommand command = new SqlCommand(SqlString, connection);
                //Add the parameter
                if (tb_company.Text == "")
                {
                    MessageBox.Show("Company name can not be empty");
                    return;
                }
                else command.Parameters.AddWithValue("@CompnayName", tb_company.Text);

                if (tb_fname.Text == "")
                {
                    MessageBox.Show("Conatnt first name can not be empty");
                    return;
                }
                else command.Parameters.AddWithValue("@Fname", tb_fname.Text);

                if (tb_lname.Text == "")
                {
                    MessageBox.Show("Conatnt last name can not be empty");
                    return;
                }
                else command.Parameters.AddWithValue("@Lname", tb_lname.Text);

                if (tb_mobile.Text == "")
                {
                    MessageBox.Show("Conatnt mobile number can not be empty");
                    return;
                }
                else command.Parameters.AddWithValue("@mobile", tb_mobile.Text);

                if (tb_c_email.Text == "")
                {
                    command.Parameters.AddWithValue("@email", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@email", tb_c_email.Text);

                if (tb_address.Text == "")
                {
                    command.Parameters.AddWithValue("@address", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@address", tb_address.Text);

                if (tb_city.Text == "")
                {
                    command.Parameters.AddWithValue("@city", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@city", tb_city.Text);

                if (tb_state.Text == "")
                {
                    command.Parameters.AddWithValue("@state", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@state", tb_state.Text);

                if (tb_country.Text == "")
                {
                    command.Parameters.AddWithValue("@country", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@country", tb_country.Text);

                if (tb_pin.Text == "")
                {
                    command.Parameters.AddWithValue("@pin", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@pin", tb_pin.Text);

                if (tb_pnumber.Text == "")
                {
                    command.Parameters.AddWithValue("@pnumber", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@pnumber", tb_pnumber.Text);

                if (tb_snumber.Text == "")
                {
                    command.Parameters.AddWithValue("@snumber", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@snumber", tb_snumber.Text);

                if (tb_fax.Text == "")
                {
                    command.Parameters.AddWithValue("@fax", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@fax", tb_fax.Text);

                if (tb_email.Text == "")
                {
                    command.Parameters.AddWithValue("@cemail", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@cemail", tb_email.Text);

                if (tb_website.Text == "")
                {
                    command.Parameters.AddWithValue("@url", DBNull.Value);
                }
                else command.Parameters.AddWithValue("@url", tb_website.Text);

                if (pictureBox1.Image == null)
                {
                    SqlParameter imageParameter = new SqlParameter("@image", SqlDbType.Image);
                    imageParameter.Value = DBNull.Value;
                    command.Parameters.Add(imageParameter);
                }
                else command.Parameters.AddWithValue("@image", ImageToByte2(pictureBox1.Image));

                //Execute the query
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    String error_message = error.Message;
                    if (error_message.Contains("Violation of PRIMARY KEY constraint") == true)
                    {
                        MessageBox.Show("This company name already exists, Please try to view the details first");
                        return;
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        private void tb_mobile_TextChanged(object sender, EventArgs e)
        {

        }

        //Coding for mobile text box to accecpt number only
        private void tb_mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

    }

}

