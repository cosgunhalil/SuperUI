
namespace LB.SuperUI.BaseComponents 
{
    public class LB_UIEvent
    {

        public UIState Type;
        public object[] ExtraInfo;

        public LB_UIEvent(UIState type, object[] extraInfo = null)
        {
            this.Type = type;
            this.ExtraInfo = extraInfo;
        }
    }
}


