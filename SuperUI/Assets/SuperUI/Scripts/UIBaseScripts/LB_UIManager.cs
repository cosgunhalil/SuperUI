
namespace LB.SuperUI.BaseComponents 
{
    using System;
    using System.Collections.Generic;
    using LB.SuperUI.Helpers.Observer;
    using UnityEngine;

    public class LB_UIManager : MonoBehaviour, ISubject<UIStateChangedEventArgs>
    {
        public event EventHandler<UIStateChangedEventArgs> UIStateChanged;
        private LB_UIPanel[] panels;

        public void Awake()
        {
            FindAllPanels();

            for (int i = 0; i < panels.Length; ++i)
            {
                panels[i].PreInit();
            }
        }

        private void FindAllPanels()
        {
            panels = FindObjectsOfType<LB_UIPanel>();
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

