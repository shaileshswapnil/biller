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
        public RecordsManagement_Company()
        {
            InitializeComponent();
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
                command.Parameters.AddWithValue("@CompnayName", tb_company.Text);
                command.Parameters.AddWithValue("@Fname", tb_fname.Text);
                command.Parameters.AddWithValue("@Lname", tb_lname.Text);
                command.Parameters.AddWithValue("@mobile", tb_mobile.Text);
                command.Parameters.AddWithValue("@email", tb_c_email.Text);
                command.Parameters.AddWithValue("@address", tb_address.Text);
                command.Parameters.AddWithValue("@city", tb_city.Text);
                command.Parameters.AddWithValue("@state", tb_state.Text);
                command.Parameters.AddWithValue("@country", tb_country.Text);
                command.Parameters.AddWithValue("@pin", tb_pin.Text);
                command.Parameters.AddWithValue("@pnumber", tb_pnumber.Text);
                command.Parameters.AddWithValue("@snumber", tb_snumber.Text);
                command.Parameters.AddWithValue("@fax", tb_fax.Text);
                command.Parameters.AddWithValue("@cemail", tb_email.Text);
                command.Parameters.AddWithValue("@url", tb_website.Text);
                //command.Parameters.AddWithValue("@catagory", int.Parse(tb_catagory.ToString()));
                command.Parameters.AddWithValue("@image", ImageToByte2(pictureBox1.Image));
                //Execute the query
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch(Exception error)
                {
                    MessageBox.Show(error.Message, "Error!");
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
            Char ch=e.KeyChar ;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

    }

}

