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
        public bool CheckAddOrUpdate { get; set; }
        public AddAndUpdateViewModel()
        {
                var vm = new AddProductUcViewModel();
                var view = new AddProductUc();
                view.DataContext = vm;
                App.MyStackPanel.Children.Add(view);
        }

    }
}
