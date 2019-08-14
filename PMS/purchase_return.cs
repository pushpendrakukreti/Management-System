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
    
    public partial class purchase_return : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\popo\\Documents\\PMS_db.accdb;");
        public purchase_return()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
          try
            {
                int  pid,pinvoiceno,mobileno,amt;
                string sname,supaddr,reason ;
                pid = Convert.ToInt32(textBox1.Text);
                pinvoiceno = Convert.ToInt32(textBox2.Text);
                sname = textBox3.Text;
                mobileno = Convert.ToInt32(textBox5.Text);
                supaddr = textBox4.Text;
                amt = Convert.ToInt32(textBox7.Text);
                reason = textBox6.Text;

                OleDbCommand cmd = new OleDbCommand("insert into purchasereturn values(" + pid + " , " + pinvoiceno + " ,'" + sname + "' , " + mobileno + ", '"+ supaddr +"', "+amt+",'"+ DateTime.Now.ToString() +"' , '" +reason+ "' )",con );
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                label2.Visible = true;
                label2.Text = "insert successfully";
            }
            catch(Exception)
            {
                label2.Visible = true;
                label2.Text = "error";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int cd = Convert.ToInt32(textBox1.Text);
                OleDbCommand cmd = new OleDbCommand("Select * from purchasereturn where productid = " + cd+ " ",con );
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
                    textBox6.Text = dr[7].ToString();

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
                OleDbCommand cmd = new OleDbCommand("delete from purchasereturn where productid=" + id + "", con);

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
                textBox8.Text = "";
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
                int pid, pinvoiceno, mobileno, amt;
                string sname, supaddr, reason,dt;
                pid = Convert.ToInt32(textBox1.Text);
                pinvoiceno = Convert.ToInt32(textBox2.Text);
                sname = textBox3.Text;
                mobileno = Convert.ToInt32(textBox5.Text);
                supaddr = textBox4.Text;
                amt = Convert.ToInt32(textBox7.Text);
                reason = textBox6.Text;
                dt = textBox8.Text;
               
                OleDbCommand cmd = new OleDbCommand("update purchasereturn set invoicenumber=" + pinvoiceno + ", suppliername = '" + sname + "',mobilenumber = " + mobileno + ",supplieraddress= '" + supaddr + "',amount= " + amt + ",date1='" + dt + "',reason= '" + reason + "' where productid = " + pid + "",con);
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
