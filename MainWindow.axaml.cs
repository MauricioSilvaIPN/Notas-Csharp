using System;
using Avalonia.Controls;
using SaveLoad;
using Avalonia.Interactivity;
using System.Threading;
using System.Threading.Tasks;

namespace Notas_Csharp;

public partial class MainWindow : Window
{
    private CancellationTokenSource? _cts;
    

    public MainWindow()
    {
        InitializeComponent();
        ShowData();
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
                    dataJson.SaveData(cardsContainer.TitleCard, cardsContainer.ContentCard);
                }
            });
        }, token);
    }
#endregion
}