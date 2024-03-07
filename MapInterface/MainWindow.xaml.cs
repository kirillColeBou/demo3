using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        Timer timer;
        Canvas canvas = new Canvas();
        public MainWindow()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:5237/");
            timer = new Timer(3000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            GetPositions();
        }

        private async void GetPositions()
        {
            var result = await client.GetAsync(client.BaseAddress + "Values");
            var resultString = await result.Content.ReadAsStringAsync();

            var positions = JsonSerializer.Deserialize<List<PersonLocations>>(resultString);
            this.Dispatcher.Invoke(() =>
            {
                foreach (Grid item in row0.Children)
                {
                    item.Children.Clear();
                }
                foreach (Grid item in row1.Children)
                {
                    item.Children.Clear();
                }
                CreateUserUi(positions);
            });
            
        }

        void CreateUserUi(List<PersonLocations> persons)
        {
            foreach (var person in persons)
            {
                string role = person.personRole;


                if (person.lastSecurityPointDirection == "out")
                    continue;

                Ellipse elipse = new Ellipse();
                elipse.Height = 10; elipse.Width = 10;
                Grid grid = new Grid();

                #region gridTake
                if (person.lastSecurityPointNumber is 0)
                    grid = skud0;
                else if (person.lastSecurityPointNumber is 1)
                    grid = skud1;
                else if (person.lastSecurityPointNumber is 2)
                    grid = skud2;
                else if (person.lastSecurityPointNumber is 3)
                    grid = skud3;
                else if (person.lastSecurityPointNumber is 4)
                    grid = skud4;
                else if (person.lastSecurityPointNumber is 5)
                    grid = skud5;
                else if (person.lastSecurityPointNumber is 6)
                    grid = skud6;
                else if (person.lastSecurityPointNumber is 7)
                    grid = skud7;
                else if (person.lastSecurityPointNumber is 8)
                    grid = skud8;
                else if (person.lastSecurityPointNumber is 9)
                    grid = skud9;
                else if (person.lastSecurityPointNumber is 10)
                    grid = skud10;
                else if (person.lastSecurityPointNumber is 11)
                    grid = skud11;
                else if (person.lastSecurityPointNumber is 12)
                    grid = skud12;
                else if (person.lastSecurityPointNumber is 13)
                    grid = skud13;
                else if (person.lastSecurityPointNumber is 14)
                    grid = skud14;
                else if (person.lastSecurityPointNumber is 15)
                    grid = skud15;
                else if (person.lastSecurityPointNumber is 16)
                    grid = skud16;
                else if (person.lastSecurityPointNumber is 17)
                    grid = skud17;
                else if (person.lastSecurityPointNumber is 18)
                    grid = skud18;
                else if (person.lastSecurityPointNumber is 19)
                    grid = skud19;
                else if (person.lastSecurityPointNumber is 20)
                    grid = skud20;
                else if (person.lastSecurityPointNumber is 21)
                    grid = skud21;
                else if (person.lastSecurityPointNumber is 22)
                    grid = skud22;
                #endregion

                double xpos = 10;
                double ypos = 10;

                if (grid.Children.Count!=0)
                {
                    Ellipse lastChild = grid.Children[grid.Children.Count-1] as Ellipse;

                    xpos = lastChild.Margin.Left + lastChild.Width + 5;

                    if (xpos>grid.Width)
                    {
                        xpos = 10;
                        ypos = lastChild.Margin.Top + lastChild.Height + 5;
                    }
                }

                elipse.Margin = new Thickness(xpos, ypos, 0, 0);
                elipse.VerticalAlignment = VerticalAlignment.Center;
                elipse.HorizontalAlignment = HorizontalAlignment.Left;


                if (person.personRole == "Клиент")
                {
                    elipse.Fill = Brushes.Green;
                }
                else if (person.personRole == "Сотрудник")
                {
                    elipse.Fill = Brushes.Blue;
                }

                grid.Children.Add(elipse);
            }

        }
    }
}