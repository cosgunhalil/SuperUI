using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_UIManager : MonoBehaviour {

    protected Dictionary<PanelType, LB_UIPanel> panelsByPanelType;

    protected PanelType currentPanel;
    protected LB_UIPanel lastActivePanel;

    public virtual void Init()
    {
        LB_UIEventManager.OnPanelActivated += ActivatePanel;
    }

    public virtual void OnDeleted()
    {
        LB_UIEventManager.OnPanelActivated -= ActivatePanel;
    }

    public virtual void InitPanels()
    {
        
    }

    public virtual void ActivatePanel(PanelType panelType)
    {
        
    }

    public virtual void DeactivatePanel(PanelType panel)
    {

    }
}
