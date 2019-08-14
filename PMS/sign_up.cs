using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace PMS
{
    public partial class sign_up : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\popo\\Documents\\PMS_db.accdb;");
        public sign_up()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            login obj = new login();
            obj.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            { 
            int mobilno;
            string usernam, pass, sq, sa, email;

            usernam = textBox1.Text;
            pass = textBox2.Text;
            sq = textBox3.Text;
            sa = textBox5.Text;
            mobilno =Convert.ToInt32(textBox4.Text);
            email = textBox7.Text;

            OleDbCommand cmd = new OleDbCommand("insert into signup values('" + usernam + "','"+pass+"','"+sq+"','"+sa+"',"+mobilno+",'" + email + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
           
                this.Visible = false;
                menu obj = new menu();
                obj.Visible = true;
                //label2.Visible = true;
                //  label2.Text = "Inserted successfully";

            }

            catch (Exception)
            {
                label2.Visible = true;
                label2.Text = "Error!!";
            }
            con.Close();

        }
    }
}
