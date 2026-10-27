using System.Text.Json;
using Avalonia.Controls;
using System.Collections.Generic;
using System;
using System.IO;


namespace SaveLoad;

public class CardsContent
{
    public string? TitleCard { get; set; }
    public string? ContentCard { get; set; }
}


public class JsonSave
{
    string fileName = "savingData.json";
    Dictionary<string, string> myDictionary = new Dictionary<string, string>();

    public void SaveData(string titleRef, string contentRef)
    {
        //List<CardsContent> cardsContent = new List<CardsContent>();

        var cardsContent = new CardsContent()
        {
            TitleCard = titleRef,
            ContentCard = contentRef
        };

        string jsonString = JsonSerializer.Serialize(cardsContent);
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine(File.ReadAllText(fileName));
    }

    public void LoadData(TextBox titleRef, TextBox contentRef)
    {
        if (File.Exists(fileName))
        {
            var fileContent = File.ReadAllText(fileName);

            if (fileContent.Contains(','))
            {
                string[] firstSeparate = fileContent.Split(",");
                
                for(int i = 0; i < firstSeparate.Length; i++)
                {
                    string[] parts = firstSeparate[i].Split(":");
                    string prefix = parts[0].Trim( new Char[] {'{', '"'} );
                    string cardsText = parts[1].Trim( new Char[] {'}', '"'} );

                    myDictionary.Add(prefix, cardsText);                    
                }
            }


            titleRef.Text = myDictionary["TitleCard"];
            contentRef.Text = myDictionary["ContentCard"];
        }

    }
}
