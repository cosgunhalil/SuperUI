using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_EditorUIElementModel {

    public string UIElementName;
    public UIElementType UIElementType;

    public LB_EditorUIElementModel(string elementName, UIElementType uiElementType)
    {
        this.UIElementName = elementName;
        this.UIElementType = uiElementType;
    }
}
