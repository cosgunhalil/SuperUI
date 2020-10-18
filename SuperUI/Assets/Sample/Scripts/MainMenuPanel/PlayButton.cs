using LB.SuperUI.BaseComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : LB_Button
{
    public override void Setup(Vector2 canvasSize)
    {
        activatedCoordinate = objectRectTransform.anchoredPosition;
        deactivtedCoordinate = new Vector2(0,
            canvasSize.y * .5f + objectRectTransform.sizeDelta.y * .5f);

        objectRectTransform.anchoredPosition = deactivtedCoordinate;
    }
}
