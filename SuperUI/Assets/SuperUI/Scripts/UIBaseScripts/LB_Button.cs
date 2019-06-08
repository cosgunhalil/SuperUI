using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG;
using DG.Tweening;

[RequireComponent(typeof(Button))]
public class LB_Button : LB_UIObject {

    public delegate void MessageAction();
    public event MessageAction OnPointerDownEvent;
    public event MessageAction OnPointerUpEvent;
    public event MessageAction OnPointerEnterEvent;
    public event MessageAction OnPointerExitEvent;

    protected float localScaleTemp;
    protected Button button;
    private EventTrigger eventTrigger;

    private const float touchAnimationTime = .05f;
    private const float sizeDivisionConst = .9f;

    public override void Init()
    {
        base.Init();
        button = GetComponent<Button>();
        localScaleTemp = transform.localScale.x;

        SetEventTrigger();
        SetupButtonActions();
    }

    private void SetEventTrigger()
    {
        eventTrigger = gameObject.GetComponent<EventTrigger>();
        if (eventTrigger == null)
        {
            eventTrigger = gameObject.AddComponent<EventTrigger>();
        }
    }

    private void SetupButtonActions()
    {
        AddActionToButton(EventTriggerType.PointerEnter, OnPointerEnter);
        AddActionToButton(EventTriggerType.PointerExit, OnPointerExit);
        AddActionToButton(EventTriggerType.PointerDown, OnPointerDown);
        AddActionToButton(EventTriggerType.PointerUp, OnPointerUp);
    }

    protected virtual void OnPointerDown() 
    {
        if(OnPointerDownEvent != null) 
        {
            OnPointerDownEvent();
        }
    }

    protected virtual void OnPointerUp() 
    {
        if(OnPointerUpEvent != null) 
        {
            OnPointerUpEvent();
        }
    }

    protected virtual void OnPointerEnter() 
    { 
        if(OnPointerEnterEvent != null) 
        {
            OnPointerEnterEvent();
        }
    }

    protected virtual void OnPointerExit() 
    { 
        if(OnPointerExitEvent != null) 
        {
            OnPointerExitEvent();
        }
    }

    private void AddActionToButton(EventTriggerType eventTriggerType, Action action)
    {
        var entry = new EventTrigger.Entry
        {
            eventID = eventTriggerType
        };
        entry.callback.AddListener((e) => { action(); });
        eventTrigger.triggers.Add(entry);
    }

}
