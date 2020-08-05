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
    public partial class ManagerForm : Form
    {

        public ManagerForm()
        {
            InitializeComponent();
            this.Text = "Manager Portal";
            listViewEmployees.Items.Clear();
            Operations.ListContents(listViewEmployees);
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {

        }
        private void ClearAllFields()
        {
            textBoxEmpFname.Clear();
            textBoxEmpLname.Clear();
            textBoxEmpPwd.Clear();
            textBoxEmpUID.Clear();
            maskedTextBoxPhoneNumber.Clear();
            comboBoxChoice.SelectedIndex = -1;
            listViewEmployees.Items.Clear();
            searchTextBox.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Validation.IsValidName(textBoxEmpFname) && Validation.IsValidName(textBoxEmpLname) && textBoxEmpUID.TextLength > 0 && textBoxEmpUID.TextLength < 10 && !string.IsNullOrEmpty(comboBoxChoice.Text.ToString())) {
                Employee emp = new Employee();
                emp.FirstName = textBoxEmpFname.Text;
                emp.LastName = textBoxEmpLname.Text;
                emp.EmployeeId = textBoxEmpUID.Text;
                emp.Password = textBoxEmpPwd.Text;
                emp.PhoneNumber = maskedTextBoxPhoneNumber.Text;
                emp.Role = comboBoxChoice.Text;
                Operations.addEmployee(emp);
                ClearAllFields();
                Operations.ListContents(listViewEmployees);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if(!Operations.SearchEmployee(searchTextBox.Text, listViewEmployees))
            {
                MessageBox.Show("Employee " + searchTextBox.Text + " does not exist!");
                ClearAllFields();
                Operations.ListContents(listViewEmployees);
            }
        }

        private void ListEmployeeButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();
            Operations.ListContents(listViewEmployees);
        }

        private void listViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }
    }
}
