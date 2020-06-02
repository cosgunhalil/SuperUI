using System.Collections;
using System.Collections.Generic;
using LB.SuperUI.BaseComponents;
using LB.SuperUI.Helpers.Observer;
using UnityEngine;

public class UIStateEventManager : ISubject<UIStateChangedEventArgs>
{
    private List<IObserver<UIStateChangedEventArgs>> observers;
    
    public void Attach(IObserver<UIStateChangedEventArgs> observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void Detach(IObserver<UIStateChangedEventArgs> observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }
}
