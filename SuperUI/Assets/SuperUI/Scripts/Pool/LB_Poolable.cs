using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public interface LB_Poolable
{
    void OnActivated();
    void OnDeactivate();
    void Initialize();
    void ApplySettings(object info);
}
