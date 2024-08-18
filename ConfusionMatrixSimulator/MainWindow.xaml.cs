using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ConfusionMatrixSimulator
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


        private void ConfusionGridElement_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Check if the input is a digit
            if (!IsTextAllowed(e.Text))
            {
                e.Handled = true; // Ignore the input
            }
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[0-9]+"); // Regex to allow digits only
            return regex.IsMatch(text);
        }
    }
}
