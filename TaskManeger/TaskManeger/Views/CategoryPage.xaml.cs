using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManeger.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManeger.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        private CategoryViewModel _categoryViewModel;
        public CategoryPage()
        {
            InitializeComponent();
            BindingContext = _categoryViewModel = new CategoryViewModel();
        }
    }
}