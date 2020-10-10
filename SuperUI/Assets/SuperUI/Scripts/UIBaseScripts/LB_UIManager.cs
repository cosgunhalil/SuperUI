
namespace LB.SuperUI.BaseComponents 
{
    using System;
    using System.Collections.Generic;
    using LB.SuperUI.Helpers.Observer;
    using UnityEngine;

    public class LB_UIManager : MonoBehaviour, ISubject<UIStateChangedEventArgs>
    {
        public event EventHandler<UIStateChangedEventArgs> UIStateChanged;
        [SerializeField]
        private LB_UIPanel[] panels;

        public void Awake()
        {
            for (int i = 0; i < panels.Length; ++i)
            {
                panels[i].InjectDependency(this);
                panels[i].PreInit();
            }
        }

        public void Start()
        {
            for (int i = 0; i < panels.Length; ++i)
            {
                panels[i].Init();
            }
        }

        public void OnDestroy()
        {
            for (int i = 0; i < panels.Length; ++i)
            {
                panels[i].OnDestroyCalled();
            }
        }

        public void Register(Helpers.Observer.IObserver<UIStateChangedEventArgs> observer)
        {
            UIStateChanged += observer.Notify;
        }

        public void UnRegister(Helpers.Observer.IObserver<UIStateChangedEventArgs> observer)
        {
            UIStateChanged -= observer.Notify;
        }

        public void AddEvent(UIStateChangedEventArgs eventArgs)
        {
            UIStateChanged?.Invoke(this, eventArgs);
        }

    }

}

