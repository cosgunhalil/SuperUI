using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_UIEvent {

    public PanelType Type;
    public object[] ExtraInfo;

    public LB_UIEvent(PanelType type, object[] extraInfo = null)
    {
        this.Type = type;
        this.ExtraInfo = extraInfo;
    }
}
