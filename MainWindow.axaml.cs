using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Notas_Csharp;

public partial class MainWindow : Window
{
    private int columnIndex = 1;
    private int rowIndex = 0;

    public MainWindow()
    {
        InitializeComponent();
    }


    public void CreateNewNote(object? sender, RoutedEventArgs args)
    {
        var newStack = new StackPanel()
        {
            Orientation = Avalonia.Layout.Orientation.Vertical,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            Name = "Notes",
            Margin = new Avalonia.Thickness(0, 0, 15, 15)
        };

        var newTitle = new TextBox()
        {
            Name = "Title",
            Width = 300
        };

        var newContent = new TextBox()
        {
            Name = "Content",
            Width = 300,
            Height = 450
        };

        ContainerNotes.RowDefinitions.Add(new RowDefinition(GridLength.Auto));

        if (columnIndex < 3)
        {
            Grid.SetColumn(newStack, columnIndex);
            Grid.SetRow(newStack, rowIndex);
        }
        else
        {
            rowIndex++;
            columnIndex = 0;

            Grid.SetRow(newStack, rowIndex);
            Grid.SetColumn(newStack, columnIndex);
        }

        columnIndex++;

        ContainerNotes.Children.Add(newStack);

        newStack.Children.Add(newTitle);
        newStack.Children.Add(newContent);
    }
}