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
    public partial class sale : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\popo\\Documents\\PMS_db.accdb;");
        public sale()
        {
            
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            menu obj = new menu();
            obj.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int saleid, custid, sinvoiceid,empid,salequnt,saleamt;
                
                saleid=Convert.ToInt32(textBox1.Text);
                custid=Convert.ToInt32(textBox2.Text);
                sinvoiceid=Convert.ToInt32(textBox3.Text);
                empid=Convert.ToInt32(textBox5.Text);
                salequnt=Convert.ToInt32(textBox4.Text);
                saleamt=Convert.ToInt32(textBox7.Text);

                 OleDbCommand cmd = new OleDbCommand("insert into sale values("+saleid+ ","+custid+ ","+sinvoiceid+ ","+empid+ ","+salequnt+ ","+saleamt+ ",'"+DateTime.Now.ToString()+"')", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                label2.Visible = true;
                label2.Text = "insert succesfully";
            }

            catch (Exception)
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
                OleDbCommand cmd = new OleDbCommand("select *from sale where saleid=" + cd + "", con);
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
                    textBox6.Text = dr[6].ToString();
                    label2.Visible = true;
                    label2.Text = "Search Successfully";
                }
                else
                {
                    label2.Visible = true;
                    label2.Text = "Data Not Found";
                }
            }
            catch (Exception)
            {

            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
               int saleid, custid, sinvoiceid, empid, salequnt, saleamt;
                string dt;
                saleid = Convert.ToInt32(textBox1.Text);
                custid = Convert.ToInt32(textBox2.Text);
                sinvoiceid = Convert.ToInt32(textBox3.Text);
                empid = Convert.ToInt32(textBox5.Text);
                salequnt = Convert.ToInt32(textBox4.Text);
                saleamt = Convert.ToInt32(textBox7.Text);
                dt = textBox6.Text;
                
                OleDbCommand cmd = new OleDbCommand("update sale set customerid= " + custid + ",saleinvoicenumber= " + sinvoiceid + ",employeeid= " + empid + ",salequantity= " + salequnt + " ,saleamount = " + saleamt + ",date1='" + dt + "'  where saleid = "+saleid+ "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                label2.Visible = true;
                label2.Text = "Update successfully";
            }

            catch (Exception)
            {
                label2.Visible = true;
                label2.Text = "error";
            }
            con.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int id = Convert.ToInt32(textBox1.Text);
               
                OleDbCommand cmd = new OleDbCommand("delete from sale where saleid=" + id + " ",con);
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
                textBox6.Text = "";
               
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
