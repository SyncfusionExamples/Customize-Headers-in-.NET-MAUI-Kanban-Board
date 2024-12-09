# Customize-Headers-in-.NET-MAUI-Kanban-Board
This article provides a detailed walkthrough on how to customize the header of [.NET MAUI Kanban board](https://www.syncfusion.com/maui-controls/maui-kanban).

In this guide, you’ll learn how to customize the header of a MAUI Kanban board by changing the background color, text color and image based on the column title. The customization is achieved using IValueConverter within the [HeaderTemplate](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Kanban.SfKanban.html#Syncfusion_Maui_Kanban_SfKanban_HeaderTemplate) of the [SfKanban](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Kanban.SfKanban.html) component.

**Step 1:** Initialize the SfKanban and add the Columns to it as follows

**XAML**

```
<kanban:SfKanban AutoGenerateColumns="False" 
                HorizontalOptions="FillAndExpand" 
                VerticalOptions="FillAndExpand" 
                ItemsSource="{Binding Cards}">

   <kanban:SfKanban.Columns>

       <kanban:KanbanColumn Title="To Do" Categories="Open" >
       </kanban:KanbanColumn>

       <kanban:KanbanColumn Title="In Progress" Categories="In Progress">
       </kanban:KanbanColumn>

       <kanban:KanbanColumn Title="Code Review" Categories="Code Review">
       </kanban:KanbanColumn>

       <kanban:KanbanColumn Title="Done"  Categories="Done">
       </kanban:KanbanColumn>

   </kanban:SfKanban.Columns>

</kanban:SfKanban>
```

**Step 2:** This code defines a resource dictionary within a ContentPage, registering three converters for use in XAML bindings throughout the page.

**XAML**

```
<ContentPage.Resources>
   <ResourceDictionary>
       <local:BackgroundColorConverter x:Key="BackgroundColorConverter"/>
       <local:ImageSourceConverter x:Key="ImageSourceConverter"/>
       <local:TextColorConverter x:Key="TextColorConverter"/>
   </ResourceDictionary>
</ContentPage.Resources> 
```

**Step 3:** To customize the header, use the HeaderTemplate property and use convertor to dynamically change the background color, text color and image of the header based on the column title.

**XAML**

```
<kanban:SfKanban.HeaderTemplate>
   <DataTemplate>
       <StackLayout Orientation="Horizontal" Padding="10" 
            HorizontalOptions="FillAndExpand" VerticalOptions="Center" 
            BackgroundColor="{Binding Title, Converter={StaticResource BackgroundColorConverter}}">

           <Image VerticalOptions="Center" WidthRequest="40" HeightRequest="40"
          Source="{Binding Title, Converter={StaticResource ImageSourceConverter}}"/>

            <Label Text="{Binding Title}" TextColor="{Binding Title, Converter={StaticResource TextColorConverter}}" FontAttributes="Bold" 
            Margin="10" FontSize="18" VerticalOptions="Center" 
            HorizontalOptions="StartAndExpand" />
       </StackLayout>
   </DataTemplate>
</kanban:SfKanban.HeaderTemplate>
```

**Step 4:** This code defines three converters **BackgroundColorConverter**, **ImageSourceConverter** and **TextColorConverter** which map a Title string to corresponding background colors, text color and image sources respectively for dynamic UI binding in XAML.

**C#**

```
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
```

**Output:**

![KanbanHeaderCustomization](https://github.com/user-attachments/assets/cd9df08c-6874-4e9e-b88a-dcdd05e6246c)

