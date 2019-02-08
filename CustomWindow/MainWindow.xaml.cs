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

namespace CustomWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private double _currentWindowTop    = 0f;
        private double _currentWindowLeft   = 0f;
        private double _currentWindowWidth  = 0f;
        private double _currentWindowHeight = 0f;

        private string _currentWindowState  = "Normal";

        private double _screenWidth         = 0f;
        private double _screenHeight        = 0f;
        private double _fullScreenWidth     = 0f;
        private double _fullScreenHeight    = 0f;

        /**
         * The whole point of "overriding" the standard window TitleBar is
         * so you can style it in a way that fits into your application theme.
         * 
         * The downside is, of course, that will have to implement the functionality again and on your own!
         */
        public MainWindow()
        {

            InitializeComponent();

            _currentWindowWidth     = Application.Current.MainWindow.Width;
            _currentWindowHeight    = Application.Current.MainWindow.Height;

            // In my case: 1980x1017 - is this "minus the task bar"? Not sure why but this should actually be ~1980x1020-ish
            _screenWidth            = SystemParameters.FullPrimaryScreenWidth;
            _screenHeight           = SystemParameters.FullPrimaryScreenHeight;
            _fullScreenWidth        = SystemParameters.VirtualScreenWidth;
            _fullScreenHeight       = SystemParameters.VirtualScreenHeight;

            // Update these values when the window is being moved or resized manually!
            _currentWindowTop       = ((_fullScreenHeight - _currentWindowHeight) / 2);
            _currentWindowLeft      = ((_fullScreenWidth - _currentWindowWidth) / 2);

        }

        private void HandleClick_BtnMinimze(object sender, RoutedEventArgs e)
        {

            this.WindowState = WindowState.Minimized;

        }

        private void HandleClick_BtnMaximize(object sender, RoutedEventArgs e)
        {

            // this.WindowState = (this.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;



            /* @todo When   WindowStyle="None"      maximizing will resutlt in a proper fullscreen!
             * But for most of the time it is wanted to show "fullscreen with task bar" when maximizing.
             * So: How do you get the current system's screen resolution + the taskbar width and height
             * (and actually also the position since BOTTOM is just the default position!)
             */

            _currentWindowState = ( _currentWindowState == "Normal" ? "Maximized" : "Normal" );

            if( _currentWindowState == "Normal" )
            {
                Application.Current.MainWindow.Top      = _currentWindowTop;
                Application.Current.MainWindow.Left     = _currentWindowLeft;
                Application.Current.MainWindow.Width    = _currentWindowWidth;
                Application.Current.MainWindow.Height   = _currentWindowHeight;
            }
            else if( _currentWindowState == "Maximized" )
            {
                Application.Current.MainWindow.Top      = 0;
                Application.Current.MainWindow.Left     = 0;
                Application.Current.MainWindow.Width    = _screenWidth;
                Application.Current.MainWindow.Height   = _screenHeight;
            }

        }

        private void HandleClick_BtnClose( object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();

        }

        // @todo How do you trigger this??
        private void OnApplicationExit( object sender, EventArgs e )
        {
            // This still allows you to propertly shut down your own processes.
            MessageBox.Show("Goodbye");
        }

    }
}
