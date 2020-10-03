
namespace LB.SuperUI.Sample
{
    using LB.SuperUI.BaseComponents;
    using LB.SuperUI.Helpers.Observer;
    using UnityEngine;

    public class MainMenuPanel : LB_UIPanel, IObserver<UIStateChangedEventArgs>
    {
        [SerializeField]
        private LB_Button playButton;

        public override void Setup()
        {
            Debug.Log(gameObject.name + "Setup()");
            
        }

        public void Notify(object sender, UIStateChangedEventArgs e)
        {
            switch (e.State)
            {
                case UIState.MAIN:
                    panelCanvas.enabled = true;
                    break;
                case UIState.GAME_OVER:
                case UIState.IN_GAME:
                case UIState.CHARACTERS:
                default:
                    panelCanvas.enabled = false;
                    break;
            }
        }

        protected override void RegisterEvents()
        {
            uiManager.Register(this);

            if (playButton != null) 
            {
                playButton.OnPointerDownEvent += PlayButton_OnPointerDownEvent;
            }
        }

        private void PlayButton_OnPointerDownEvent()
        {
            uiManager.AddEvent(new UIStateChangedEventArgs() { State = UIState.OPPONENT_SEARCH });
        }

        protected override void UnRegisterEvents()
        {
            uiManager.UnRegister(this);

            if (playButton != null)
            {
                playButton.OnPointerDownEvent -= PlayButton_OnPointerDownEvent;
            }
        }
    }
}


