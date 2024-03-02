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
using WpfApp3.Model;

namespace WpfApp3.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (factoryEntities db = new factoryEntities())
            { 
                if (db.User.FirstOrDefault(u=>u.Username==loginTB.Text&&u.Password==PassTB.Password)!=null) {
                    this.Hide();
                    Window1 window1 = new Window1();
                    window1.Show();
                }
                else
                {
                    MessageBox.Show("Отказано в доступе","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                }

            }
        }
    }
}
