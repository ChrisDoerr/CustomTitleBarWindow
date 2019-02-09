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

            _screenWidth            = SystemParameters.FullPrimaryScreenWidth;          // Not sure why, but MaximizedPrimaryScreenWidth seems slightly bigger than my actual resolution?!
            _screenHeight           = SystemParameters.MaximizedPrimaryScreenHeight;    // ...whereas the *Height value seems right (resoltuion/height - taskbar/height)
            _fullScreenWidth        = SystemParameters.VirtualScreenWidth;
            _fullScreenHeight       = SystemParameters.VirtualScreenHeight;

            // Update these values when the window is being moved or resized manually
            _currentWindowTop       = ((_fullScreenHeight - _currentWindowHeight) / 2);
            _currentWindowLeft      = ((_fullScreenWidth - _currentWindowWidth) / 2);

            /**
             * &#128469;    Minimize
             * &#128471;    Restore Down
             * &#128470;    Maximize
             * &#128473;    Close
             */

        }

        private void HandleClick_BtnMinimze(object sender, RoutedEventArgs e)
        {

            this.WindowState = WindowState.Minimized;

        }

        private void HandleClick_BtnMaximize(object sender, RoutedEventArgs e)
        {

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
