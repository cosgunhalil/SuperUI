
namespace LB.SuperUI.BaseComponents 
{
    public class LB_UIEventManager
    {

        public delegate void PanelActivatedDelegate(PanelType panelType);
        public static PanelActivatedDelegate OnPanelActivated;

        private static readonly LB_UIEventManager instance = new LB_UIEventManager();

        static LB_UIEventManager()
        {

        }

        private LB_UIEventManager()
        {

        }

        public static LB_UIEventManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void SetPanelActivate(PanelType panelType)
        {
            if (OnPanelActivated != null)
            {
                OnPanelActivated(panelType);
            }
        }
    }

}

