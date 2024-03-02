using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Model;

namespace WpfApp3.ViewModel
{
    internal class Window1ViewModel:BaseViewModel
    {
        public Window1ViewModel() { 
			UpdateList();
		}
		private ObservableCollection<User> users=new ObservableCollection<User>();

		public ObservableCollection<User> Users
        {
			get { return users; }
			set { users = value; OnPropertyChanged(nameof(Roll)); }
		}

		public void UpdateList() {
			using (factoryEntities db = new factoryEntities())
			{
                Users.Clear();
                foreach (var user in db.User)
                {
					Users.Add(user);
                }
            }
		}

		public void SortByUsername() {
            using (factoryEntities db = new factoryEntities())
            {
                Users.Clear();
                foreach (var user in db.User.OrderBy(e=>e.Username))
                {
                    Users.Add(user);
                }
            }
        }
        public void SortByPassword()
        {
            using (factoryEntities db = new factoryEntities())
            {
                Users.Clear();
                foreach (var user in db.User.OrderBy(e => e.Password))
                {
                    Users.Add(user);
                }
            }
        }
        public void SearchByUsername(string input) {
            using (factoryEntities db = new factoryEntities())
            {
                Users.Clear();
                foreach (var user in db.User.Where(u => u.Username.Contains(input)))
                {
                    Users.Add(user);
                }
            }
        }

    }
}
