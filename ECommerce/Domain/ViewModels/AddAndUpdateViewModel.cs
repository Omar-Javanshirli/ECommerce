using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModels
{
    public class AddAndUpdateViewModel : BaseViewModel
    {
        private readonly IRepository<Product> _dataContext;
        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }
        public bool CheckAddOrUpdate { get; set; }
        public AddAndUpdateViewModel()
        {

            if (CheckAddOrUpdate == true)
            {
                var vm = new AddProductUcViewModel();
                var view = new AddProductUc();
                view.DataContext = vm;
                App.MyStackPanel.Children.Add(view);
            }
            else
            {
                _dataContext = new ProductRepository();
                AllProducts = _dataContext.GetAllData();
            }

        }
    }
}
