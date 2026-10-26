using System.Text.Json;
using Avalonia.Controls;
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

    public void SavingData(string titleRef, string contentRef)
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

    public void LoadData(string titleRef, string contentRef)
    {   
        if (File.Exists(fileName))
        {
            Console.WriteLine(File.ReadAllText(fileName));

            var fileContent = File.ReadAllText(fileName);

            string[] separateString = fileContent.Split(":");
            string prefix = separateString[0];

            Console.WriteLine(prefix);

            
            /*var cardsContent = new CardsContent()
            {
                //TitleCard = "",
                //ContentCard = "" 
            };*/
        }

    }
}
