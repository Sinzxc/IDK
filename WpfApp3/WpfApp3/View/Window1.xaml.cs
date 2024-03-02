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
using WpfApp3.Model;
using WpfApp3.ViewModel;

namespace WpfApp3.View
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User user = (sender as ListView).SelectedItem as User;
            if (user!=null)
            {
                Window2 window2 = new Window2(user);
                window2.ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as Window1ViewModel).SortByUsername();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (DataContext as Window1ViewModel).SortByPassword();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            (DataContext as Window1ViewModel).UpdateList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            (DataContext as Window1ViewModel).SearchByUsername(searchTB.Text);
        }
    }
}
