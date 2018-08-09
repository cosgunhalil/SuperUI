using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_UIManager : MonoBehaviour {

    private static LB_UIManager instance;
    public static LB_UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (LB_UIManager)FindObjectOfType(typeof(LB_UIManager));
                instance.Init();
            }

            return instance;
        }
    }

    public delegate void ActivatePanelDelegate(LB_UIEventArgs eventArgs);
    public event ActivatePanelDelegate PanelActivated;

    protected Dictionary<PanelType, LB_UIPanel> panelsByPanelType;

    public PanelType CurrentPanel;
    protected LB_UIPanel _lastActivePanel;

    protected bool _isPopUpActivate;

    public virtual void Init()
    {

    }

    public virtual void InitPanels()
    {
        
    }

    public virtual void ActivatePanel(LB_UIEventArgs eventArgs)
    {
        if (PanelActivated != null)
        {
            PanelActivated(eventArgs);
        }
    }

    public virtual void DeactivatePanel(PanelType panel)
    {

    }

    public virtual void DeactivateLastActivePanel()
    {

    }

    public virtual void PopUpActivated(bool isActivated)
    {

    }

    public virtual void ShowPopUpMessage(string message)
    {

    }
}
