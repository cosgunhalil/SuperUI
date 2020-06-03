
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

        public void Register(Helpers.Observer.IObserver<UIStateChangedEventArgs> observer)
        {
            UIStateChanged += observer.Notify;
        }

        public void UnRegister(Helpers.Observer.IObserver<UIStateChangedEventArgs> observer)
        {
            UIStateChanged -= observer.Notify;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                CentralEventManager.Instance.GetUIStateEventManager().
                    AddEvent(new UIStateChangedEventArgs() { State = UIState.MAIN });
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                CentralEventManager.Instance.GetUIStateEventManager().AddEvent(new UIStateChangedEventArgs() { State = UIState.IN_GAME});
            }
        }

    }

}

