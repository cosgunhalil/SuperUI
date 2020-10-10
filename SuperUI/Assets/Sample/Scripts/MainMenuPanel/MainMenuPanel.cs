
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
            panelCanvas.enabled = e.State == UIState.MAIN_MENU;
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
            //Todo send onclick event of play button
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


