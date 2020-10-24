using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using LB.SuperUI.Animation;
using LB.SuperUI.BaseComponents;
using UnityEngine;

public class ChestContainer : LB_UIObject
{
    public override void Setup(Vector2 canvasSize)
    {
        AddMovementAnimationComponent(canvasSize);
        AddScaleAnimationComponent();
    }

    private void AddMovementAnimationComponent(Vector2 canvasSize)
    {
        LB_MoveAnimationComponent moveAnimation = new LB_MoveAnimationComponent(objectRectTransform, .5f);
        moveAnimation.ActivatedCoordinate = objectRectTransform.anchoredPosition;
        moveAnimation.DeactivatedCoordinate = new Vector2(
            -canvasSize.x * .5f - objectRectTransform.sizeDelta.x * .5f,
            objectRectTransform.anchoredPosition.y);

        objectRectTransform.anchoredPosition = moveAnimation.DeactivatedCoordinate;

        animationComponents.Add(moveAnimation);
    }

    private void AddScaleAnimationComponent()
    {
        LB_ScaleAnimationComponent scaleAnimationComponent = new LB_ScaleAnimationComponent(objectRectTransform, .5f)
        {
            ActivatedScale = 1,
            DeactivatedScale = 0,
            AnimationEase = Ease.InOutBounce
        };

        objectRectTransform.localScale = new Vector3(scaleAnimationComponent.DeactivatedScale, 
            scaleAnimationComponent.DeactivatedScale, 
            scaleAnimationComponent.DeactivatedScale);

        animationComponents.Add(scaleAnimationComponent);
    }
}
