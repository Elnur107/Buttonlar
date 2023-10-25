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

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private List<Brush> colors = new List<Brush>
        {
            Brushes.Red,
            Brushes.Blue,
            Brushes.Green,
            Brushes.Yellow,
            Brushes.Purple,
            Brushes.Orange
        };
        private Dictionary<Button, int> buttonColorIndices = new Dictionary<Button, int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                if (!buttonColorIndices.ContainsKey(clickedButton))
                {
                    buttonColorIndices[clickedButton] = 0;
                }

                clickedButton.Background = colors[buttonColorIndices[clickedButton]];
                buttonColorIndices[clickedButton] = (buttonColorIndices[clickedButton] + 1) % colors.Count;
            }
        }

        private int rightClickCount = 0;
        private void Button_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            rightClickCount++;
            if (rightClickCount == 2)
            {
                Button clickedButton = sender as Button;
                if (clickedButton != null)
                {
                    clickedButton.Visibility = Visibility.Collapsed;
                }
                rightClickCount = 0;
            }
        }
    }
}
