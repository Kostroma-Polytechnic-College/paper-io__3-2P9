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
using System.Windows.Threading;

namespace paper_io
{
    /// <summary>
    /// Логика взаимодействия для Start.xaml
    /// </summary>
    public partial class Room : Window
    {
        enum Direction { left, right, up, down, none };
        double x = 0;
        double y = 0;
        public Room()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(MovePlayer);
            timer.Start();
        }
        private void MovePlayer(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Left))
            {
                x -= .05;
                Canvas.SetLeft(Player, x);
            }
            else if (Keyboard.IsKeyDown(Key.Up))
            {
                y -= .05;
                Canvas.SetTop(Player, y);
            }
            else if (Keyboard.IsKeyDown(Key.Down))
            {
                y += .05;
                Canvas.SetTop(Player, y);
            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                x += .05;
                Canvas.SetLeft(Player, x);
            }
        }
        #region IDK
        //private void MoveCamera(object sender, EventArgs e)
        //{
        //   if (Keyboard.IsKeyDown(Key.Left))
        //   {
        //       x -= .05;
        //       Canvas.SetLeft(CanvasViewer, x);
        //   }
        //   else if (Keyboard.IsKeyDown(Key.Up))
        //   {
        //      y -= .05;
        //       Canvas.SetTop(CanvasViewer, y);
        //   }
        //   else if (Keyboard.IsKeyDown(Key.Down))
        //   {
        //       y += .05;
        //       Canvas.SetTop(CanvasViewer, y);
        //   }
        //   else if (Keyboard.IsKeyDown(Key.Right))
        //   {
        //       x += .05;
        //       Canvas.SetLeft(CanvasViewer, x);
        //   }
        #endregion
    }
}

