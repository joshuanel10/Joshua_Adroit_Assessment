using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
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

namespace Joshua_Adroit_Assessment
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool error = false;
            Object errorString = string.Empty;

            Interop.AdroitCOMLib.Adroit _adroit = new Interop.AdroitCOMLib.Adroit();

            _adroit.Connect("", "", ref error, ref errorString);

            if (error)
            {
                MessageBox.Show("Could not connect to Adroit Agent Server. Error: " + errorString.ToString());
            }
            else
            {
                MessageBox.Show("Connected to Adroit Agent Server");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool error = false;
            Object errorString = string.Empty;

            Interop.AdroitCOMLib.Adroit _adroit = new Interop.AdroitCOMLib.Adroit();

            _adroit.Disconnect(ref error, ref errorString);

            if (error)
            {
                MessageBox.Show("Could not disconnect from Adroit Agent Server. Error: " + errorString.ToString());
            } else
            {
                MessageBox.Show("Disconnected from Adroit Agent Server");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Object _errorString = string.Empty;
            bool _error = false;
            Object _returnObject = string.Empty;

            Interop.AdroitCOMLib.Adroit _adroit = new Interop.AdroitCOMLib.Adroit();

            _adroit.GetSlot("", "BAT-01-MIX-01-TEM", ref _returnObject,ref _error, ref _errorString);

            lblTagValue.Content = _returnObject;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            if (txtInput.Text == "")
            {
                MessageBox.Show("Please Enter A value");
            } else
            {
                Object _errorString = string.Empty;
                bool _error = false;

                Interop.AdroitCOMLib.Adroit _adroit = new Interop.AdroitCOMLib.Adroit();

                _adroit.PutSlot("", "BAT-01-MIX-01-TEM", txtInput.Text,ref _error,_errorString);

                lblTagValue.Content = txtInput.Text;
            }

            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            if (txtSub.Text == "")
            {
                MessageBox.Show("Please Enter A value");
            } else
            {
                Object _errorString = string.Empty;
                bool _error = false;
                String _SubIndexes = string.Empty;

                string value = txtSub.Text;

                Interop.AdroitCOMLib.Adroit _adroit = new Interop.AdroitCOMLib.Adroit();

                _adroit.SubscribeBulk(value, ref _SubIndexes, ref _error, ref _errorString);

                if (_error)
                {
                    MessageBox.Show("Could not subscribe " + _errorString.ToString());
                }
                else
                {
                    MessageBox.Show("Subscribed Successfully");
                }
            }
            
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

            if (txtUnSub.Text == "")
            {
                MessageBox.Show("Please Enter A value");
            } else
            {
                Object _errorString = string.Empty;
                bool _error = false;
                String _SubIndexes = string.Empty;
                string value = txtUnSub.Text;

                Interop.AdroitCOMLib.Adroit _adroit = new Interop.AdroitCOMLib.Adroit();

                _adroit.UnsubscribeBulk(value, ref _error, ref _errorString);

                if (_error)
                {
                    MessageBox.Show("Could not Unsubscribe " + _errorString.ToString());
                }
                else
                {
                    MessageBox.Show("Unsubscribed Successfully");
                }
            }

            
        }
    }
}
