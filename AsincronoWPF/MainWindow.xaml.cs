using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsincronoWPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r;
        int sorteggiato1;
        int sorteggiato2;

        readonly Uri uriDado1 = new Uri("dado-1.jpg", UriKind.Relative);
        readonly Uri uriDado2 = new Uri("dado-2.jpg", UriKind.Relative);
        readonly Uri uriDado3 = new Uri("dado-3.png", UriKind.Relative);
        readonly Uri uriDado4 = new Uri("dado-4.png", UriKind.Relative);
        readonly Uri uriDado5 = new Uri("dado-5.png", UriKind.Relative);
        readonly Uri uriDado6 = new Uri("dado-6.png", UriKind.Relative);

        ImageSource dado1;
        ImageSource dado2;
        ImageSource dado3;
        ImageSource dado4;
        ImageSource dado5;
        ImageSource dado6;

        public MainWindow()
        {
            InitializeComponent();

            dado1 = new BitmapImage(uriDado1);
            dado2 = new BitmapImage(uriDado2);
            dado3 = new BitmapImage(uriDado3);
            dado4 = new BitmapImage(uriDado4);
            dado5 = new BitmapImage(uriDado5);
            dado6 = new BitmapImage(uriDado6);

            r = new Random();

            Sorteggio();
        }

        private async void Sorteggio()
        {
            await Task.Run(() =>
            {
                for (;;)
                {
                    sorteggiato1 = r.Next(1, 7);
                    sorteggiato2 = r.Next(1, 7);
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        switch (sorteggiato1)
                        {
                            case 1:
                                imgDadoN1.Source = dado1;
                                break;
                            case 2:
                                imgDadoN1.Source = dado2;
                                break;
                            case 3:
                                imgDadoN1.Source = dado3;
                                break;
                            case 4:
                                imgDadoN1.Source = dado4;
                                break;
                            case 5:
                                imgDadoN1.Source = dado5;
                                break;
                            case 6:
                                imgDadoN1.Source = dado6;
                                break;
                        }

                        switch (sorteggiato2)
                        {
                            case 1:
                                imgDadoN2.Source = dado1;
                                break;
                            case 2:
                                imgDadoN2.Source = dado2;
                                break;
                            case 3:
                                imgDadoN2.Source = dado3;
                                break;
                            case 4:
                                imgDadoN2.Source = dado4;
                                break;
                            case 5:
                                imgDadoN2.Source = dado5;
                                break;
                            case 6:
                                imgDadoN2.Source = dado6;
                                break;
                        }
                    }));
                    Thread.Sleep(200);
                }
            });
        }

        private void btnSorteggia_Click(object sender, RoutedEventArgs e)
        {
            int somma = sorteggiato1 + sorteggiato2;
            MessageBox.Show(somma.ToString());
        }
    }
}
