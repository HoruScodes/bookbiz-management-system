using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookBiz_Management_System.VALIDATION;
using BookBiz_Management_System.BLL;

namespace BookBiz_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "BookBiz Management System";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = this.textBoxId.Text.Trim();
            string password = this.textBoxPassword.Text.Trim();
            String userAuth = " ";
            if (Validation.IsUserValid(username, password))
            {
                userAuth = auth.AuthValidation(username, password);
                if (userAuth == "WrongPwd")
                {
                    MessageBox.Show("You Have Entered Wrong Password");
                }else if(userAuth == "UserNotFound")
                {
                    MessageBox.Show("User not found in our system!");
                }else if(userAuth == null || userAuth == "DbError")
                {
                    MessageBox.Show("Please Contact Admin!");   
                }              
            }
            openForm(userAuth);

        }

        private void openForm(String item)
        {
            if (item == "mis_manager")
            {
                Form manager = new ManagerForm();
                manager.ShowDialog();
                this.Close();
            }
            else if (item == "sales_manager")
            {
                Form salesmanager = new SalesManagerForm();
                salesmanager.ShowDialog();
                this.Close();
            }
            else if (item == "inventory_controller")
            {
                Form inv = new ManageInventory();
                inv.ShowDialog();
                this.Close();
            }
            else if (item == "order_clerk")
            {
                Form ordform = new OrdersForm();
                ordform.ShowDialog();
                this.Close();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }
    }
}
