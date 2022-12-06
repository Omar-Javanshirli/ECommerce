using ECommerce.Domain.ViewModels;
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

namespace ECommerce.Domain.Views
{
    /// <summary>
    /// Interaction logic for AddAndUpdateWindow.xaml
    /// </summary>
    public partial class AddAndUpdateWindow : Window
    {
        public AddAndUpdateWindow()
        {
            InitializeComponent();
            App.MyStackPanel = MyStackpanel;
            var vm=new AddAndUpdateViewModel();
            this.DataContext = vm;
        }
    }
}
