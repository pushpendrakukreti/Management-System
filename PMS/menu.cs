using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToString();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Visible = false;
           staff_attendance obj = new staff_attendance();
            obj.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            bank obj = new bank();
            obj.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            sale obj = new sale();
            obj.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            daily_expenses obj = new daily_expenses();
            obj.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            purchase obj = new purchase();
            obj.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            staff obj = new staff();
            obj.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            sale_return obj = new sale_return();
            obj.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            purchase_return obj = new purchase_return();
            obj.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
           salary obj = new salary();
            obj.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            login obj = new login();
            obj.Visible = true;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            staff obj = new staff();
            obj.Visible = true;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            bank obj = new bank();
            obj.Visible = true;

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
         purchase obj = new purchase();
            obj.Visible = true;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            sign_up obj = new sign_up();
            obj.Visible = true;

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            purchase_return obj = new purchase_return();
            obj.Visible = true;

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
           staff_attendance obj = new staff_attendance();
            obj.Visible = true;

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
           sale_return obj = new sale_return();
            obj.Visible = true;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            daily_expenses obj = new daily_expenses();
            obj.Visible = true;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            sale obj = new sale();
            obj.Visible = true;

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
           salary obj = new salary();
            obj.Visible = true;
        }
    }
}
