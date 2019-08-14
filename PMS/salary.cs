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
    public partial class salary : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\popo\\Documents\\PMS_db.accdb;");
        public salary()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            menu obj = new menu();
            obj.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int  salid,empid,amt ;
                string empname;
                salid = Convert.ToInt32(textBox1.Text);
                empid = Convert.ToInt32(textBox2.Text);
                empname = textBox3.Text;
                amt = Convert.ToInt32(textBox4.Text);
                
                OleDbCommand cmd = new OleDbCommand("insert into salary values(" + salid + " , " + empid + " , '" + empname + "' , '"+DateTime.Now.ToString()+"',"+amt+" )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                label2.Visible = true;
                label2.Text = "inserted successfully ";

            }
            catch (Exception)
            {
                label2.Visible = true;
                label2.Text = "error";
            }
            con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int cd = Convert.ToInt32(textBox1.Text);
                OleDbCommand cmd = new OleDbCommand("select * from salary where salaryid="+cd+" ", con);
                con.Open();
                OleDbDataReader dr=cmd.ExecuteReader();
                if(dr.Read())
                {
                    textBox1.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox5.Text = dr[3].ToString();
                    textBox4.Text = dr[4].ToString();

                    label2.Visible = true;
                    label2.Text = "search successfully";
                }
                else
                {
                    label2.Visible = true;
                    label2.Text = "data not found";
                }

            }
            catch(Exception)
            {
                label2.Visible = true;
                label2.Text = "error";

            }
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int id = Convert.ToInt32(textBox1.Text);
                OleDbCommand cmd = new OleDbCommand("delete from salary where salaryid=" + id + "", con);

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
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int salid, empid, amt;
                string empname,dt;
                salid = Convert.ToInt32(textBox1.Text);
                empid = Convert.ToInt32(textBox2.Text);
                empname = textBox3.Text;
                amt = Convert.ToInt32(textBox4.Text);
                dt = textBox5.Text;
               

                OleDbCommand cmd = new OleDbCommand("update salary set employeeid =" + empid + ",employeename='" + empname + "', salarydate='" + dt + "',amount=" + amt + "   where salaryid=" + salid + " ", con);
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
            con.Close();
        }
    }
}
