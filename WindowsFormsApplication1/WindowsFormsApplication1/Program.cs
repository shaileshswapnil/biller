using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static void ClearControl(Control control)
        {
            if (control is TextBox)
            {
                TextBox txtbox = (TextBox)control;
                txtbox.Text = string.Empty;
            }
            else if (control is CheckBox)
            {
                CheckBox chkbox = (CheckBox)control;
                chkbox.Checked = false;
            }
            else if (control is RadioButton)
            {
                RadioButton rdbtn = (RadioButton)control;
                rdbtn.Checked = false;
            }
            else if (control is ComboBox)
            {
                ComboBox cmb = (ComboBox)control;
                cmb.SelectedItem = string.Empty;
                cmb.SelectedValue = 0;

            }

            // repeat for combobox, listbox, checkbox and any other controls you want to clear
            if (control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    ClearControl(child);
                }
            }


        }

    }
}
