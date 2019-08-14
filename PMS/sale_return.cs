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
    public partial class sale_return : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\popo\\Documents\\PMS_db.accdb;");
        public sale_return()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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
            textBox8.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
           try
            {
                int invoiceno,saleid,amt ;
                string salename,saleaddr,reason;

                invoiceno = Convert.ToInt32(textBox1.Text);
                saleid = Convert.ToInt32(textBox2.Text);
                salename = textBox3.Text;
                saleaddr = textBox5.Text;
                amt = Convert.ToInt32(textBox4.Text);
                reason = textBox8.Text;

               OleDbCommand cmd = new OleDbCommand("insert into salereturn values(" + invoiceno + "," + saleid + ",'" + salename + "','" + saleaddr + "'," + amt + ",'"+DateTime.Now.ToString()+"','" + reason + "')", con);
         

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
           // OleDbCommand cmd = new OleDbCommand();


           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                int cd = Convert.ToInt32(textBox1.Text);
                OleDbCommand cmd = new OleDbCommand("Select * from salereturn where invoicenumber = " + cd + " ", con);
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
                OleDbCommand cmd = new OleDbCommand("delete from salereturn where invoicenumber=" + id + "", con);

                cmd.ExecuteNonQuery();
                con.Close();
                label2.Visible = true;
                label2.Text = "Deleted Successfully";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                textBox8.Text = "";
                
            }
            catch (Exception)
            {
                label2.Visible = true;
                label2.Text = "Error!!";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           /* try
            {*/
                int invoiceno, saleid, amt;
                string salename, saleaddr, reason,dt;
                invoiceno = Convert.ToInt32(textBox1.Text);
                saleid = Convert.ToInt32(textBox2.Text);
                salename = textBox3.Text;
                saleaddr = textBox5.Text;
                amt = Convert.ToInt32(textBox4.Text);
                reason = textBox8.Text;
                dt = textBox6.Text;

                OleDbCommand cmd = new OleDbCommand("update salereturn set  saleid= " + saleid + ",salename= '" + salename + "', saleaddress= '" + saleaddr + "',amount= " + amt + ",date1='" + dt + "',reason='" + reason + "' where invoicenumber=" + invoiceno + " ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                label2.Visible = true;
                label2.Text = "Updated successfully";
          /*  }
            catch (Exception)
            {
                label2.Visible = true;
                label2.Text = "Error!!";
            }
            */
        }
    }
}
