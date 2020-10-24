using LB.SuperUI.Animation;
using LB.SuperUI.BaseComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : LB_Button
{
    public override void Setup(Vector2 canvasSize)
    {
        CreateMoveAnimationComponent(canvasSize);
    }

    private void CreateMoveAnimationComponent(Vector2 canvasSize)
    {
        LB_MoveAnimationComponent moveAnimationComponent = new LB_MoveAnimationComponent(objectRectTransform, .5f)
        {
            AnimationEase = DG.Tweening.Ease.InOutSine,
            ActivatedCoordinate = objectRectTransform.anchoredPosition,
            DeactivatedCoordinate = new Vector2(0,
            canvasSize.y * .5f + objectRectTransform.sizeDelta.y * .5f)

        };

        animationComponents.Add(moveAnimationComponent);

        objectRectTransform.anchoredPosition = moveAnimationComponent.DeactivatedCoordinate;
    }
}
