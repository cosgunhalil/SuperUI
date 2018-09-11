using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_UIElement : MonoBehaviour {

    protected RectTransform UIElementRectTransform;
    protected Vector2 ActivatedCoordinate;
    protected Vector2 DeactivtedCoordinate;

    public virtual void Init()
    {
        UIElementRectTransform = GetComponent<RectTransform>();
    }

    public virtual void PlayActivateAnimation()
    {

    }

    public virtual void PlayActivateAnimation(float delay)
    {

    }

    public virtual void PlayDeactivateAnimation()
    {

    }

    public virtual void PlayDeactivateAnimation(float delay)
    {

    }

    public virtual void PlaySelectionAnimation()
    {

    }

    public virtual void PlayUnselectAnimation()
    {

    }

    public virtual void SetSize(Vector2 size)
    {
        
    }

    public virtual void CalculateCoordinates()
    {

    }

    public virtual void CalculateCoordinates(float canvasWidth)
    {

    }

    public virtual void CalculateCoordinates(Vector2 screenSize)
    {

    }

    public virtual void SetPosition(float width)
    {

    }

    public void SetAnchorMax(Vector2 anchorMax)
    {
        if (UIElementRectTransform != null)
        {
            UIElementRectTransform.anchorMax = anchorMax;
        }
    }

    public void SetAnchorMin(Vector2 anchorMin)
    {
        if (UIElementRectTransform != null)
        {
            UIElementRectTransform.anchorMin = anchorMin;
        }
    }

    public void SetAnchorPosition(Vector2 position)
    {
        if (UIElementRectTransform != null)
        {
            UIElementRectTransform.anchoredPosition = position;
        }
    }

    public RectTransform GetRectTransform()
    {
        if (UIElementRectTransform == null)
        {
            UIElementRectTransform = GetComponent<RectTransform>();
        }

        return UIElementRectTransform;
    }

    public virtual void CalculateSize(Vector2 screenSize)
    {

    }

    public virtual void StartIdleAnimation()
    {

    }

    public virtual void StopIdleAnimation()
    {

    }
}
