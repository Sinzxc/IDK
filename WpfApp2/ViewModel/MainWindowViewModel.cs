using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Model;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    public class MainWindowViewModel :BaseViewModel
    {
        ObservableCollection<User> users=new ObservableCollection<User>();

        public ObservableCollection<User> Users
        {
            get => users;
            set { users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public MainWindowViewModel()
        {
           UpdateUserList();
        }

        void UpdateUserList() 
        {
            using (factoryEntities db = new factoryEntities())
            {
                Users.Clear();
                foreach (var item in db.User.ToList())
                {
                    Users.Add(item);
                }
            }
        }
        public RelayCommand OrderByName
        {
            get 
            {
                using(factoryEntities db = new factoryEntities())
                {
                    return new RelayCommand(obj =>
                    {
                        List<User> users = new List<User>();
                        foreach (var item in Users.OrderBy(e=>e.Name))
                        {
                              users.Add(item);
                        }
                        Users.Clear();
                        foreach (var item in users)
                        {
                            Users.Add(item);
                        }
                    }
                );
                }
            }
        }
        public RelayCommand Search
        {
            get
            {
                
                    return new RelayCommand(obj =>
                    {
                        MainWindow g = (MainWindow)Application.Current.MainWindow;
                        Users.Clear();
                        using (factoryEntities db = new factoryEntities())
                        {
                            foreach (var item in db.User.Where(e=>e.Name.ToLower().Contains(g.tb1.Text.ToString().ToLower())))
                            {
                                Users.Add(item);
                            }
                        }
                    }
                );
                
            }
        }
        public RelayCommand GetDefault
        {
            get
            {

                return new RelayCommand(obj =>
                {
                    Users.Clear();
                    using (factoryEntities db = new factoryEntities())
                    {
                        foreach (var item in db.User)
                        {
                            Users.Add(item);
                        }
                    }
                }
            );

            }
        }

    }
}
