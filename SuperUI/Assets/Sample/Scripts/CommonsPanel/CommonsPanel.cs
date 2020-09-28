

namespace LB.SuperUI.Sample
{
    using LB.SuperUI.BaseComponents;
    using LB.SuperUI.Helpers.Observer;
    using UnityEngine;

    public class CommonsPanel : LB_UIPanel, IObserver<UIStateChangedEventArgs>
    {
        public override void Setup()
        {
            Debug.Log(gameObject.name + "Setup");
        }

        public void Notify(object sender, UIStateChangedEventArgs e)
        {
            switch (e.State)
            {
                case UIState.IN_GAME:
                    panelCanvas.enabled = false;
                    break;
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
        }

        protected override void UnRegisterEvents()
        {
            uiManager.UnRegister(this);
        }
    }
}

