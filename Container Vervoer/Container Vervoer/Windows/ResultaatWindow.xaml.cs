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
using Container_Vervoer.Classes;

namespace Container_Vervoer.Windows
{
    /// <summary>
    /// Interaction logic for ResultaatWindow.xaml
    /// </summary>
    public partial class ResultaatWindow : Window
    {
        LogicaSchip Logica;
        public ResultaatWindow(LogicaSchip logica)
        {
            InitializeComponent();
            this.Logica = logica;
            SorteerScherm_Load();
        }
        private void SorteerScherm_Load()
        {
            int boxWidth = 75;
            int boxHeight = 50;

            int waarde1 = 0;
            int waarde2 = 0;

            IReadOnlyList<Row> rijen = Logica.Schip.Rijen;
            foreach (Row rij in rijen)
            {
                StackPanel nieuweStack = new StackPanel
                {
                    Orientation = Orientation.Vertical
                };
                IReadOnlyList<ContainerStack> stapels = rij.ContainerStapels;
                foreach (ContainerStack stapel in stapels)
                {
                    Button nieuweStapel = new Button
                    {
                        Foreground = Brushes.Black,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Content = "Stapel: " + waarde1 + " x " + waarde2,
                        Width = boxWidth,
                        Height = boxHeight,
                    };
                    
                    nieuweStapel.Click += new RoutedEventHandler(LaatInfoZien);
                    nieuweStack.Children.Add(nieuweStapel);
                    waarde2++;
                }
                spResultaat.Children.Add(nieuweStack);
                waarde1++;
                waarde2 = 0;
            }
        }
        private void LaatInfoZien(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int x = int.Parse(button.Content.ToString().Substring(8, 2));
                int z = int.Parse(button.Content.ToString().Substring(12));

                Row rij = Logica.Schip.Rijen[x];
                ContainerStack stapel = rij.ContainerStapels[z];
                string textOutput = "";
                if(stapel.Stapel.Count == 0)
                {
                    textOutput += "Deze stapel is leeg.";
                }
                else
                {
                    foreach (Container containers in stapel.Stapel)
                    {
                        textOutput += containers.ToString() + "\n";
                    }
                }
                MessageBox.Show(textOutput, "Stapel: " + x + " - " + z);
            }
        }
    }
}
