using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace BookBiz_Management_System.VALIDATION
{
    public class Validation
    {
        public static bool IsUserValid(string username , string password)
        {
            if (username.Length == 0)
            {
                MessageBox.Show("Please Enter Your User Name");
                return false;
            }
            if (password.Length == 0)
            {
                MessageBox.Show("Please Enter Password");
                return false;
            }
            return true;
        }

        public static bool isValidEmail(TextBox text)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(text.Text);
            if (match.Success)
            {
                return true;
            }
            return false;
        }

        public static bool IsValidName(TextBox text)
        {
            if (text.TextLength == 0)
            {
                MessageBox.Show("this field Can Not be empty.", "INVALID NAME");
                text.Clear();
                text.Focus();
                return false;
            }
            else
            {
                for (int i = 0; i < text.TextLength; i++)
                {
                    if (char.IsDigit(text.Text, i) || char.IsWhiteSpace(text.Text, i))
                    {
                        MessageBox.Show("it seems you have number or space in your field please enter another name.", "INVALID NAME");
                        text.Clear();
                        text.Focus();
                        return false;
                    }

                }
            }
            return true;
        }

        public static bool IsValidContactNumber(TextBox text)
        {
            if (text.TextLength == 10 && isValidNumber(text)){
                return true;
            }
            return false;
        }

        public static bool isValidNumber(TextBox text)
        {
            int id;
            if(Int32.TryParse(text.Text, out id)){
                return true;
            }
            return false;
        }
    }
}
