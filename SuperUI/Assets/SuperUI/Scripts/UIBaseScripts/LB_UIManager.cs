
namespace LB.SuperUI.BaseComponents 
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using LB.SuperUI.Helpers.Observer;
    using LB.SuperUI.Sample;
    using UnityEngine;

    public class LB_UIManager : MonoBehaviour, ISubject<UIStateChangedEventArgs>
    {
        public event EventHandler<UIStateChangedEventArgs> UIStateChanged;
        private LB_UIPanel[] panels;

        [SerializeField] 
        private MainMenuPanel mainMenuPanel;
        [SerializeField] 
        private CommonsPanel commonsPanel;
        [SerializeField] 
        private CharactersPanel charactersPanel;
        [SerializeField] 
        private EventsPanel eventsPanel;
        [SerializeField] 
        private MarketPanel marketPanel;

        private LB_UIPanel activeCanvas = null;

        public void Awake()
        {
            panels = new LB_UIPanel[(int)UIState.COUNT];
            panels[(int)UIState.MAIN_MENU] = mainMenuPanel;
            panels[(int)UIState.COMMONS] = commonsPanel;
            panels[(int)UIState.CHARACTERS] = charactersPanel;
            panels[(int)UIState.EVENTS] = eventsPanel;
            panels[(int)UIState.MARKET] = marketPanel;

            for (int i = 0; i < panels.Length; ++i)
            {
                panels[i].InjectUIManagerDependency(this);
                panels[i].PreInit();
            }
        }

        public void Start()
        {
            for (int i = 0; i < panels.Length; ++i)
            {
                panels[i].Init();
                panels[i].LateInit();
            }
        }

        public void OnDestroy()
        {
            for (int i = 0; i < panels.Length; ++i)
            {
                panels[i].OnDestroyCalled();
            }
        }

        public void EnableCanvas(UIState canvasType)
        {

            LB_UIPanel targetCanvas = null;
            switch (canvasType)
            {
                case UIState.CHARACTERS:
                    targetCanvas = charactersPanel;
                    break;
                case UIState.MAIN_MENU:
                    targetCanvas = mainMenuPanel;
                    break;
                case UIState.MARKET:
                    targetCanvas = marketPanel;
                    break;
                case UIState.EVENTS:
                    targetCanvas = eventsPanel;
                    break;
                case UIState.COMMONS:
                case UIState.COUNT:
                    targetCanvas = commonsPanel;
                    break;
            }

            if (activeCanvas == null)
            {
                activeCanvas = targetCanvas;
                activeCanvas.Activate();
                return;
            }

            StopCoroutine("EnableRequestedCanvas");
            StartCoroutine("EnableRequestedCanvas", canvasType);
        }

        private IEnumerator EnableRequestedCanvas(LB_UIPanel targetCanvas)
        {
            if (activeCanvas != null)
            {
                activeCanvas.Deactivate();
            }

            yield return new WaitForSeconds(.5f);

            activeCanvas = targetCanvas;
            activeCanvas.Activate();
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

