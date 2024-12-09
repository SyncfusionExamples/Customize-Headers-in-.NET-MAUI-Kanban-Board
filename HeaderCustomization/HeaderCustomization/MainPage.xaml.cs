using System.Globalization;

namespace HeaderCustomization
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class BackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string title)
            {
                return title switch
                {
                    "To Do" => Colors.LightGoldenrodYellow,
                    "In Progress" => Colors.LightCyan,
                    "Code Review" => Colors.LightBlue,
                    "Done" => Colors.LightGreen,
                    _ => Colors.Transparent
                };
            }
            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string title)
            {
                return title switch
                {
                    "To Do" => "todolist.png",
                    "In Progress" => "inprogress.png",
                    "Code Review" => "review.png",
                    "Done" => "done.png",
                    _ => null
                };
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string title)
            {
                return title switch
                {
                    "To Do" => Colors.Orange,
                    "In Progress" => Colors.DarkCyan,
                    "Code Review" => Colors.Blue,
                    "Done" => Colors.Green,
                    _ => Colors.Transparent
                };
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
