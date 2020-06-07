using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using LB.SuperUI.BaseComponents;
using UnityEngine;

public class ChestContainer : LB_UIObject
{
    private Vector2 startPosition;
    private Vector2 targetPosition;

    public override void Setup(Vector2 canvasSize)
    {
        Debug.Log("<color=green>" + gameObject.name + " Setup()</color>");

        startPosition = objectRectTransform.anchoredPosition;
        targetPosition = new Vector2(
            -canvasSize.x * .5f - objectRectTransform.sizeDelta.x * .5f,
            objectRectTransform.anchoredPosition.y);

    }

    //todo refactor - code duplication
    public override void PlayActivateAnimation()
    {
        if (activationTween != null)
        {
            activationTween.Kill();
        }

        activationTween = objectRectTransform.DOAnchorPos(targetPosition, .5f).SetEase(Ease.InOutSine);
    }

    public override void PlayDeactivateAnimation()
    {
        if (deactivationTween != null)
        {
            deactivationTween.Kill();
        }

        deactivationTween = objectRectTransform.DOAnchorPos(startPosition, .5f);
    }

    //todo delete
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayActivateAnimation();
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            PlayDeactivateAnimation();
        }
    }
}
