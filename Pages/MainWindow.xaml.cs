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
using System.IO;

namespace Pages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTab_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = new TabItem();
            tabItem.Name = "NewTab";
            tabItem.Header = "New Tab";
            tcFile.Items.Add(tabItem);
        }

        private void readTextFile()
        {
            string text = System.IO.File.ReadAllText(@"C:\Exports\WEEKINVCNT.TXT");
            txtBox1.Text = text;

        }

        private void miOpen_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void miOpen_Click(object sender, RoutedEventArgs e)
        {
            //readTextFile();
            openTestFile();
        }

        private void openTestFile()
        {
            FileInfo fileInfo = new FileInfo(@"C:\Exports\WEEKINVCNT.TXT");

            TabItem tabItem = new TabItem();
            Grid grid = null;
            TextBox textBox = null;

            try
            {
                //Creating the textBox
                textBox = new TextBox();
                textBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                textBox.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;

                //Creating the Grid (can also do a canvas, stack panal or other panel here)
                grid = new Grid();
                grid.Children.Add(textBox);

                tabItem = new TabItem();
                //tabItem.Name = "NewTab";
                tabItem.Header = fileInfo.Name;
                tabItem.Content = grid;

                tcFile.Items.Add(tabItem);
                tcFile.SelectedItem = tabItem;

                textBox.Text = System.IO.File.ReadAllText(fileInfo.FullName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                textBox = null;
                grid = null;
                tabItem = null;
            }

        }

        private void tcFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tabItem = tcFile.SelectedItem as TabItem;
            sbiFile.Content = tabItem.Header;
        }



        //private void tcFile_Selected(object sender, RoutedEventArgs e)
        //{
        //    //int test = tcFile.SelectedIndex;
        //    //MessageBox.Show("EMPTY");
        //}
    }
}
