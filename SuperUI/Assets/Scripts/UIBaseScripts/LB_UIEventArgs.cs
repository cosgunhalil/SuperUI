using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_UIEventArgs {

    public PanelType Type;
    public object[] ExtraInfo;

    public LB_UIEventArgs(PanelType type, object[] extraInfo = null)
    {
        this.Type = type;
        this.ExtraInfo = extraInfo;
    }
}
