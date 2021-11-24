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
        /// <summary>
        /// Используется для последующей передачи классу Game количества игроков
        /// </summary>
        Game game;
        /// <summary>
        /// Будет использоваться для перехода к окну с игрой
        /// </summary>
        Room room;
        public Start()
        {
            InitializeComponent();
        }
        /// <summary>
        /// При нажатии на кнопку происходит проверка количества игроков, отправка количества игроков в класс Game и запуск окна с игрой Room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte n;
            bool success = byte.TryParse(Gamers.Text, out n);
            if (success)
            {
                if (n <= 1 | n>10)
                {
                    Error.Content = "Введите число от 2 до 10";
                }
                else 
                {
                    game = new Game(n);
                    room = new Room();
                    room.Show();
                    window.WindowState = WindowState.Minimized;
                }
            }
            else
            { 
                Error.Content = "Введите число от 2 до 10";
            }
        }
    }
}
