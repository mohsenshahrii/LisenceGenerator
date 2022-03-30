using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LisenceGenerator
{
    //lmlknl
    //!!!!!!!!!!!!!!!!!!!!!!!!
    //------------------
    //++++++++++++++
    //comment on 3/30/2022
    /// <summary>
    
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dt = new DateTime();
                if (TxtReqCode.Text != "")
                {
                    if (ExpirationDate.Text != "")
                    {
                        //if (ExpirationDate.Text == "")
                        //    ExpirationDate.Text = dt.AddYears(1).ToString();
                        var Lic = TxtReqCode.Text + "aCkO" + ExpirationDate.Text + " 12:00:00 AM" + "aCkO" + DateTime.Today;
                        TxtLic.Text = RijndaelManagedEncryption.EncryptRijndael(Lic, "www.acko.co");
                    }
                    else
                        MessageBox.Show("The Date feild is empty");

                }
                else
                    MessageBox.Show("The req feild is empty");
            }
            catch (Exception)
            {

                throw;
            }
            //                                          "AAAA-BBBB-BCCE-FFFF-FFFF-0000-0246-6666-7778-8999aCkO9/13/2022 12:00:00 AMaCkO9/13/2021 12:00:00 AM"
            //RijndaelManagedEncryption.EncryptRijndael("AAAA-BBBB-BCCE-EFFF-FFFF-0000-0466-6667-7888-9999aCkO12/31/2021 12:00:00AMaCkO2/13/2021 12:00:00 AM", "www.acko.co");
            //RijndaelManagedEncryption.EncryptRijndael("AAAA-BBBB-BCCE-EFFF-FFFF-0000-0466-6667-7888-9999aCkO12/31/2021 12:00:00 AMaCkO2/13/2021 12:00:00 AM", "www.acko.co");

        }

        //this is test
        //test 2
        // test 5

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
