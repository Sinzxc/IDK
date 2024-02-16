using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Model;

namespace WpfApp2.ViewModel
{
    public class MainWindowViewModel :BaseViewModel
    {
        ObservableCollection<Product> products=new ObservableCollection<Product>();

        public ObservableCollection<Product> Products
        {
            get => products;
            set { products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public MainWindowViewModel()
        {

            Products = new ObservableCollection<Product>
            {
                new Product()
                {
                    Id = 0,
                    Name = "Подушка с Путиным",
                    Description = "Лучшая подушка в мире",
                    Category = "Товары для дома"
                },
                new Product()
                {
                    Id = 1,
                    Name = "Мышка Логитеч",
                    Description = "Лучшая мышка в мире (точно не китайская подделка)",
                    Category = "Периферия для ПК"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Подписка на VS2022 Professional",
                    Description = "Контент для профессиАНАЛОВ",
                    Category = "Товары для людей с ОВЗ"
                }
            };
        }
    }
}
