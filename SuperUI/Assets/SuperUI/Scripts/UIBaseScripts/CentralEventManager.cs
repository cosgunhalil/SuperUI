using System;
using System.Collections;
using System.Collections.Generic;
using LB.SuperUI.BaseComponents;
using LB.SuperUI.Helpers.Observer;
using UnityEngine;

public class CentralEventManager
{
    private static readonly CentralEventManager instance = new CentralEventManager();

    private UIStateEventManager uIStateEventManager = new UIStateEventManager();

    static CentralEventManager()
    {
        
    }

    private CentralEventManager()
    {
        
    }

    public static CentralEventManager Instance
    {
        get
        {
            return instance;
        }
    }

    public UIStateEventManager GetUIStateEventManager()
    {
        return uIStateEventManager;
    }
}
