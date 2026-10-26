using System.Text.Json;
using Avalonia.Controls;
using System;
using System.IO;


namespace SaveLoad;

public class CardsContent
{
    public string? GetTitleCard { get; set; }
    public string? GetContentCard { get; set; }
}


public class JsonSave
{
    public void SavingData(TextBox titleRef, TextBox contentRef)
    {
        var cardsContent = new CardsContent()
        {
            GetTitleCard = titleRef.Text,
            GetContentCard = contentRef.Text
        };

        string fileName = "savingData.json";
        string jsonString = JsonSerializer.Serialize(cardsContent);
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine(File.ReadAllText(fileName));
    }

    public void LoadData(TextBox titleRef, TextBox contentRef)
    {   


        var cardsContent = new CardsContent()
        {
            GetTitleCard = "",
            GetContentCard = "" 
        };
    }
}
