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
    
    public partial class login : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\popo\\Documents\\PMS_db.accdb;");
        public login()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            sign_up obj = new sign_up();
            obj.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            String nam, pas;
            nam = textBox1.Text;
            pas = textBox2.Text;
            OleDbCommand cmd = new OleDbCommand("select * from signup where Username='"+nam+"' and Password='"+pas+"'",con);
            con.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.Visible = false;
                menu obj = new menu();
                obj.Visible =  true;
            }
            else
            {
                label2.Visible = true;
                label2.Text = "Username and password not valid";
            }
            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
