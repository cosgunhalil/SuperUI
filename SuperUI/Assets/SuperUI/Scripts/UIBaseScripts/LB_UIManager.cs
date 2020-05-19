
namespace LB.SuperUI.BaseComponents 
{
    using System;
    using System.Collections.Generic;
    using LB.SuperUI.Helpers.Observer;
    using UnityEngine;

    public abstract class LB_UIManager : MonoBehaviour, ISubject<UIStateChangedEventArgs>
    {
        public event EventHandler<UIStateChangedEventArgs> UIStateChanged;
        protected List<LB_UIPanel> panels;

        public void Awake()
        {
            for (int i = 0; i < panels.Count; ++i)
            {
                panels[i].PreInit();
            }
        }

        public void Start()
        {
            for (int i = 0; i < panels.Count; ++i)
            {
                panels[i].Init();
            }
        }

        public void OnDestroy()
        {
            for (int i = 0; i < panels.Count; ++i)
            {
                panels[i].OnDestroyCalled();
            }
        }

        public void Attach(Helpers.Observer.IObserver<UIStateChangedEventArgs> observer)
        {
            UIStateChanged += observer.Syncronize;
        }

        public void Detach(Helpers.Observer.IObserver<UIStateChangedEventArgs> observer)
        {
            UIStateChanged -= observer.Syncronize;
        }
    }

}

