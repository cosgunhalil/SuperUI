using DG.Tweening;
using LB.SuperUI.Animation;
using LB.SuperUI.BaseComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersMainContainer : LB_UIObject
{
    public override void Setup(Vector2 canvasSize)
    {
        CreateMoveAnimationComponent(canvasSize);
    }

    private void CreateMoveAnimationComponent(Vector2 canvasSize)
    {
        LB_MoveAnimationComponent moveAnimationComponent = new LB_MoveAnimationComponent(objectRectTransform, .5f)
        {
            AnimationEase = Ease.InOutSine,
            ActivatedCoordinate = objectRectTransform.anchoredPosition,
            DeactivatedCoordinate = new Vector2(
            canvasSize.x * .5f + objectRectTransform.sizeDelta.x * .5f,
            objectRectTransform.anchoredPosition.y)
        };

        animationComponents.Add(moveAnimationComponent);

        objectRectTransform.anchoredPosition = moveAnimationComponent.DeactivatedCoordinate;
    }
}
