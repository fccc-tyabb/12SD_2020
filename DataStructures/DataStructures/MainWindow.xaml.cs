using DataStructures.Classes;
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
using System.Xml.Linq;

namespace DataStructures
{

    public partial class MainWindow : Window
    {
        Dictionary<string, Biscuit> biscuits = new Dictionary<string, Biscuit>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MakeBiscuitsButton_Click(object sender, RoutedEventArgs e)
        {
            biscuits = new Dictionary<string, Biscuit>();

            biscuits.Add("vovo", new Biscuit("Arnotts", true, "Vovo"));
            biscuits.Add("timtam", new Biscuit("Arnotts", true, "TimTam"));
            biscuits.Add("ritz", new Biscuit("Arnotts", false, "Ritz"));
            biscuits.Add("ripoff", new Biscuit("Aldi", true, "TrueSweet"));

            //string s = String.Empty;
            //foreach (var item in biscuits)
            //{
            //    s += item.Key + ": " + item.Value + ", ";
            //}
            //MessageBox.Show(s);

            //// Might work
            //string concat = String.Join(", ", biscuits);
            //MessageBox.Show(concat);

            BiscuitListBox.ItemsSource = biscuits;
        }

        private void SerialiseBiscuits_Click(object sender, RoutedEventArgs e)
        {
            XDocument xDoc = new XDocument();
            XElement xBiscuits = new XElement("biscuits");
            xDoc.Add(xBiscuits);
            foreach(string s in biscuits.Keys)
            {
                xBiscuits.Add(new XElement("biscuit", s));
            }
            xDoc.Save(@"C:\Temp\biscuits.xml");
        }
    }
}
