using System;
using Avalonia.Controls;
using SaveLoad;
using Avalonia.Interactivity;
using System.Threading;
using System.Threading.Tasks;

namespace Notas_Csharp;

public partial class MainWindow : Window
{
    private int columnIndex = 1;
    private int rowIndex = 0;
    private CancellationTokenSource? _cts;
    

    public MainWindow()
    {
        InitializeComponent();
        //ShowData();
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
            Width = 300,
            PlaceholderText = "Insira um título para sua nota..."
        };

        var newContent = new TextBox()
        {
            Name = "Content",
            Width = 300,
            Height = 450,
            PlaceholderText = "Insira qualquer informação aqui..."
        };
        
        newContent.TextChanged += WrittingData;
        newTitle.TextChanged += WrittingData;

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

#region SAVE & LOAD METHODS
    private void ShowData()
    {
        var dataJson = new JsonSave();
        

        dataJson.LoadData(Title, Content);
    }


    private void WrittingData(object? sender, TextChangedEventArgs e)
    {
        _cts?.Cancel();
        _cts = new CancellationTokenSource();
        var token  = _cts.Token;

        Task.Delay(500, token).ContinueWith(t =>
        {
           if (t.IsCanceled) return;
            

            Avalonia.Threading.Dispatcher.UIThread.Post(() =>
            {
                var cardsContainer = new CardsContent()
                {
                    TitleCard = Title.Text,
                    ContentCard = Content.Text
                };

                var dataJson = new JsonSave();

                if (cardsContainer.TitleCard != null && cardsContainer.ContentCard != null)
                {
                    Console.WriteLine("GOOOOOL");
                    dataJson.SaveData(cardsContainer.TitleCard, cardsContainer.ContentCard);
                }
            });
        }, token);
    }
#endregion
}