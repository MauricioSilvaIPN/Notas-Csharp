using System.Text.Json;
using Avalonia.Controls;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;


namespace SaveLoad;

public class CardsContent
{
    public string? TitleCard { get; set; }
    public string? ContentCard { get; set; }
}


public class JsonSave
{
    string fileName = "savingData.json";

    public void SaveData(string titleRef, string contentRef)
    {
        var cardsContent = new CardsContent()
        {
            TitleCard = titleRef,
            ContentCard = contentRef
        };

        string jsonString = JsonSerializer.Serialize(cardsContent);
        File.WriteAllText(fileName, jsonString, Encoding.UTF8);

        //Console.WriteLine(File.ReadAllText(fileName));
    }

    public void LoadData(TextBox titleRef, TextBox contentRef)
    {
        if (File.Exists(fileName))
        {
            var fileContent = File.ReadAllText(fileName, Encoding.UTF8);
            CardsContent? cardsContent = 
            JsonSerializer.Deserialize<CardsContent>(fileContent);

            if (cardsContent != null)
            {
                titleRef.Text = $"{cardsContent.TitleCard}";
                contentRef.Text = $"{cardsContent.ContentCard}";    
            }
        }

    }
}
