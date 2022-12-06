using ECommerce.Commands;
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
    public class UpdateViewModel:BaseViewModel
    {
        private readonly IRepository<Product> _dataContext;
        private ObservableCollection<Product> allProducts ;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; }
        }

        private Product selectedItem;

        public Product SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; OnPropertyChanged(); }
        }

        public RelayCommand SelectProductCommand { get; set; }

        public UpdateViewModel()
        {
            _dataContext = new ProductRepository();
            AllProducts=_dataContext.GetAllData();


            SelectProductCommand = new RelayCommand((e) =>
            {
                try
                {
                    App.ProductStackPanel.Children.RemoveAt(0);
                    var vm=new UpdateUcViewModel(SelectedItem);
                    vm.SelectedItem = SelectedItem;
                    var view = new UpdateProductUc();
                    view.DataContext = vm;
                    App.ProductStackPanel.Children.Add(view);
                }
                catch (Exception)
                {

                }
            });
        }
    }
}
