using LB.SuperUI.BaseComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventContainer : LB_UIObject
{
    public override void Setup(Vector2 canvasSize)
    {
        activatedCoordinate = objectRectTransform.anchoredPosition;
        deactivtedCoordinate = new Vector2(
            canvasSize.x * .5f + objectRectTransform.sizeDelta.x * .5f,
            objectRectTransform.anchoredPosition.y);

        objectRectTransform.anchoredPosition = deactivtedCoordinate;
    }
}
