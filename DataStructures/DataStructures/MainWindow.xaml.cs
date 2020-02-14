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

namespace DataStructures
{
    struct Fred // record
    {
        int age;
        string name;
        List<string> interests;
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Brush b = new SolidColorBrush(Colors.HotPink);
            AMainWindow.Background = b;

            Biscuit biscuit = new Biscuit("Arnotts", true);
            //biscuit.Brand = "Arnotts";
            biscuit.HasChocolate = true;
            //biscuit.IsSweet = true;

            bool isForBrunch = biscuit.SuitableForBrunch();
            MessageBox.Show(isForBrunch.ToString());

            Dictionary<string, Biscuit> biscuits = new Dictionary<string, Biscuit>();
            biscuits.Add("vovo", new Biscuit("Arnotts", true));
            biscuits.Add("timtam", new Biscuit("Arnotts", true));
            biscuits.Add("ritz", new Biscuit("Arnotts", false));
            biscuits.Add("ripoff", new Biscuit("Aldi", true));

            string s = String.Empty;
            foreach (var item in biscuits)
            {
                s += item.Key + ": " + item.Value + ", ";
            }
            MessageBox.Show(s);

            // Might work
            string concat = String.Join(", ", biscuits);
            MessageBox.Show(concat);
        }
    }
}
