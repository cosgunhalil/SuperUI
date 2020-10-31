using LB.SuperUI.BaseComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LB_SuperUI_Editor : EditorWindow
{
    public static LB_SuperUI_Editor editorWindow;
    private Rect MainEditorPanelRect = new Rect(100, 100, 200, 200);
    private Rect EnumsWindowRect = new Rect(100, 100, 200, 200);

    private Vector2 scrollPosition;
    private LB_EnumCreator enumCreator;
    private LB_SceneCreator sceneCreator;

    private string sceneName;

    private void Awake()
    {
        if (editorWindow == null)
        {
            CreateEditorWindow();
        }

        enumCreator = new LB_EnumCreator();
        enumCreator.Init();

        sceneCreator = new LB_SceneCreator(enumCreator);

        MainEditorPanelRect.position = new Vector2(6, 6); //TODO: think how can we place better way

        
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
        EnumsWindowRect = GUILayout.Window(2, EnumsWindowRect, DoEnumsWindow, "Enums");
        EndWindows();

        GUI.EndScrollView();

    }

    private void DoMainEditorWindow(int id)
    {
        GUILayout.Label("Setup your scenes in here.");

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Create A Manager"))
        {
            if (IsThereAnyManagersInTheScene()) 
            {
                return;
            }

            CreateUIManager();
        }

        if (GUILayout.Button("Convert To Manager"))
        {
            var selectedObject = Selection.activeGameObject;

            if (selectedObject == null) 
            {
                Debug.LogError("Please select a gameObject in the scene before try to convert a manager!");
                return;
            }

            if (IsThereAnyManagersInTheScene()) 
            {
                return;
            }

            var managerScript = selectedObject.GetComponent<LB_UIManager>();

            if (managerScript != null) 
            {
                Debug.LogWarning("The selected object is already a manager!");
                //TODO: do you want to remove manager component from the selected object?
                return;
            }

            selectedObject.AddComponent<LB_UIManager>();
            selectedObject.name = "UIManager";
        }

        if (GUILayout.Button("Remove All Managers"))
        {
            var managers = FindObjectsOfType<LB_UIManager>();

            for (int i = 0; i < managers.Length; i++)
            {
                GameObject.DestroyImmediate(managers[i].gameObject);
            }

        }

        GUILayout.EndHorizontal();

        GUILayout.Label("Scene Name");
        sceneName = GUILayout.TextField(sceneName);

        if (GUILayout.Button("Create New Scene"))
        {
            
            sceneCreator.CreateScene(sceneName);
        }

        GUI.DragWindow();
    }

    private void DoEnumsWindow(int id)
    {
        if (enumCreator == null) 
        {
            enumCreator = new LB_EnumCreator();
            enumCreator.Init();

            sceneCreator = new LB_SceneCreator(enumCreator);
        }

        GUILayout.Label("Enum to add");
        enumCreator.CurrentEnumStringToAdd = GUILayout.TextField(enumCreator.CurrentEnumStringToAdd);

        if (GUILayout.Button("Add Enum"))
        {
            enumCreator.AddEnum(enumCreator.CurrentEnumStringToAdd);
        }

        //TODO: improve current user interface
        for (int i = 0; i < enumCreator.GetEnumCount(); i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.TextField(enumCreator.GetEnum(i));

            if (i > 0)
            {
                if (GUILayout.Button("Up", GUILayout.Width(60)))
                {
                    enumCreator.MoveUpEnum(i);
                }
            }

            if (i < enumCreator.GetEnumCount() - 1)
            {
                if (GUILayout.Button("Down", GUILayout.Width(60)))
                {
                    enumCreator.MoveDownEnum(i);
                }
            }

            if (GUILayout.Button("Delete", GUILayout.Width(60)))
            {
                enumCreator.DeleteEnum(i);
            }

            GUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Save Enums"))
        {
            enumCreator.SaveEnums();
        }

        GUI.DragWindow();
    }

    private bool IsThereAnyManagersInTheScene()
    {
        var managers = FindObjectsOfType<LB_UIManager>();

        if (managers.Length == 1)
        {
            Debug.LogWarning("You have already a manager in your scene!");
            //TODO: do you want to delete it?
            return true;
        }

        return false;
    }

    private void CreateUIManager()
    {
        var manager = new GameObject("UIManager").AddComponent<LB_UIManager>();
        manager.transform.position = Vector3.zero;
        manager.gameObject.isStatic = true;
    }
}
