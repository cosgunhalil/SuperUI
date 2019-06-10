using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LB.SuperUI.BaseComponents;

public class LB_EditorPanelModel {

    public string EditorPanelName;
    public List<LB_UIObject> EditorUIObjects;

    public LB_EditorPanelModel(string editorPanelName)
    {
        this.EditorPanelName = editorPanelName;
        EditorUIObjects = new List<LB_UIObject>(); 
    }

}
