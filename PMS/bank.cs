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
    public partial class bank : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\popo\\Documents\\PMS_db.accdb;");
        public bank()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            menu obj = new menu();
            obj.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string nam;
                int cod, acc, with, dep, total;
                cod = Convert.ToInt32(textBox1.Text);
                nam = textBox2.Text;
                acc = Convert.ToInt32(textBox3.Text);
                with = Convert.ToInt32(textBox4.Text);
                dep = Convert.ToInt32(textBox5.Text);
                total = with - dep;
                label9.Visible = true;
                label9.Text = " your total account balance is " + total;
                OleDbCommand cmd = new OleDbCommand("insert into bank values(" + cod + ",'" + nam + "'," + acc + "," + with + "," + dep + ",'" + DateTime.Now.ToString() + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                label2.Visible = true;
                label2.Text = "Inserted successfully";
            }
            catch (Exception)
            {
                label2.Visible = true;
                label2.Text = "Error!!";

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int cd = Convert.ToInt32(textBox1.Text);
                OleDbCommand cmd = new OleDbCommand("select * from bank where Bankcode=" + cd + "", con);
                con.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox5.Text = dr[3].ToString();
                    textBox4.Text = dr[4].ToString();
                    textBox6.Text = dr[5].ToString();
                    label2.Visible = true;
                    label2.Text = "Search Successfully";
                }
                else {
                    label2.Visible = true;
                    label2.Text = "Data Not Found";
                }
                con.Close();
            }
            catch (Exception)
            {
                label2.Visible = true;
                label2.Text = "Error!!";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try {
                con.Open();
                int id = Convert.ToInt32(textBox1.Text);
                OleDbCommand cmd = new OleDbCommand("delete from bank where Bankcode=" + id + "", con);

                cmd.ExecuteNonQuery();
                con.Close();
                label2.Visible = true;
                label2.Text = "Deleted Successfully";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
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
                string nam, dd, mm, yy;
                int cod, acc, with, dep, total;
                cod = Convert.ToInt32(textBox1.Text);
                nam = textBox2.Text;
                acc = Convert.ToInt32(textBox3.Text);
                with = Convert.ToInt32(textBox4.Text);
                dep = Convert.ToInt32(textBox5.Text);
            string dt = textBox6.Text;
                total = with - dep;
                label9.Visible = true;
                label9.Text = " your total account balance is " + total;
                OleDbCommand cmd = new OleDbCommand("update bank set bankname='" + nam + "',bankaccountnumber=" + acc + ",bankwithdraw=" + with + ",bankdeposit=" + dep + ",date1='" + dt + "' where Bankcode="+cod+"", con);
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
