

namespace LB.SuperUI.BaseComponents
{
    using System;

    public class UIStateChangedEventArgs : EventArgs
    {
        public UIState State { get; set; }

        public object ExtraInfo;
    }
}


