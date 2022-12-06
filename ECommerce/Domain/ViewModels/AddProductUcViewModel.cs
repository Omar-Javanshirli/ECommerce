using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModels
{
    public class AddProductUcViewModel:BaseViewModel
    {
        private readonly IRepository<Product> _productRepo;

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }

        private string price;

        public string Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }

        private string discount;

        public string Discount
        {
            get { return discount; }
            set { discount = value; OnPropertyChanged(); }
        }

        private string quantity;

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; OnPropertyChanged(); }
        }

        public RelayCommand AddCommand { get; set; }
        public AddProductUcViewModel()
        {
            _productRepo=new ProductRepository();

            AddCommand = new RelayCommand((e) =>
            {
                Product p = new Product
                {
                    Name = Name,
                    Description = Description,
                    Price = int.Parse(Price),
                    Discount = int.Parse(Discount),
                    Quantity = int.Parse(Quantity)
                };
                _productRepo.AddData(p);
            });
        }

    }
}
