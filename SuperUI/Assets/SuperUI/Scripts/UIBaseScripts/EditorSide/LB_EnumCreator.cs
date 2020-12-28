
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using LB.SuperUI.BaseComponents;
using System.Text;
using LB.Helper.FileHandler;

public class LB_EnumCreator{

    public string CurrentEnumStringToAdd 
    { 
        get => currentEnumStringToAdd; 
        set => currentEnumStringToAdd = value; 
    }

    private const string enumContainerPath = "/Scripts/UIBaseScripts/LB_MenuEnumContainer.cs";//TODO: improve - must be dynamic
    private List<string> enums;

    private string currentEnumStringToAdd = string.Empty;

    public void Init()
    {
        enums = GetEnumStrings();
    }

    public List<string> GetEnumStrings()
    {
        var currentEnums = new List<string>();
        foreach (var enumString in Enum.GetNames(typeof(UIState)))
        {
            currentEnums.Add(enumString);
        }

        return currentEnums;
    }

    //TODO: Move!!!!
    private void CreateManagerScript(string className)
    {
        var templateLocation = Application.dataPath + "/Scripts/CodeTemplates/UIManagerTemplate.txt";
        var saveLocation = Application.dataPath + "/Scripts/CodeTemplates/" + className + ".cs";
        string template = string.Empty;

        using (StreamReader sr = new StreamReader(templateLocation))
        {
            // Read the stream to a string, and write the string to the console.

            template = sr.ReadToEnd();
        }
        Debug.Log("before");
        Debug.Log(template);

        template = template.Replace("<-className->", className);
        Debug.Log("after");
        Debug.Log(template);

        File.WriteAllText(saveLocation, template);
        AssetDatabase.Refresh();

    }

    public void MoveUpEnum(int i)
    {
        var temp = enums[i - 1];
        enums[i - 1] = enums[i];
        enums[i] = temp;
    }

    public void MoveDownEnum(int i)
    {
        var temp = enums[i + 1];
        enums[i + 1] = enums[i];
        enums[i] = temp;
    }

    public void DeleteEnum(int i)
    {
        enums.RemoveAt(i);
    }

    public void CreateEnumContainerScript(string saveLocation)
    {

        //TODO: read template file from location
        //TODO: change template then save file!

        LB_Writer writer = new LB_Writer();
        writer.Write(saveLocation, "public class TestClass{}");

        AssetDatabase.Refresh();
    }

    public void AddEnum(string currentEnumStringToAdd)
    {
        if (!enums.Contains(currentEnumStringToAdd) && currentEnumStringToAdd != string.Empty)
        {
            enums.Add(currentEnumStringToAdd);
            this.CurrentEnumStringToAdd = string.Empty;
        }
        else
        {
            if (currentEnumStringToAdd == string.Empty)
            {
                Debug.LogError("Enums can not be empty! Please enter a string.");
            }
            else
            {
                Debug.LogError("You already have enum <color=blue>" + currentEnumStringToAdd + " </color> in the enum container");
            }
        }
    }

    public int GetEnumCount()
    {
        return enums.Count;
    }

    public string GetEnum(int i)
    {
        return enums[i];
    }

    public void SaveEnums()
    {
        //var saveLocation = Application.dataPath + enumContainerPath;
        var saveLocation = Application.dataPath + "/sampleGeneratedCode.cs";
        CreateEnumContainerScript(saveLocation);
    }
}
