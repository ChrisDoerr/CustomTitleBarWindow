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

        /**
         * The whole point of "overriding" the standard window TitleBar is
         * so you can style it in a way that fits into your application theme.
         * 
         * The downside is, of course, that will have to implement the functionality again and on your own!
         */
        public MainWindow()
        {

            InitializeComponent();

        }

        private void HandleClick_BtnMinimze(object sender, RoutedEventArgs e)
        {

            this.WindowState = WindowState.Minimized;

        }

        private void HandleClick_BtnMaximize(object sender, RoutedEventArgs e)
        {

            this.WindowState = (this.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;

            /* @todo When   WindowStyle="None"      maximizing will resutlt in a proper fullscreen!
             * But for most of the time it is wanted to show "fullscreen with task bar" when maximizing.
             * So: How do you get the current system's screen resolution + the taskbar width and height
             * (and actually also the position since BOTTOM is just the default position!)
             */
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
