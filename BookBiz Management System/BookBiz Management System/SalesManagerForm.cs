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
    public partial class SalesManagerForm : Form
    {
        public SalesManagerForm()
        {
            InitializeComponent();
            this.Text = "Sales Manager Form";
        }

        private void SalesManagerForm_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clearAllFields();
        }

        private void clearAllFields()
        {
            textBoxClientName.Clear();
            textBoxCity.Clear();
            textBoxClientStreet.Clear();
            textBoxFaxNumber.Clear();
            textBoxCreditLimit.Clear();
            textBoxPhoneNumber.Clear();
            textBoxPostalCode.Clear();
            textBoxSeach.Clear();
            listViewClients.Items.Clear();
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            if (Validation.IsValidName(textBoxClientName) && 
                Validation.IsValidName(textBoxCity) )
            {
                Client cl = new Client();
                cl.ClientName = textBoxClientName.Text;
                cl.ClientStreet = textBoxClientStreet.Text;
                cl.ClientCity = textBoxCity.Text;
                cl.ClientPostalcode = textBoxPostalCode.Text;
                cl.ClientPhoneNumber = textBoxPhoneNumber.Text;
                cl.ClientFaxNumber = textBoxFaxNumber.Text;
                cl.ClientCreditLimit = Convert.ToInt32(textBoxCreditLimit.Text);
                Operations.addClient(cl);
                clearAllFields();
                Operations.ListClients(listViewClients);
            }
        }

        private void buttonViewClients_Click(object sender, EventArgs e)
        {
            clearAllFields();
            Operations.ListClients(listViewClients);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (Validation.IsValidName(textBoxSeach))
            {
                if (!Operations.SearchClient(textBoxSeach.Text, listViewClients)) 
                {
                    MessageBox.Show("The client you are searching for is not found in our system..");
                };
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
