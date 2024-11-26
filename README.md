# Customize-Headers-in-.NET-MAUI-Kanban-Board
This article provides a detailed walkthrough on how to customize the header of [.NET MAUI Kanban board](https://www.syncfusion.com/maui-controls/maui-kanban).

In this guide, you’ll learn how to customize the header of a MAUI Kanban board by changing the background color and image based on the column title. The customization is achieved using DataTriggers within the [HeaderTemplate](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Kanban.SfKanban.html#Syncfusion_Maui_Kanban_SfKanban_HeaderTemplate) of the [SfKanban](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Kanban.SfKanban.html) component.

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

**Step 2:** To customize the header, use the HeaderTemplate property. A DataTemplate is used to define the layout of each header

**XAML**

```
<kanban:SfKanban.HeaderTemplate>

       <DataTemplate>
           <StackLayout Orientation="Horizontal" Padding="10" HorizontalOptions="FillAndExpand" VerticalOptions="Center">
           </StackLayout>
       </DataTemplate>

</kanban:SfKanban.HeaderTemplate>
```

**Step 3:** Use DataTriggers to dynamically change the background color and image of the header based on the column title.

**XAML**

```
<kanban:SfKanban.HeaderTemplate>
   <DataTemplate>
       <StackLayout Orientation="Horizontal" Padding="10" HorizontalOptions="FillAndExpand" VerticalOptions="Center">

           <StackLayout.Triggers>
               <DataTrigger TargetType="StackLayout" Binding="{Binding Title}" Value="To Do">
                   <Setter Property="BackgroundColor" Value="LightGoldenrodYellow"/>
               </DataTrigger>
               <DataTrigger TargetType="StackLayout" Binding="{Binding Title}" Value="In Progress">
                   <Setter Property="BackgroundColor" Value="LightCyan"/>
               </DataTrigger>
               <DataTrigger TargetType="StackLayout" Binding="{Binding Title}" Value="Code Review">
                   <Setter Property="BackgroundColor" Value="LightBlue"/>
               </DataTrigger>
               <DataTrigger TargetType="StackLayout" Binding="{Binding Title}" Value="Done">
                   <Setter Property="BackgroundColor" Value="LightGreen"/>
               </DataTrigger>
           </StackLayout.Triggers>

           <Image VerticalOptions="Center" WidthRequest="40" HeightRequest="40">
               <Image.Triggers>
                   <DataTrigger TargetType="Image" Binding="{Binding Title}" Value="To Do">
                       <Setter Property="Source" Value="todolist.png" />
                   </DataTrigger>
                   <DataTrigger TargetType="Image" Binding="{Binding Title}" Value="In Progress">
                       <Setter Property="Source" Value="inprogress.png" />
                   </DataTrigger>
                   <DataTrigger TargetType="Image" Binding="{Binding Title}" Value="Code Review">
                       <Setter Property="Source" Value="review.png" />
                   </DataTrigger>
                   <DataTrigger TargetType="Image" Binding="{Binding Title}" Value="Done">
                       <Setter Property="Source" Value="done.png" />
                   </DataTrigger>
               </Image.Triggers>
           </Image>

           <Label Text="{Binding Title}" TextColor="Black" FontAttributes="Bold" Margin="10" FontSize="18" VerticalOptions="Center" HorizontalOptions="StartAndExpand"/>

       </StackLayout>
   </DataTemplate>
</kanban:SfKanban.HeaderTemplate>
```

**Output:**

![HeaderCustomizationKanban](https://github.com/user-attachments/assets/d1e049d2-e50b-4cff-9ab9-515289c57922)

**Conclusion:**
