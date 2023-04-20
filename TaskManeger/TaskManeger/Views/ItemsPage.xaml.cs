using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManeger.Models;
using TaskManeger.ViewModels;
using TaskManeger.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManeger.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        private bool SlidingPanelIsShown = false;


        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();

            Task.Run(AnimateBackground);
        }

        private async void AnimateBackground()
        {
            int animationDuration = 5000;
            var forwardAnim = new Animation(x => BackGradient.AnchorY = x, 0, 1, Easing.Linear);
            var backwardAnim = new Animation(x => BackGradient.AnchorY = x, 1, 0, Easing.Linear);

            while (true)
            {
                forwardAnim.Commit(BackGradient, "forwardAnim", 16U, (uint) animationDuration, Easing.Linear, null, () => false);
                await Task.Delay(animationDuration);
                backwardAnim.Commit(BackGradient, "backwardAnim", 16U,(uint) animationDuration, Easing.Linear, null, () => false);
                await Task.Delay(animationDuration);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

            HideSlidingPanel();
        }

        private async void HideSlidingPanel()
        {
            while(this.Height == -1)
                {
                    await Task.Delay(200);
                    SlidingPanel.TranslationY = this.Height;
                    SPBackground.BackgroundColor = Color.Transparent;
                    SPBackground.InputTransparent = true;
            }
                    SlidingPanel.TranslationY = this.Height;
                    SPBackground.BackgroundColor = Color.Transparent;
                    SPBackground.InputTransparent = true;

                    SlidingPanelIsShown = false;
        }

        private async void FloatingButton_Clicked(object sender, EventArgs e)
        {
            SwitchSlidingPanel();

            AnimateFloatingButton();
        }

        private void SwitchSlidingPanel()
        {
            if (SlidingPanelIsShown)
            {
                SlidingPanel.TranslateTo(0, this.Height, 250, Easing.SinIn);

                SPBackground.BackgroundColor = Color.Transparent;
                SPBackground.InputTransparent = true;
            }
            else
            {
                SlidingPanel.TranslateTo(0, this.Height - QuickMenu.Height - 30, 250, Easing.SpringOut);

                SPBackground.BackgroundColor = Color.FromRgba(55,55,55,99);
                SPBackground.InputTransparent = false;
            }

            SlidingPanelIsShown = !SlidingPanelIsShown;
        }

        private async Task AnimateFloatingButton()
        {
            FloatingButton.ScaleTo(0.9, 125);
            await FloatingButton.TranslateTo(0, -5, 125);

            FloatingButton.ScaleTo(1, 125);
            await FloatingButton.TranslateTo(0, 5, 125);
        }

        private void SPBackground_OnTapped(object sender, EventArgs e)
        {
            SwitchSlidingPanel();
        }

        private void QuickMenuButton_OnClicked(object sender, EventArgs e)
        {
            SwitchSlidingPanel();
        }

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
                switch (e.Direction)
                {
                    case SwipeDirection.Up:
                    SlidingPanel.TranslateTo(0, this.Height - QuickMenu.Height - 350 - 30, 250, Easing.SinIn);
                    break;
                    case SwipeDirection.Down:
                    SlidingPanel.TranslateTo(0, this.Height - QuickMenu.Height - 30, 250, Easing.SinIn);
                    break;
                }
            
        }
    }
}