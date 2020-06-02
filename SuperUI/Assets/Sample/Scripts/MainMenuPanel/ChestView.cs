using System.Collections;
using System.Collections.Generic;
using LB.SuperUI.BaseComponents;
using UnityEngine;

public class ChestView : LB_UIObject
{
    public override void Setup(Vector2 canvasSize)
    {
        Debug.Log("<color=red>" + gameObject.name + "</color>");
    }
}
