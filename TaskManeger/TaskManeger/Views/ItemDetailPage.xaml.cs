using System.ComponentModel;
using TaskManeger.ViewModels;
using Xamarin.Forms;

namespace TaskManeger.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}