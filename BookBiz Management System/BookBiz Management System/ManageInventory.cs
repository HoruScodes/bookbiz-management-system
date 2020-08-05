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
    public partial class ManageInventory : Form
    {
        public ManageInventory()
        {
            InitializeComponent();
            this.Text = "Manage Inventory of Bookbiz";
        }

        private void ManageInventory_Load(object sender, EventArgs e)
        {

        }

        private void ClearAllFields()
        {
            textBoxAuthorFname.Clear();
            textBoxAuthorLname.Clear();
            textBoxPublisherName.Clear();
            textBoxPublicationYear.Clear();
            textBoxISBN.Clear();
            textBoxBookName.Clear();
            textBoxUnitPrice.Clear();
            textBoxQOH.Clear();
            textBoxCatagory.Clear();
            textBoxAuthorEmail.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(
               Validation.IsValidName(textBoxCatagory) &&
               Validation.IsValidName(textBoxPublisherName) &&
               Validation.IsValidName(textBoxAuthorFname) &&
               Validation.IsValidName(textBoxAuthorLname) &&
               Validation.IsValidName(textBoxAuthorEmail)){
                Inventory item = new Inventory();
                Book bk = new Book();
                Author ath = new Author();

                bk.ISBN = textBoxISBN.Text;
                bk.Title = textBoxBookName.Text;
                bk.Category = textBoxCatagory.Text;
                bk.UnitPrice = Convert.ToInt32(textBoxUnitPrice.Text);
                bk.PublicationYear = Convert.ToInt32(textBoxPublicationYear.Text);
                item.PublisherName = textBoxPublisherName.Text;
                item.QOH = Convert.ToInt32(textBoxQOH.Text);
                ath.AuthorFname = textBoxAuthorFname.Text;
                ath.AuthorLname = textBoxAuthorLname.Text;
                ath.AuthorEmail = textBoxAuthorEmail.Text;
                Operations.addItemToInventory(item, ath, bk);
            } 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearAllFields();
            Operations.ListInventory(listViewInventory);
        }

        private void listViewInventory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
                if (!Operations.SearchBook(searchTextBox.Text, listViewInventory))
                {
                    MessageBox.Show("Book " + searchTextBox.Text + " is not available at the moment!");
                    ClearAllFields();
                    Operations.ListInventory(listViewInventory);
                }
           
            
        }
    }
}
