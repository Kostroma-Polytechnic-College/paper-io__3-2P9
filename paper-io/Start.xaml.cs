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
        public Start()
        {
            InitializeComponent();
        }
        /// <summary>
        /// При нажатии на кнопку происходит проверка количества игроков, отправка количества игроков в класс Game и запуск окна с игрой Room
        /// </summary>
        /// <param name="sender">Предоставляет ссылку на кнопку</param>
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
                    /// используеться для перехода к окну с игрой и передачи количества игроков
                    Room room = new Room(n);
                    this.Hide();
                    room.ShowDialog();
                    this.Show();
                }
            }
            else
            { 
                Error.Content = "Введите число от 2 до 10";
            }
        }
    }
}
