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

namespace WpfTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> ints = new List<int>();
        DispatcherTimer timer = new DispatcherTimer();
        TimeSpan target;
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            for (int i = 0; i < 60; i++)
            {
                ints.Add(i);
            }
            cbHours.ItemsSource = ints;
            cbHours.SelectedIndex = 0;
            cbMins.ItemsSource = ints;
            cbMins.SelectedIndex = 0;
            cbSec.ItemsSource = ints;
            cbSec.SelectedIndex = 0;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            target -= new TimeSpan(0, 0, 1);
            tbTime.Text = (target).ToString();

            if(target == TimeSpan.Zero)
            {
                MessageBox.Show("Время вышло");
                timer.Stop();
            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            target = new TimeSpan(cbHours.SelectedIndex, cbMins.SelectedIndex, cbSec.SelectedIndex);
            tbTime.Text = (target).ToString();
            timer.Start();
        }
    }
}
