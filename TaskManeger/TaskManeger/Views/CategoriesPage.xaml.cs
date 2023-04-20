using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TaskManeger.ViewModels;

namespace TaskManeger.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage1 : ContentPage
    {
       private CategoriesViewModel _viewModel;
        public CategoryPage1()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CategoriesViewModel();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        async void OnItemSelected(Models.Category category)
        {
            if (category == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(CategoryPage)}?{nameof(CategoryViewModel.ItemId)}={category.Id}");
        }
    }
}