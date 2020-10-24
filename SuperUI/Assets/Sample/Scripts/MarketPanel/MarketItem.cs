using LB.SuperUI.BaseComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using LB.SuperUI.Animation;

public class MarketItem : LB_UIObject
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
            DeactivatedCoordinate = new Vector2(
                -canvasSize.x * .5f - objectRectTransform.sizeDelta.x * .5f, 0)

        };

        animationComponents.Add(moveAnimationComponent);

        objectRectTransform.anchoredPosition = moveAnimationComponent.DeactivatedCoordinate;
    }
}
