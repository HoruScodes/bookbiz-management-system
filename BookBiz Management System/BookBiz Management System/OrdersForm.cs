using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookBiz_Management_System.BLL;
using BookBiz_Management_System.VALIDATION;

namespace BookBiz_Management_System
{
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
            this.Text = "Order Management";
            Operations.ListOrders(listViewOrders);
            Operations.getBooks(comboBoxBooks);
            Operations.getClients(comboBoxClients);
        }
        private void clearAllFields()
        {
            comboBoxBooks.SelectedIndex = -1;
            comboBoxClients.SelectedIndex = -1;
            textBoxQuantity.Clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            clearAllFields();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(
               Validation.isValidNumber(textBoxQuantity) && comboBoxBooks.SelectedIndex != -1 && comboBoxClients.SelectedIndex != -1)
            {
                Orders item = new Orders();
                item.BookName = comboBoxBooks.Text;
                item.ClientName = comboBoxClients.Text;
                item.Quantity = textBoxQuantity.Text;
                item.Date = dateTimePicker1.Value.ToShortDateString();
                foreach (RadioButton r in groupBox1.Controls)
                {
                    if (r.Checked)
                        item.TakenVia = r.Text;
                }
                Operations.placeOrder(item);
                Operations.ListOrders(listViewOrders);

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void textBoxBookName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBoxBooks.SelectedIndex != -1 && comboBoxClients.SelectedIndex != -1)
            {
                Operations.searchOrder(comboBoxBooks.Text, comboBoxClients.Text , listViewOrders);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to cancel this order?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (comboBoxBooks.SelectedIndex != -1 && comboBoxClients.SelectedIndex != -1)
                {
                    MessageBox.Show("Sales Manager is informed about cancellation , please wait some time");
                    // Operations.CancelOrder(comboBoxBooks.Text, comboBoxClients.Text);
                }   // this method was deleting each entry in the file thats why this is incomplete.
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Operations.ListOrders(listViewOrders);
        }
    }
}
