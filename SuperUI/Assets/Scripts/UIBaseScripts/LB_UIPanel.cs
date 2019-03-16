using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_UIPanel : MonoBehaviour {

    public LB_UIObject[] UIObjects;

    protected PanelType panelType;
    protected Canvas panelCanvas;
    protected RectTransform panelRectTransform;

    protected float animationTime;

    public virtual void PreInit()
    {
        PreInitUIObjects();
    }

    public virtual void Init()
    {
        animationTime = 0f;//todo animate
        panelCanvas = GetComponent<Canvas>();
        panelRectTransform = GetComponent<RectTransform>();

        InitUIObjects();
    }

    public virtual void LateInit()
    {
        LateInitUIObjects();
    }

    public virtual void Activate()
    {
        panelCanvas.enabled = true;
        panelCanvas.sortingOrder = 1;
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
        panelCanvas.sortingOrder = 2;

        yield return new WaitForSeconds(animationTime);
        panelCanvas.sortingOrder = 0;
        panelCanvas.enabled = false;
    }

    private void PreInitUIObjects()
    {
        for (int i = 0; i < UIObjects.Length; i++)
        {
            UIObjects[i].PreInit();
        }
    }

    private void InitUIObjects()
    {
        for (int i = 0; i < UIObjects.Length; i++)
        {
            UIObjects[i].Init();
        }
    }

    private void LateInitUIObjects()
    {
        for (int i = 0; i < UIObjects.Length; i++)
        {
            UIObjects[i].LateInit();
        }
    }

    public void PlayActivateAnimations()
    {
        for (int i = 0; i < UIObjects.Length; i++)
        {
            UIObjects[i].PlayActivateAnimation();
        }
    }

    public void PlayDeactivateAnimations()
    {
        for (int i = 0; i < UIObjects.Length; i++)
        {
            UIObjects[i].PlayDeactivateAnimation();
        }
    }
}
