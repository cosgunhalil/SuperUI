using System.Collections;
using System.Collections.Generic;
using LB.SuperUI.BaseComponents;
using LB.SuperUI.Helpers.Observer;
using UnityEngine;

public class UIStateEventManager : ISubject<UIStateChangedEventArgs>
{
    private List<IObserver<UIStateChangedEventArgs>> observers = new List<IObserver<UIStateChangedEventArgs>>();
    
    public void Register(IObserver<UIStateChangedEventArgs> observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void UnRegister(IObserver<UIStateChangedEventArgs> observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    public void AddEvent(UIStateChangedEventArgs eventArgs)
    {
        for (int i = 0; i < observers.Count; i++)
        {
            observers[i].Notify(this, eventArgs);
        }
    }
}
