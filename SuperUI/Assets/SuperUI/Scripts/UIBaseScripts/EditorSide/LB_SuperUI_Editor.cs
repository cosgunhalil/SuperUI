using LB.SuperUI.BaseComponents;
using LB.SuperUI.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LB_SuperUI_Editor : EditorWindow
{
    public static LB_SuperUI_Editor editorWindow;
    private Rect MainEditorPanelRect = new Rect(100, 100, 200, 200);
    private Rect EnumsWindowRect = new Rect(100, 100, 200, 200);
    private Rect UIJsonCreatorWindowRect = new Rect(200, 100, 200, 200);

    private Vector2 scrollPosition;
    private LB_EnumCreator enumCreator;
    private LB_SceneCreator sceneCreator;

    private string sceneName;

    private string panelName;
    private SceneJsonData sceneJsonData;

    private void Awake()
    {
        if (editorWindow == null)
        {
            CreateEditorWindow();
        }

        sceneJsonData = new SceneJsonData();

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
        UIJsonCreatorWindowRect = GUILayout.Window(3, UIJsonCreatorWindowRect, DoJsonCreatorWindow, "UI Json Creator");
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

    private void DoJsonCreatorWindow(int id)
    {
        CreatePanelButton();
        RenderSceneJsonData();

        GUI.DragWindow();
    }

    private void CreatePanelButton()
    {
        GUILayout.Label("Current Panel Name");
        panelName = GUILayout.TextField(panelName);

        if (GUILayout.Button("Create Panel")) 
        {
            PanelJsonData panelJsonData = new PanelJsonData() { Name = panelName };
            sceneJsonData.AddPanelData(panelJsonData);

        }
    }

    private void RenderSceneJsonData()
    {
        GUILayout.Space(5);

        var panelDataList = sceneJsonData.GetPanelDataList();
        GUILayout.Label("Panels");

        for (int i = 0; i < panelDataList.Count; i++)
        {
            RenderPanelData(panelDataList, i);
        }

        CreateLoadMetaButton();
        CreateSaveMetaButton();
        CreateGenerateSceneButton();
    }

    private void RenderPanelData(List<PanelJsonData> panelDataList, int i)
    {
        GUILayout.BeginHorizontal();

        GUILayout.TextArea(panelDataList[i].Name);

        GUI.color = Color.red;

        if (GUILayout.Button("Delete"))
        {
            sceneJsonData.RemovePanelData(i);
        }

        GUI.color = Color.white;

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Add UIObject"))
        {
            panelDataList[i].AddUIObject(new UIObjectJsonData() { Name = "default object" });
        }


        GUILayout.EndHorizontal();

        if (i < panelDataList.Count)
        {
            RenderPanelDataUIObjects(panelDataList[i].GetUIObjectList());
        }

        GUILayout.Label("------");
        GUILayout.Space(10);
    }

    private void RenderPanelDataUIObjects(List<UIObjectJsonData> uiObjectList)
    {
        GUILayout.Label("UI Objects");

        GUILayout.BeginVertical();

        for (int i = 0; i < uiObjectList.Count; i++)
        {
            uiObjectList[i].Name = GUILayout.TextField(uiObjectList[i].Name);
        }

        GUILayout.EndVertical();
    }

    private void CreateLoadMetaButton()
    {
        if (GUILayout.Button("Load"))
        {
            string path = Application.dataPath + "/sceneUIMeta.data";
            FileStream fileStream;

            if (File.Exists(path))
            {
                fileStream = File.OpenRead(path);
            }
            else
            {
                Debug.LogError("There is now meta file in here! (path = " + path + ")");
                return;
            }

            var binaryFormatter = new BinaryFormatter();

            var dataString = binaryFormatter.Deserialize(fileStream) as string;

            sceneJsonData = JsonUtility.FromJson<SceneJsonData>(dataString);

            fileStream.Close();
        }
    }

    private void CreateSaveMetaButton()
    {
        if (GUILayout.Button("Save"))
        {
            string path = Application.dataPath + "/sceneUIMeta.data";
            FileStream fileStream;

            if (File.Exists(path))
            {
                fileStream = File.OpenWrite(path);
            }
            else
            {
                fileStream = File.Create(path);
            }

            var data = JsonUtility.ToJson(sceneJsonData);
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, data);

            fileStream.Close();

            Debug.Log(path);
            Debug.Log(JsonUtility.ToJson(sceneJsonData));
        }
    }

    private void CreateGenerateSceneButton()
    {
        if (GUILayout.Button("Generate Scene")) 
        {
            GenerateScene("Main");
            GenerateUIManager(sceneJsonData.UIManagerName);
            SetupPanels(sceneJsonData.GetPanelDataList());
        }
    }

    private void GenerateUIManager(string uIManagerName)
    {
        new GameObject(uIManagerName).AddComponent<LB_UIManager>();
    }

    private void GenerateScene(string sceneName)
    {
        EditorSceneManager.NewScene(new NewSceneSetup(), NewSceneMode.Single);
        var activeScene = EditorSceneManager.GetActiveScene();
        activeScene.name = sceneName;

        var camera = new GameObject("Main Camera").AddComponent<Camera>();
        camera.orthographic = true;

    }

    private void SetupPanels(List<PanelJsonData> panelList)
    {
        for (int i = 0; i < panelList.Count; i++)
        {
            CreatePanel(panelList[i]);
        }
    }

    private void CreatePanel(PanelJsonData panelJsonData)
    {
        var panelObject = new GameObject(panelJsonData.Name);
        SetupPanelUIObjects(panelObject, panelJsonData.GetUIObjectList());
    }

    private void SetupPanelUIObjects(GameObject panelObject, List<UIObjectJsonData> uiObjectList)
    {
        for (int i = 0; i < uiObjectList.Count; i++)
        {
            var uiObject = CreateUIObject(uiObjectList[i]);
            uiObject.transform.SetParent(panelObject.transform);
        }
    }
    private GameObject CreateUIObject(UIObjectJsonData uIObjectJsonData)
    {
        return new GameObject(uIObjectJsonData.Name);
    }
}
