

namespace LB.SuperUI.Sample
{
    using LB.SuperUI.BaseComponents;
    using LB.SuperUI.Helpers.Observer;
    using UnityEngine;

    public class CommonsPanel : LB_UIPanel
    {
        //TODO: solve these dependencies. UI Panels must not know each other!..
        [SerializeField]
        private LB_Button mainMenuButton;
        [SerializeField]
        private LB_Button marketButton;
        [SerializeField]
        private LB_Button charactersButton;
        [SerializeField]
        private LB_Button eventsButton;

        public override void Setup()
        {
            Debug.Log(gameObject.name + "Setup");
        }

        protected override void RegisterEvents()
        {
            if (mainMenuButton != null) 
            {
                mainMenuButton.OnPointerDownEvent += MainMenuButton_OnPointerDownEvent;
            }
            
            if (charactersButton != null) 
            {
                charactersButton.OnPointerDownEvent += CharactersButton_OnPointerDownEvent;
            }

            if (marketButton != null) 
            {
                marketButton.OnPointerDownEvent += MarketButton_OnPointerDownEvent;
            }

            if (eventsButton != null) 
            {
                eventsButton.OnPointerDownEvent += EventsButton_OnPointerDownEvent;
            }
        }

        private void MainMenuButton_OnPointerDownEvent()
        {
            //TODO: send MainMenuButton_OnPointerDownEvent
        }
        private void CharactersButton_OnPointerDownEvent()
        {
            //TODO: send CharactersButton_OnPointerDownEvent
        }

        private void MarketButton_OnPointerDownEvent()
        {
            //TODO: send MarketButton_OnPointerDownEvent
        }

        private void EventsButton_OnPointerDownEvent()
        {
            //TODO: send EventsButton_OnPointerDownEvent
        }

        protected override void UnRegisterEvents()
        {
            if (mainMenuButton != null)
            {
                mainMenuButton.OnPointerDownEvent -= MainMenuButton_OnPointerDownEvent;
            }

            if (charactersButton != null)
            {
                charactersButton.OnPointerDownEvent -= CharactersButton_OnPointerDownEvent;
            }

            if (marketButton != null)
            {
                marketButton.OnPointerDownEvent -= MarketButton_OnPointerDownEvent;
            }

            if (eventsButton != null)
            {
                eventsButton.OnPointerDownEvent -= EventsButton_OnPointerDownEvent;
            }
        }
    }
}

