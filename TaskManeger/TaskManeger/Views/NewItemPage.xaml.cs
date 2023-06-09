﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TaskManeger.Models;
using TaskManeger.Services;
using TaskManeger.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManeger.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        private NewItemViewModel _viewModel;
        private IEnumerable<Category> categories;

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new NewItemViewModel();
            LoadCategories();
        }
        async Task LoadCategories()
        {
    

            try
            {
                
               categories = await _viewModel.DataStoreCategories.GetItemsAsync(true);
                List<string> categoriesTitles = new List<string>();
                foreach (var category in categories)
                {
                    categoriesTitles.Add(category.Title);
                }
                PickerCategory.ItemsSource = categoriesTitles;
                if (categoriesTitles.Count > 0)
                    PickerCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void DatePickerDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            _viewModel.Date = e.NewDate.ToShortDateString();
        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}