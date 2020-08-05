using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BookBiz_Management_System.BLL
{
    public class Operations
    {
        private static string authdb = Application.StartupPath + @"\Users.dat";
        private static string clientdb = Application.StartupPath + @"\Clients.dat";
        private static string authordb = Application.StartupPath + @"\Authors.dat";
        private static string inventorydb = Application.StartupPath + @"\Inventory.dat";
        private static string bookdb = Application.StartupPath + @"\Books.dat";
        private static string orderdb = Application.StartupPath + @"\Orders.dat";
        private static string temp = Application.StartupPath + @"\temp.dat";



        public static void ListContents(ListView listViewItems)
        {
            StreamReader sReader = new StreamReader(authdb);
            listViewItems.Items.Clear();
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[5]);
                item.SubItems.Add(fields[4]);
                listViewItems.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        public static void ListInventory(ListView listViewItems)
        {
            StreamReader sReader1 = new StreamReader(bookdb);
            StreamReader sReader2 = new StreamReader(inventorydb);
            StreamReader sReader3 = new StreamReader(authordb);
            listViewItems.Items.Clear();
            string line1 = sReader1.ReadLine();
            string line2 = sReader2.ReadLine();
            string line3 = sReader3.ReadLine();

            while (line1 != null && line2 != null && line3 != null)
            {
                string[] fields1 = line1.Split(',');
                string[] fields2 = line2.Split(',');
                string[] fields3 = line3.Split(',');
                ListViewItem item = new ListViewItem(fields1[1]);
                item.SubItems.Add(fields1[3]);
                item.SubItems.Add(fields2[3]);
                item.SubItems.Add(fields3[1]);
                item.SubItems.Add(fields2[2]);
                listViewItems.Items.Add(item);
                line1 = sReader1.ReadLine();
                line2 = sReader2.ReadLine();
                line3 = sReader3.ReadLine();
            }
            sReader1.Close();         
            sReader2.Close();
            sReader3.Close();
        }

        public static void addEmployee(Employee emp)
        {
            StreamWriter sWriter = new StreamWriter(authdb, true);
            sWriter.WriteLine(emp.FirstName + "," + emp.LastName + "," + emp.EmployeeId + "," + emp.Password + "," + emp.Role + "," + emp.PhoneNumber);
            sWriter.Close();
            MessageBox.Show("Employee Data has been saved.");
        }

        public static void addClient(Client cl)
        {
            StreamWriter sWriter = new StreamWriter(clientdb, true);
            sWriter.WriteLine(cl.ClientName + "," + cl.ClientStreet + "," + cl.ClientCity + "," + cl.ClientPostalcode + "," + cl.ClientFaxNumber + "," +cl.ClientCreditLimit + "," + cl.ClientPhoneNumber);
            sWriter.Close();
            MessageBox.Show("Client Data has been saved.");
        }

        public static void ListClients(ListView listViewItems)
        {
            StreamReader sReader = new StreamReader(clientdb);
            listViewItems.Items.Clear();
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                item.SubItems.Add(fields[5]);
                item.SubItems.Add(fields[6]);
                listViewItems.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        public static void ListOrders(ListView listViewItems)
        {
            StreamReader sReader = new StreamReader(orderdb);
            listViewItems.Items.Clear();
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[5]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[3]);
                listViewItems.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }
        public static Boolean SearchEmployee(String empId , ListView listViewItems)
        {
            StreamReader sReader = new StreamReader(authdb);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                if (empId == fields[0])
                {
                    listViewItems.Items.Clear();
                    ListViewItem item = new ListViewItem(fields[0]);
                    item.SubItems.Add(fields[1]);
                    item.SubItems.Add(fields[5]);
                    item.SubItems.Add(fields[4]);
                    listViewItems.Items.Add(item);
                    sReader.Close();
                    return true;
                }
                else
                {
                    line = sReader.ReadLine();
                }               
            }
            sReader.Close();
            return false;
        }

        public static Boolean SearchBook(String bookName, ListView listViewItems)
        {
            StreamReader sReader = new StreamReader(bookdb);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
               
                if (bookName.ToLower() == fields[1].ToLower())
                {
                    string ISBN = fields[0].ToLower();
                    StreamReader sReader1 = new StreamReader(inventorydb);
                    string line2 = sReader1.ReadLine();
                    listViewItems.Items.Clear();
                    string QOH = " ";
                    while (line2 != null)
                    {
                        string[] fields1 = line.Split(',');
                        if(ISBN == fields1[0].ToLower())
                        {
                            QOH = fields1[3];
                            sReader1.Close();
                        }
                        line2 = sReader.ReadLine();
                    }
                    MessageBox.Show("book " + bookName + " is available in inventory :" + QOH.ToString() + ".");
                    sReader.Close();
                    sReader1.Close();
                    return true;
                }
                else
                {
                    line = sReader.ReadLine();
                }
            }
            sReader.Close();
            return false;
        }

        public static Boolean SearchClient(String clientName, ListView listViewItems)
        {
            StreamReader sReader = new StreamReader(clientdb);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                if (clientName.ToLower() == fields[0].ToLower())
                {
                    listViewItems.Items.Clear();
                    ListViewItem item = new ListViewItem(fields[0]);
                    item.SubItems.Add(fields[1]);
                    item.SubItems.Add(fields[2]); 
                    item.SubItems.Add(fields[3]);
                    item.SubItems.Add(fields[4]);
                    item.SubItems.Add(fields[5]);
                    item.SubItems.Add(fields[6]);
                    listViewItems.Items.Add(item);
                    sReader.Close();
                    return true;
                }
                else
                {
                    line = sReader.ReadLine();
                }
            }
            sReader.Close();
            return false;
        }

        private static string getLatestAuthorId()
        {
            StreamReader f = new StreamReader(authordb);
            string lastline = "";
            string temp;
            while ((temp = f.ReadLine()) != null)
            {
                lastline = temp;
            }
            if (String.IsNullOrEmpty(lastline))
            {
                f.Close();
                return "1";
            }
            else
            {
                f.Close();
                string[] fields = lastline.Split(',');
                int id = Convert.ToInt32(fields[0]);
                string latestId = (id + 1).ToString();
                return latestId;
            }
        }

        private static string getLatestOrderId()
        {
            StreamReader f = new StreamReader(orderdb);
            string lastline = "";
            string temp;
            while ((temp = f.ReadLine()) != null)
            {
                lastline = temp;
            }
            if (String.IsNullOrEmpty(lastline))
            {
                f.Close();
                return "1";
            }
            else
            {
                f.Close();
                string[] fields = lastline.Split(',');
                int id = Convert.ToInt32(fields[0]);
                string latestId = (id + 1).ToString();
                return latestId;
            }
        }

        private static string getLatestPublisherId()
        {

            StreamReader f = new StreamReader(inventorydb);
            string lastline = "";
            string temp;
            while ((temp = f.ReadLine()) != null)
            {
                lastline = temp;
            }
            if (String.IsNullOrEmpty(lastline))
            {
                f.Close();
                return "1";
            }
            else
            {
                f.Close();
                string[] fields = lastline.Split(',');
                int id = Convert.ToInt32(fields[1]);
                string latestId = (id + 1).ToString();
                return latestId;
            }
        }
        public static void addItemToInventory(Inventory item ,Author auth , Book bk)
        {
            

            string generateAuthId = getLatestAuthorId();
            string generatePubId = getLatestPublisherId();

            StreamWriter bkWriter = new StreamWriter(bookdb, true);
            StreamWriter itemWriter = new StreamWriter(inventorydb, true);
            StreamWriter authWriter = new StreamWriter(authordb, true);

            bkWriter.WriteLine(bk.ISBN + "," + bk.Title + "," + bk.Category + "," + bk.UnitPrice + "," + bk.PublicationYear +"," + generateAuthId);
            itemWriter.WriteLine(bk.ISBN + "," + generatePubId + "," + item.PublisherName + "," + item.QOH);
            authWriter.WriteLine(generateAuthId + "," + auth.AuthorFname + "," + auth.AuthorLname + "," + auth.AuthorEmail);

            bkWriter.Close();
            itemWriter.Close();
            authWriter.Close();
            MessageBox.Show("Book Data has been saved.");
        }

        public static void placeOrder(Orders item)
        {
            string generateOrderId = getLatestOrderId();
            StreamWriter itemWriter = new StreamWriter(orderdb, true);
            itemWriter.WriteLine(generateOrderId + "," + item.BookName + "," + item.ClientName + "," + item.Quantity + "," + item.TakenVia + "," + item.Date);
            itemWriter.Close();
            MessageBox.Show("Order Has Been Placed.");
        }

        public static void getClients(ComboBox item)
        {
            StreamReader sReader = new StreamReader(clientdb);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                item.Items.Add(fields[0]);
                line = sReader.ReadLine();
            }
        }
        public static void getBooks(ComboBox item)
        {
            StreamReader sReader = new StreamReader(bookdb);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                item.Items.Add(fields[1]);
                line = sReader.ReadLine();
            }
        }

        public static Boolean searchOrder(String book, String client , ListView listViewItems)
        {
            StreamReader sReader = new StreamReader(orderdb);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                if (book == fields[1] && client == fields[2])
                {
                    listViewItems.Items.Clear();
                    ListViewItem item = new ListViewItem(fields[5]);
                    item.SubItems.Add(fields[2]);
                    item.SubItems.Add(fields[1]);
                    item.SubItems.Add(fields[3]);
                    listViewItems.Items.Add(item);
                    sReader.Close();
                    return true;
                }
                else
                {
                    line = sReader.ReadLine();
                }
            }
            sReader.Close();
            return false;
        }

        public static Boolean CancelOrder(String book, String client)
        {
            StreamReader sReader = new StreamReader(orderdb);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(temp, true);
            while (line != null)
            {
                string[] fields = line.Split(',');
                if (book != fields[1] && client != fields[2])
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] +","+ fields[4] + "," + fields[5]);
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            sWriter.Close();
            File.Delete(orderdb);
            File.Move(temp, orderdb);
            return true;
        }

    }
}
