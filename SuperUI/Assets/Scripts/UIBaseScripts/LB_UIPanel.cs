using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_UIPanel : MonoBehaviour {

    public LB_UIElement[] UIElements;

    protected Canvas PanelCanvas;
    protected RectTransform PanelRectTransform;

    protected float AnimationTime;

    public virtual void Init()
    {
        AnimationTime = .5f;
        PanelCanvas = GetComponent<Canvas>();
        PanelRectTransform = GetComponent<RectTransform>();
    }

    public virtual void Activate()
    {
        PanelCanvas.enabled = true;
        PanelCanvas.sortingOrder = 1;
        StopCoroutine("DeactivateWithAnimation");
        PlayActivateAnimations();
    }

    public virtual void Deactivate()
    {
        StartCoroutine("DeactivateWithAnimation");
    }

    private IEnumerator DeactivateWithAnimation()
    {
        PlayDeactivateAnimations();
        PanelCanvas.sortingOrder = 2;

        yield return new WaitForSeconds(AnimationTime);
        PanelCanvas.sortingOrder = 0;
        PanelCanvas.enabled = false;
    }

    private void InitUIElements()
    {
        for (int i = 0; i < UIElements.Length; i++)
        {
            UIElements[i].Init();
        }
    }

    public void PlayActivateAnimations()
    {
        for (int i = 0; i < UIElements.Length; i++)
        {
            UIElements[i].PlayActivateAnimation(AnimationTime);
        }
    }

    public void PlayDeactivateAnimations()
    {
        for (int i = 0; i < UIElements.Length; i++)
        {
            UIElements[i].PlayDeactivateAnimation();
        }
    }
}
