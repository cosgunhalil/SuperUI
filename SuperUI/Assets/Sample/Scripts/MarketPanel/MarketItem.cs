using LB.SuperUI.BaseComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MarketItem : LB_UIObject
{
    public override void Setup(Vector2 canvasSize)
    {
        //todo move another place (some main component or ...)
        animationTime = .5f;

        activatedCoordinate = objectRectTransform.anchoredPosition;
        deactivtedCoordinate = new Vector2(
            -canvasSize.x * .5f - objectRectTransform.sizeDelta.x * .5f, 0);

        objectRectTransform.anchoredPosition = deactivtedCoordinate;
    }

    public override void PlayActivateAnimation()
    {
        objectRectTransform.DOAnchorPos(activatedCoordinate, animationTime).SetEase(Ease.InOutSine);
    }

    public override void PlayDeactivateAnimation()
    {
        objectRectTransform.DOAnchorPos(deactivtedCoordinate, animationTime).SetEase(Ease.InOutSine);
    }
}
