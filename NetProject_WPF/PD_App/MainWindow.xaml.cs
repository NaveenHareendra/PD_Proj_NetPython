using System;
using System.Collections.Generic;
using System.Diagnostics;
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


namespace PD_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Record_Button_Click(object sender, RoutedEventArgs e)
        {
            Class1 class1 = new Class1();
            MainLabel.Content = "Started";

            class1.recordManipulation();


        }

        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            Class1 class1 = new Class1();

            var nhrValue = class1.recordManipulationStop();

            MainLabel.Content = "record Stopped, NHR Val: "+ nhrValue.ToString();


        }

        private void Play_Button_Click(Object sender, RoutedEventArgs e)
        {
            /*            ms = 0;
                        h = 0;
                        s = 0;
                        m = 0;
                        timer1.Enabled = false;
                        lblhur.Text = "00";
                        lblmin.Text = "00";
                        lblsecond.Text = "00";
                        (new Microsoft.VisualBasic.Devices.Audio()).Play("d:\\mic.wav");*/
        }
    }
}
