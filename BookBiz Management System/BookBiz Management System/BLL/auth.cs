using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBiz_Management_System;
using System.Windows.Forms;
using System.IO;


namespace BookBiz_Management_System.BLL
{
    public class auth
    {
        private static string authdb = Application.StartupPath + @"\Users.dat";
        public static String AuthValidation(String user , String pass)
        {
            StreamReader sReader = new StreamReader(authdb);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                if(user == fields[2])
                {
                  if(pass == fields[3])
                    {
                        sReader.Close();
                        return fields[4];
                    }
                    else
                    {
                        sReader.Close();
                        return "WrongPwd";
                    }
                }else
                {
                    line = sReader.ReadLine();
                }
            }          
                sReader.Close();
                return "UserNotFound";
        }
    }
}
