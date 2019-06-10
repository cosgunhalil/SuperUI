
namespace LB.SuperUI.BaseComponents 
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class LB_UIManager : MonoBehaviour
    {

        protected Dictionary<PanelType, LB_UIPanel> panelsByPanelType;

        protected PanelType currentPanel;
        protected LB_UIPanel lastActivePanel;

        public void Awake()
        {
            SetupPanels();
            CallPanelsPreInits();
        }

        public void Start()
        {
            CallPanelsInits();
            CallPanelsLateInits();
        }

        public void OnDestroy()
        {

        }

        public abstract void SetupPanels();

        private void CallPanelsPreInits()
        {
            foreach (var panel in panelsByPanelType)
            {
                panel.Value.PreInit();
            }

        }

        private void CallPanelsInits()
        {
            foreach (var panel in panelsByPanelType)
            {
                panel.Value.Init();
            }
        }

        private void CallPanelsLateInits()
        {
            foreach (var panel in panelsByPanelType)
            {
                panel.Value.LateInit();
            }
        }

        public void ActivatePanel(PanelType panelType)
        {
            if (panelsByPanelType.ContainsKey(panelType))
            {
                if (lastActivePanel != null)
                {
                    lastActivePanel.Deactivate();
                }

                lastActivePanel = panelsByPanelType[panelType];
                lastActivePanel.Activate();
                LB_UIEventManager.Instance.SetPanelActivate(panelType);
            }
        }

        public void DeactivatePanel(PanelType panel)
        {

        }
    }

}

