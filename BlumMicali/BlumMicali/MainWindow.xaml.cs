using System.Linq;
using System.Windows;
using BlumMicali.Save;
using System.Numerics;
using BlumMicali.Generator;
using System.Windows.Controls;
using System.Collections.Generic;

namespace BlumMicali
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            BigInteger primitiveRoot = BigInteger.Parse(
                "3089014570559104071319006923413060128665200110584708220833159771123973154612557115837845252375278703");
            BigInteger mod = BigInteger.Parse(
                "3089014570559104071319006923413060128665200110584708220833159771123973154612557115837845252375278767");
            BigInteger seed = BigInteger.Parse(
                "35707516168479785771797981373542410151981709510147");

            BlumMicaliGenerator gen = new BlumMicaliGenerator(seed, primitiveRoot, mod);

            List<byte> data = gen.GetRandomNumbers(int.Parse(CountTB.Text));
            NumbersTB.Text = string.Join("\n", data.Select(s => s.ToString()).ToArray());
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile saver = new SaveToFile();
            saver.SaveFile(NumbersTB.Text);
        }

        private void CountTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!CountTB.Text.Equals(string.Empty))
                GenerateBtn.IsEnabled = true;
            else
                GenerateBtn.IsEnabled = false;
        }

        private void NumbersTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!NumbersTB.Text.Equals(string.Empty))
                SaveBtn.IsEnabled = true;
            else
                SaveBtn.IsEnabled = false;
        }
    }
}
