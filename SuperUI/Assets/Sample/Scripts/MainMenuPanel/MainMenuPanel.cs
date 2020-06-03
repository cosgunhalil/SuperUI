
namespace LB.SuperUI.Sample
{
    using LB.SuperUI.BaseComponents;
    using LB.SuperUI.Helpers.Observer;
    using UnityEngine;

    public class MainMenuPanel : LB_UIPanel, IObserver<UIStateChangedEventArgs>
    {
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
            CentralEventManager.Instance.GetUIStateEventManager().Register(this);
        }

        protected override void UnRegisterEvents()
        {
            CentralEventManager.Instance.GetUIStateEventManager().UnRegister(this);
        }
    }
}


