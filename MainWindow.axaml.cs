using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Notas_Csharp;

public partial class MainWindow : Window
{
    private int columnIndex = 1;

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
            Name = "Notes"
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

        ContainerNotes.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));

        Grid.SetColumn(newStack, columnIndex);
        columnIndex++;

        ContainerNotes.Children.Add(newStack);

        newStack.Children.Add(newTitle);
        newStack.Children.Add(newContent);
    }
}