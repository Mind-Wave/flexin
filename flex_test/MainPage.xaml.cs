using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace flex_test
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            for (int i = 0; i < 100; i++)
            {
                var colorfulRect = new StackLayout { WidthRequest = 150,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center, 
                    HeightRequest = 150, 
                    BackgroundColor = GetRandomColor(), 
                    Margin = new Thickness(10)};
                
                colorfulRect.PropertyChanged += (sender, e) => 
                {
                    if (e.PropertyName == "X")
                    {

                    }
                    else if (e.PropertyName == "Y")
                    {

                    }
                };

                Label label = new Label { Text = (i + 1).ToString(), 
                    FontSize = 34, 
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.FillAndExpand };

                colorfulRect.Children.Add(label);

                colorfulRect.GestureRecognizers.Add(new TapGestureRecognizer((arg1, arg2) => { Handle_Clicked(); }));

                flex.Children.Add(colorfulRect);
            }

        }

        void Handle_Clicked()
        {
            double start = broker.WidthRequest;
            double end = 400 - start;

            

            var animate = new Animation(d => broker.WidthRequest = d, start, end, Easing.SinInOut);
            animate.Commit(broker, "BarGraph", 16, 250);
        }

        Color GetRandomColor()
        {
            var random = new Random();
            var color = String.Format("#{0:X6}", random.Next());
            Thread.Sleep(50);
            return Color.FromHex(color);
        }
    }
}
