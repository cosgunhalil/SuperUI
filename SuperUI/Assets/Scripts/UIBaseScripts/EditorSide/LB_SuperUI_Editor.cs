using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LB_SuperUI_Editor : EditorWindow
{
    public static LB_SuperUI_Editor editorWindow;
    private Rect MainEditorPanelRect = new Rect(100, 100, 200, 200);
    private Vector2 scrollPosition;

    private void Awake()
    {
        if (editorWindow == null)
        {
            CreateEditorWindow();
        }

        MainEditorPanelRect.position = new Vector2(6, 6); //todo  think how can we place better way
    }

    [MenuItem("Tools/Open Super UI Editor")]
    public static void CreateEditorWindow()
    {
        editorWindow = (LB_SuperUI_Editor)EditorWindow.GetWindow(typeof(LB_SuperUI_Editor)); //create a window
        GUIContent title = new GUIContent
        {
            text = "SuperUI Editor"
        };
        editorWindow.titleContent = title;
    }

    void OnGUI()
    {

        scrollPosition = GUI.BeginScrollView(new Rect(0, 0, position.width, position.height), scrollPosition, new Rect(0, 0, 1000, 1000));

        BeginWindows();
        MainEditorPanelRect = GUILayout.Window(1, MainEditorPanelRect, DoMainEditorWindow, "Main Editor Panel");
        EndWindows();

        GUI.EndScrollView();

    }

    private void DoMainEditorWindow(int id)
    {
        GUILayout.Label("Setup your scenes in here.");

        if (GUILayout.Button("Create Scene"))
        {
            
        }

        GUI.DragWindow();
    }
}
