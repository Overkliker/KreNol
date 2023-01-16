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
using System.Diagnostics;


namespace KreNol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool isGoing = true;
        public int thisGame = 0;
        List<(int, int, int)> allWins = new List<(int, int, int)> { (0, 1, 2), (3, 4, 5), (6, 7, 8), (0, 3, 6), (1, 4, 7), (2, 5, 8), (0, 4, 8), (2, 4, 6) };
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    if (((Button)el).Name == "bEnd")
                    {
                        ((Button)el).Click += New_Game;
                    }
                    else
                    {
                        ((Button)el).Click += Button_Click;
                    }
                    
                }
            }
        }

        private void New_Game(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("asd");
            if (isGoing)
            {
                if (thisGame == 0)
                {
                    ((Button)e.OriginalSource).Content = "X";
                    if (Is_Win("X") == false)
                    {
                        MessageBox.Show("Крестики победили");
                    }
                    else
                    {
                        Button botButt;
                    }
                }
                else if (thisGame == 1)
                {
                    ((Button)e.OriginalSource).Content = "0";
                }

                isGoing = !isGoing;
            } 
        }

        public bool Is_Win(string symbol)
        {
            List<string> desk = new List<string> { };

            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    if (((Button)el).Name != "bEnd")
                    {
                        desk.Add((string)((Button)el).Content);
                    }

                }
            }

            if (symbol == "X")
            {
                if ((desk[0] == "X" && desk[1] == "X" && desk[2] == "X")) return false;
                if ((desk[3] == "X" && desk[4] == "X" && desk[5] == "X")) return false;
                if ((desk[6] == "X" && desk[7] == "X" && desk[8] == "X")) return false;


                if ((desk[0] == "X" && desk[3] == "X" && desk[6] == "X")) return false;
                if ((desk[2] == "X" && desk[4] == "X" && desk[7] == "X")) return false;
                if ((desk[2] == "X" && desk[5] == "X" && desk[8] == "X")) return false;

                if ((desk[0] == "X" && desk[4] == "X" && desk[8] == "X")) return false;
                if ((desk[6] == "X" && desk[4] == "X" && desk[2] == "X")) return false;

                else return true;

            }

            else
            {
                if ((desk[0] == "O" && desk[1] == "O" && desk[2] == "O")) return false;
                if ((desk[3] == "O" && desk[4] == "O" && desk[5] == "O")) return false;
                if ((desk[6] == "O" && desk[7] == "O" && desk[8] == "O")) return false;


                if ((desk[0] == "O" && desk[3] == "O" && desk[6] == "O")) return false;
                if ((desk[1] == "O" && desk[4] == "O" && desk[7] == "O")) return false;
                if ((desk[2] == "O" && desk[5] == "O" && desk[8] == "O")) return false;

                if ((desk[0] == "O" && desk[4] == "O" && desk[8] == "O")) return false;
                if ((desk[6] == "O" && desk[4] == "O" && desk[2] == "O")) return false;

                else return true;
            }
            

        }

    }
}
