using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Abstractions.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerce.Domain.ViewModels
{
    public class AdminViewModel:BaseViewModel
    {
        public OrderModel orderModel{ get; set; }
        private readonly IRepository<Order> _orderRepo;
        private ObservableCollection<Order> allProducts;

        public ObservableCollection<Order> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }

        private string totalPrice;

        public string TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; OnPropertyChanged(); }
        }

        private Order selectedProduct;

        public Order SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }

        public RelayCommand TotalPriceCommand { get; set; }
        public RelayCommand SelectProductCommand { get; set; }
        public AdminViewModel()
        {
            _orderRepo = new OrderRepository();
            AllProducts=_orderRepo.GetAllData();

            TotalPriceCommand = new RelayCommand((e) =>
            {
                var result = 0;
                foreach (var item in AllProducts)
                {
                    result+= ((int)item.Product.Price);
                }
                if (TotalPrice != null)
                {
                    totalPrice = TotalPrice.ToString();
                    TotalPrice = result.ToString();
                }
                else
                    TotalPrice = result.ToString();
            });

            SelectProductCommand = new RelayCommand((e) =>
            {
                var result = 0; 
                for (int i = 0; i < SelectedProduct.Amount; i++)
                {
                    result += ((int)SelectedProduct.Product.Price);
                }
                if(TotalPrice!= null)
                {
                    totalPrice= TotalPrice.ToString();
                    TotalPrice = result.ToString();
                }
                else
                    TotalPrice = result.ToString();
            });
        }
    }
}
