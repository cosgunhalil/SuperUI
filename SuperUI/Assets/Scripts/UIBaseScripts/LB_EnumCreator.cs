using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class LB_EnumCreator : EditorWindow{

    public static LB_EnumCreator window;
    private Rect EnumsWindowRect = new Rect(100,100,200,200);

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
            text = "Enum Creator Tool"
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

        for (int i = 0; i < enums.Count; i++)
        {
            GUILayout.TextField(enums[i]);
        }

        if (GUILayout.Button("Save Enums"))
        {
            //todo save enum file
            var saveLocation = Application.dataPath + "/Scripts/UIBaseScripts/LB_MenuEnumContainer.cs";
            CreateEnum(saveLocation);
        }

        GUI.DragWindow();
    }

    public void CreateEnum(string saveLocation)
    {
        string classDefinition = string.Empty;
        classDefinition += "public enum PanelType" + Environment.NewLine;

        classDefinition += "{" + Environment.NewLine;

        for (int i = 0; i < enums.Count; i++)
        {
            classDefinition += "  " + enums[i] + "," + Environment.NewLine;
        }

        classDefinition += "}" + Environment.NewLine;

        File.WriteAllText(saveLocation, classDefinition);
    }
}
