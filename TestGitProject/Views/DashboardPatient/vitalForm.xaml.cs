#define __IOS__
#define __ANDROID__

using System;
using System.Collections.Generic;
using Syncfusion.SfRangeSlider.XForms;
using Xamarin.Forms;

namespace TestGitProject.Views.DashboardPatient
{
    public partial class vitalForm : ContentPage
    {
        public vitalForm()
        {
            InitializeComponent();

#if __IOS__
            Slider.SetBinding(SfRangeSlider.ValueProperty, new Binding("Text", source: RelatedValueText4));
            PSlider.SetBinding(SfRangeSlider.ValueProperty, new Binding("Text", source: RelatedValueText5));
#endif
        }

        public vitalForm(string user)
        {
            InitializeComponent();

#if __IOS__
            Slider.SetBinding(SfRangeSlider.ValueProperty, new Binding("Text", source: RelatedValueText4));
            PSlider.SetBinding(SfRangeSlider.ValueProperty, new Binding("Text", source: RelatedValueText5));
#endif
        }

        void text4Toggled(object sender, EventArgs args)
        {
        }

        void OnInfoImageTapped(object sender, EventArgs args)
        {
        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
        }

        void goodDayToggled(object sender, EventArgs args)
        {
        }

        void picToggled(object sender, EventArgs args)
        {
        }

        void OnClickedVitalSubmit(object sender, System.EventArgs e)
        {
        }
#if __IOS__
            void OnSliderValueChanged(object sender, ValueEventArgs e)
        {
            RelatedValueText4.Text = e.Value.ToString("F1"); //To display only integer  values
        }
        void OnPSliderValueChanged(object sender, ValueEventArgs e)
        {
            var StepValue = 1.0;
            var newStep = Math.Round(e.Value / StepValue);
            RelatedValueText5.Text = (newStep * StepValue).ToString(); //To display only integer  values
        }
#endif

            //With default slider
#if __ANDROID__
        void OnSliderValueChangedAndroid(object sender, ValueChangedEventArgs e)
        {
            RelatedValueText4.Text = String.Format("{0:F1}", e.NewValue);
        }
        void OnPSliderValueChangedAndroid(object sender, ValueChangedEventArgs e)
        {       
            var StepValue = 1.0;
            var newStep = Math.Round(e.NewValue / StepValue);
            RelatedValueText5.Text = (newStep * StepValue).ToString(); //To display only integer  values
        }
#endif

        async void GoToNextPage(object sender, System.EventArgs e)
        {
            layout2.IsVisible = true; layout1.IsVisible = false;
            await scrollViewVital.ScrollToAsync(StackLayoutTop, ScrollToPosition.Start, true);
        }

        async void OnClickedBackBtn(object sender, System.EventArgs e)
        {
            layout2.IsVisible = false; layout1.IsVisible = true;
            await scrollViewVital.ScrollToAsync(StackLayoutTop, ScrollToPosition.Center, true);
        }


    }
}
