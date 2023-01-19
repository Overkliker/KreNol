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
        List<(int, int, int)> allWins = new List<(int, int, int)> { (0, 1, 2), (3, 4, 5), (6, 7, 8), (0, 3, 6), (2, 5, 8), (0, 4, 8), (2, 4, 6) };
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

            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    if (((Button)el).Name != "bEnd")
                    {
                        ((Button)el).Content = "";
                    }

                }
            }

            if (thisGame == 0)
            {
                thisGame = 1;

                bot_Going("X");
                isGoing = true;
            }
            else
            {
                thisGame = 0;
                isGoing = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("asd");
            if (isGoing)
            {
                if (thisGame == 0)
                {
                    ((Button)e.OriginalSource).Content = "X";
                    isGoing = !isGoing;

                    if (Is_Win("X") == 0)
                    {
                        MessageBox.Show("Крестики победили");
                    }

                    else if (Is_Win("X") == 1)
                    {
                        //В этом цикле бот ставит свой значёк на повторяющуюся клетку
                        bot_Going("0");
                        if (Is_Win("0") == 0)
                        {
                            MessageBox.Show("Нолики победили");
                        }

                        else if (Is_Win("0") == 1)
                        {
                            isGoing = true;
                        }
                    }
                }
                else if (thisGame == 1)
                {
                    ((Button)e.OriginalSource).Content = "0";
                    isGoing = !isGoing;

                    if (Is_Win("0") == 0)
                    {
                        MessageBox.Show("Нолики победили");
                    }

                    else if (Is_Win("0") == 1)
                    {
                        //В этом цикле бот ставит свой значёк на случайную пустую клетку
                        bot_Going("X");
                        if (Is_Win("X") == 0)
                        {
                            MessageBox.Show("Крестики победили");
                        }

                        else if (Is_Win("X") == 1)
                        {
                            isGoing = true;
                        }
                    }
                }
            }

        }

        public int Is_Win(string symbol)
        {
            List<string> desk = new List<string> { };

            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    if (((Button)el).Name != "bEnd")
                    {
                        Debug.WriteLine((string)((Button)el).Content);
                        desk.Add((string)((Button)el).Content);
                    }

                }
            }

            if (symbol == "X")
            {
                if ((desk[0] == "X" && desk[1] == "X" && desk[2] == "X")) return 0;
                if ((desk[3] == "X" && desk[4] == "X" && desk[5] == "X")) return 0;
                if ((desk[6] == "X" && desk[7] == "X" && desk[8] == "X")) return 0;


                if ((desk[0] == "X" && desk[3] == "X" && desk[6] == "X")) return 0;
                if ((desk[2] == "X" && desk[4] == "X" && desk[7] == "X")) return 0;
                if ((desk[2] == "X" && desk[5] == "X" && desk[8] == "X")) return 0;

                if ((desk[0] == "X" && desk[4] == "X" && desk[8] == "X")) return 0;
                if ((desk[6] == "X" && desk[4] == "X" && desk[2] == "X")) return 0;

                else return 1;

            }

            else if (symbol == "0")
            {
                if ((desk[0] == "0" && desk[1] == "0" && desk[2] == "0")) return 0;
                if ((desk[3] == "0" && desk[4] == "0" && desk[5] == "0")) return 0;
                if ((desk[6] == "0" && desk[7] == "0" && desk[8] == "0")) return 0;


                if ((desk[0] == "0" && desk[3] == "0" && desk[6] == "0")) return 0;
                if ((desk[1] == "0" && desk[4] == "0" && desk[7] == "0")) return 0;
                if ((desk[2] == "0" && desk[5] == "0" && desk[8] == "0")) return 0;

                if ((desk[0] == "0" && desk[4] == "0" && desk[8] == "0")) return 0;
                if ((desk[6] == "0" && desk[4] == "0" && desk[2] == "0")) return 0;

                else return 1;
            }
            
            else
            {
                return 3;
            }
        }

        public void bot_Going(string znak)
        {
            List<Button> desk = new List<Button> { };
            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    if (((Button)el).Name != "bEnd")
                    {
                        desk.Add((Button)el);
                    }

                }
            }
            Random rnd = new Random();
            Button bot = desk[rnd.Next(0, 8)];

            while (bot.Content == "0" || bot.Content == "X")
            {
                bot = desk[rnd.Next(0, 8)];
            }

            bot.Content = znak;
        }
    }
}
