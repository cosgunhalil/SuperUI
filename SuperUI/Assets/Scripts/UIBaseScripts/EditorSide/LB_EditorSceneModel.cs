using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_EditorSceneModel {

    public string EditorSceneName;
    public List<LB_EditorPanelModel> EditorPanels;

    public LB_EditorSceneModel(string editorSceneName)
    {
        this.EditorSceneName = editorSceneName;
        EditorPanels = new List<LB_EditorPanelModel>();
    }

}
