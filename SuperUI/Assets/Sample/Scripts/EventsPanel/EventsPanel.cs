using LB.SuperUI.BaseComponents;
using LB.SuperUI.Helpers.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsPanel : LB_UIPanel, IObserver<UIStateChangedEventArgs>
{
    public void Notify(object sender, UIStateChangedEventArgs e)
    {
        panelCanvas.enabled = e.State == UIState.EVENTS;
    }
    public override void Setup()
    {
        Debug.Log(gameObject.name + "Setup()");
    }

    protected override void RegisterEvents()
    {
        uiManager.Register(this);
    }

    protected override void UnRegisterEvents()
    {
        uiManager.UnRegister(this);
    }
}
