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
using System.Windows.Shapes;

namespace paper_io
{
    /// <summary>
    /// Логика взаимодействия для Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        Game game;

        public Start()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte n;
            bool success = byte.TryParse(Gamers.Text, out n);
            if (success)
            {
                if (n <= 1)
                {
                    Error.Content = "Слишком мало";
                }
                if (n > 10)
                {
                    Error.Content = "Слишком много";
                }
                else
                {
                    game = new Game(n);
                }
            }
            else
            {
                Error.Content = "Должно быть положительное число";
            }
        }
    }
}
