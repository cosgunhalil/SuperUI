using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class LB_EnumCreator : EditorWindow{

    public static LB_EnumCreator window;
    private Rect EnumsWindowRect = new Rect(100,100,200,200);

    private const string enumContainerPath = "/Scripts/UIBaseScripts/LB_MenuEnumContainer.cs";//todo improve - must be dynamic
    private List<string> enums;
    private Vector2 scrollPosition;

    private string currentEnumStringToAdd = string.Empty;

    private void Awake()
    {
        if (window == null)
        {
            CreateWindow();
            enums = GetEnumStrings();
        }

        EnumsWindowRect.position = new Vector2(6,6); //todo  think how can we place better way
    }

    private List<string> GetEnumStrings()
    {
        var currentEnums = new List<string>();
        foreach (var enumString in Enum.GetNames(typeof(PanelType)))
        {
            currentEnums.Add(enumString);
        }

        return currentEnums;
    }

    [MenuItem("Tools/EnumCreator")]
    public static void CreateWindow()
    {
        window = (LB_EnumCreator)EditorWindow.GetWindow(typeof(LB_EnumCreator)); //create a window
        GUIContent title = new GUIContent
        {
            text = "EnumCreator"
        };
        window.titleContent = title;
    }

    void OnGUI()
    {

        scrollPosition = GUI.BeginScrollView(new Rect(0, 0, position.width, position.height), scrollPosition, new Rect(0, 0, 1000, 1000));

        BeginWindows();
        EnumsWindowRect = GUILayout.Window(1,EnumsWindowRect,DoEnumsWindow,"Enums");
        EndWindows();

        GUI.EndScrollView();

    }

    private void DoEnumsWindow(int id)
    {
        
        GUILayout.Label("Enum to add");
        currentEnumStringToAdd = GUILayout.TextField(currentEnumStringToAdd);
        if (GUILayout.Button("Add Enum"))
        {
            if (!enums.Contains(currentEnumStringToAdd) && currentEnumStringToAdd != string.Empty)
            {
                enums.Add(currentEnumStringToAdd);
                currentEnumStringToAdd = string.Empty;
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

        //todo improve current user interface
        for (int i = 0; i < enums.Count; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.TextField(enums[i]);

            if (i > 0)
            {
                if (GUILayout.Button("Up", GUILayout.Width(60)))
                {
                    MoveUpEnum(i);
                }
            }

            if (i < enums.Count - 1)
            {
                if (GUILayout.Button("Down", GUILayout.Width(60)))
                {
                    MoveDownEnum(i);
                }
            }

            if (GUILayout.Button("Delete", GUILayout.Width(60)))
            {
                DeleteEnum(i);
            }
            GUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Save Enums"))
        {
            var saveLocation = Application.dataPath + enumContainerPath;
            CreateEnumContainerScript(saveLocation);
        }

        if (GUILayout.Button("Test Code Generation"))
        {
            
            CreateManagerScript("MenuManager");
        }

        GUI.DragWindow();
    }

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

    private void MoveUpEnum(int i)
    {
        var temp = enums[i - 1];
        enums[i - 1] = enums[i];
        enums[i] = temp;
    }

    private void MoveDownEnum(int i)
    {
        var temp = enums[i + 1];
        enums[i + 1] = enums[i];
        enums[i] = temp;
    }

    private void DeleteEnum(int i)
    {
        enums.RemoveAt(i);
    }

    public void CreateEnumContainerScript(string saveLocation)
    {
        string classContent = string.Empty;
        classContent += "public enum PanelType" + Environment.NewLine;

        classContent += "{" + Environment.NewLine;

        for (int i = 0; i < enums.Count - 1; i++)
        {
            classContent += "    " + enums[i] + "," + Environment.NewLine;
        }

        classContent += "    " + enums[enums.Count - 1] + Environment.NewLine;
        classContent += "}" + Environment.NewLine;

        File.WriteAllText(saveLocation, classContent);
        AssetDatabase.Refresh();
    }
}
