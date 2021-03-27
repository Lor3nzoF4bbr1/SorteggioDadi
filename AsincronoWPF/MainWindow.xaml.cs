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
        int sorteggiato;

        public MainWindow()
        {
            InitializeComponent();

            r = new Random();

            Sorteggio();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            ExecuteLongOp();
            MessageBox.Show("Operazione sincrona completata");
        }

        private async void ExecuteLongOp()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                }
            });
        }

        private async void Sorteggio()
        {
            await Task.Run(() =>
            {
                for (;;)
                {
                    sorteggiato = r.Next(1, 1001);
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        lblRandom.Content = sorteggiato;
                    }));
                    Thread.Sleep(100);
                }
            });
        }

        private void btnSorteggia_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(sorteggiato.ToString());
        }
    }
}
