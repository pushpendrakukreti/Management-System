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
    public partial class market : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\popo\\Documents\\PMS_db.accdb;");
        public market()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            menu obj = new menu();
            obj.Visible = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int mid, empid,exp;
                string texp;
                mid = Convert.ToInt32(textBox1.Text);
                empid = Convert.ToInt32(textBox2.Text);
                texp = textBox3.Text;
                exp = Convert.ToInt32(textBox5.Text);

                OleDbCommand cmd = new OleDbCommand("insert into market values( " + mid + "," + empid + ",'" + texp + "' , " + exp + ",'" + DateTime.Now.ToString() + "')",con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                label2.Visible = true;
                label2.Text = "Inserted successfully";
            }
            catch(Exception)
            {
                label2.Visible = true;
                label2.Text = "Error!!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int cd = Convert.ToInt32(textBox1.Text);
                OleDbCommand cmd = new OleDbCommand("select *from market where marketid= "+cd+" ",con);
                con.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox5.Text = dr[3].ToString();
                    textBox4.Text = dr[4].ToString();
                    label2.Visible = true;
                    label2.Text = "Search Successfully";
                }
                else
                {
                    label2.Visible = true;
                    label2.Text = "data not found";
                }
            }
            catch (Exception)
            {
                label2.Visible = true;
                label2.Text = "error";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int id = Convert.ToInt32(textBox1.Text);
                OleDbCommand cmd = new OleDbCommand("delete from market where marketid=" + id + "", con);

                cmd.ExecuteNonQuery();
                con.Close();
                label2.Visible = true;
                label2.Text = "Deleted Successfully";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
                textBox4.Text = "";
             }
            catch (Exception)
            {
                label2.Visible = true;
                label2.Text = "Error!!";
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int mid, empid, exp;
                string texp,dt;
                mid = Convert.ToInt32(textBox1.Text);
                empid = Convert.ToInt32(textBox2.Text);
                texp = textBox3.Text;
                exp = Convert.ToInt32(textBox5.Text);
                dt = textBox4.Text;

                OleDbCommand cmd = new OleDbCommand("Update market set employeeid = "+empid+", typeofmarket = '"+ texp+"', expenses = "+exp+", date = '"+dt+"' where marketid= "+mid+"", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                label2.Visible = true;
                label2.Text = "Updated successfully";
            }
            catch (Exception)
            {
                label2.Visible = true;
                label2.Text = "Error!!";

            }

        }
    }
}
