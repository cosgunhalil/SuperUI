using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_EditorUIElementModel {

    public string UIObjectName;
    public UIObjectType ObjectType;

    public LB_EditorUIElementModel(string uiObjectName, UIObjectType uiObjectType)
    {
        this.UIObjectName = uiObjectName;
        this.ObjectType = uiObjectType;
    }
}
