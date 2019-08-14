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
    public partial class staff : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\popo\\Documents\\PMS_db.accdb;");
        public staff()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            menu obj = new menu();
            obj.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string snam, sdesignation, saddr, sjoiningdate;
                int sid, ssalary, smobil;
                sid = Convert.ToInt32(textBox1.Text);
                snam = textBox2.Text;
                sjoiningdate = textBox3.Text;
                ssalary = Convert.ToInt32(textBox5.Text);
                sdesignation = textBox4.Text;
                saddr = textBox7.Text;
                smobil = Convert.ToInt32(textBox8.Text);

                //
                //OleDbCommand cmd = new OleDbCommand("update staff set staffname='" + snam + "', date1='" + sjoiningdate + "',staffsalary=" + ssalary + ",staffdesignation='" + sdesignation + "',staffaddress='" + saddr + "',staffmobilenumber=" + smobil + " where staffid=" + sid + " ", con);
                OleDbCommand cmd = new OleDbCommand("update staff set staffname='"+snam+"', date1='"+sjoiningdate+"',staffsalary="+ssalary+ ",staffdesignation='"+sdesignation+ "',staffaddress='"+saddr+ "',staffmobilenumber="+smobil+" where staffid="+sid+"", con);

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string snam, sdesignation,saddr;
                int sid,  ssalary, smobil;
                sid = Convert.ToInt32(textBox1.Text);
                snam = textBox2.Text;
               
                ssalary = Convert.ToInt32(textBox5.Text);
                sdesignation =textBox4.Text;
                saddr = textBox7.Text;
                smobil = Convert.ToInt32(textBox8.Text);
                
                OleDbCommand cmd = new OleDbCommand("insert into staff values(" + sid + " , '" + snam + "' , '" + DateTime.Now.ToString() +"' , " + ssalary + " , '" + sdesignation + "' , '" + saddr + "' , " + smobil + ")", con);
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
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int cd = Convert.ToInt32(textBox1.Text);
                OleDbCommand cmd = new OleDbCommand("select * from staff where staffid = " + cd + " ", con);
                con.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox5.Text = dr[3].ToString();
                    textBox4.Text = dr[4].ToString();
                    textBox7.Text = dr[5].ToString();
                    textBox8.Text = dr[6].ToString();

                    label2.Visible = true;
                    label2.Text = "Search Successfully";
                 }
                else
                {
                    label2.Visible = true;
                    label2.Text = "data not found";
                }
                con.Close();
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
                OleDbCommand cmd = new OleDbCommand("delete from staff where staffid=" + id + "", con);

                cmd.ExecuteNonQuery();
                con.Close();
                label2.Visible = true;
                label2.Text = "Deleted Successfully";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
                textBox4.Text = "";
                textBox7.Text = "";
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
