using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using LB.SuperUI.BaseComponents;
using UnityEngine;

public class ChestContainer : LB_UIObject
{
    public override void Setup(Vector2 canvasSize)
    {
        activatedCoordinate = objectRectTransform.anchoredPosition;
        deactivtedCoordinate = new Vector2(
            -canvasSize.x * .5f - objectRectTransform.sizeDelta.x * .5f,
            objectRectTransform.anchoredPosition.y);

        objectRectTransform.anchoredPosition = deactivtedCoordinate;
    }
}
