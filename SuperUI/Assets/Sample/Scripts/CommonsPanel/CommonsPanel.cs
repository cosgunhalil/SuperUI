

namespace LB.SuperUI.Sample
{
    using LB.SuperUI.BaseComponents;
    using LB.SuperUI.Helpers.Observer;
    using UnityEngine;

    public class CommonsPanel : LB_UIPanel, IObserver<UIStateChangedEventArgs>
    {
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

        public void Notify(object sender, UIStateChangedEventArgs e)
        {
            switch (e.State)
            {
                case UIState.IN_GAME:
                case UIState.MAIN:
                case UIState.GAME_OVER:
                case UIState.CHARACTERS:
                default:
                    panelCanvas.enabled = true;
                    break;
            }
        }

        protected override void RegisterEvents()
        {
            uiManager.Register(this);

            if (mainMenuButton != null) 
            {
                mainMenuButton.OnPointerDownEvent += MainMenuButton_OnPointerDownEvent;
            }
            
            if (charactersButton != null) 
            {
                charactersButton.OnPointerDownEvent += CharactersButton_OnPointerDownEvent;
            }
        }

        private void CharactersButton_OnPointerDownEvent()
        {
            uiManager.AddEvent(new UIStateChangedEventArgs() { State = UIState.IN_GAME });
        }

        private void MainMenuButton_OnPointerDownEvent()
        {
            uiManager.AddEvent(new UIStateChangedEventArgs() { State = UIState.MAIN });
        }

        protected override void UnRegisterEvents()
        {
            uiManager.UnRegister(this);
            if (mainMenuButton != null) 
            {
                mainMenuButton.OnPointerDownEvent -= MainMenuButton_OnPointerDownEvent;
            }
            
        }
    }
}

