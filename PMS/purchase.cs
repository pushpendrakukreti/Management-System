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
    public partial class purchase : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\popo\\Documents\\PMS_db.accdb;");
        public purchase()
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
            textBox5.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox6.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                int invoiceno, vid, itemid,noofitem,totalamt,vno;
                string vname;

                invoiceno = Convert.ToInt32(textBox1.Text);
                vid = Convert.ToInt32(textBox2.Text);
                vname = textBox3.Text;
                itemid = Convert.ToInt32(textBox5.Text);
                noofitem = Convert.ToInt32(textBox4.Text);
                totalamt = Convert.ToInt32(textBox7.Text);
                vno = Convert.ToInt32(textBox8.Text);
                
                OleDbCommand cmd = new OleDbCommand("insert into purchase values(" + invoiceno + "," + vid + ",'" + vname + "'," + itemid + "," + noofitem + "," + totalamt + "," + vno + ",'"+ DateTime.Now.ToString() +"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                label2.Visible = true;
                label2.Text = "insert successfully";

             }
            catch (Exception)
            {
                label2.Visible = true;
                label2.Text = "error";
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int cd = Convert.ToInt32(textBox1.Text);
                OleDbCommand cmd = new OleDbCommand("Select * from purchase where purchasedinvoicenumber = "+cd+" ",con );
                con.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
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
                OleDbCommand cmd = new OleDbCommand("delete from purchase where purchasedinvoicenumber=" + id + "", con);

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
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int invoiceno, vid, itemid, noofitem, totalamt, vno;
                string vname,dt;

                invoiceno = Convert.ToInt32(textBox1.Text);
                vid = Convert.ToInt32(textBox2.Text);
                vname = textBox3.Text;
                itemid = Convert.ToInt32(textBox5.Text);
                noofitem = Convert.ToInt32(textBox4.Text);
                totalamt = Convert.ToInt32(textBox7.Text);
                vno = Convert.ToInt32(textBox8.Text);
                dt = textBox6.Text;

                OleDbCommand cmd = new OleDbCommand("update purchase set vendorid=" + vid + ", vendorname='" + vname + "', itemid=" + itemid + ",numberofitem=" + noofitem + ",totalamount=" + totalamt + ",vendornumber=" + vno + ",date1 = '" + dt + "' where purchasedinvoicenumber=" + invoiceno + " ", con);
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
