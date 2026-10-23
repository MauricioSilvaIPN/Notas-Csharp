using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Notas_Csharp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }



    public void CreateNewNote(object? sender, RoutedEventArgs args)
    {
        Console.WriteLine("Criou uma nova nota");
    }
}