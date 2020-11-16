using LB.SuperUI.BaseComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LB_SceneCreator
{
    private LB_EnumCreator enumCreator;

    public LB_SceneCreator(LB_EnumCreator enumCreator) 
    {
        this.enumCreator = enumCreator;
    }

    public void CreateScene(string sceneName)
    {
        if (!IsAllowedToCreateANewScene()) 
        {
            return;
        }

        var scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);
        if (sceneName != string.Empty) 
        {
            scene.name = sceneName;
        }

        SetupScene();
    }

    private bool IsAllowedToCreateANewScene()
    {
        return  EditorUtility.DisplayDialog("Create SuperUI Scene", 
            "Do you want to create a new scene?", 
            "Yes", 
            "No");
    }

    private void SetupScene()
    {
        CreateUIManager();
        CreatePanels();
    }
    private void CreateUIManager()
    {
        var manager = new GameObject("UIManager").AddComponent<LB_UIManager>();
        manager.transform.position = Vector3.zero;
        manager.gameObject.isStatic = true;
    }

    private void CreatePanels()
    {
        var panelNameList = enumCreator.GetEnumStrings();

        foreach (var panelName in panelNameList)
        {
            CreatePanel(panelName);
        }
    }

    private void CreatePanel(string panelName)
    {
        //TODO: read from json
        //Create gameObjects in Unity Scene
        //Generate codes and attach them to this gameObjects
        //TODO: code generation
        //Panel
        //name , UIOBjects array
        //{name, position}

        var panel = new GameObject(panelName).AddComponent<LB_UIPanel>();

    }
}
