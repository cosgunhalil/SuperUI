namespace LB.SuperUI.Sample
{

    using LB.SuperUI.BaseComponents;
    using LB.SuperUI.Helpers.Observer;
    using UnityEngine;

public class OpponentSearch : LB_UIPanel, IObserver<UIStateChangedEventArgs>
{

        public override void Setup()
        {
            Debug.Log(gameObject.name + "Setup()");
        }

        public override void LateInit()
        {
            uiManager.AddEvent(new UIStateChangedEventArgs() { State = UIState.OPPONENT_SEARCH });
        }

        public void Notify(object sender, UIStateChangedEventArgs e)
        {
            if (e.State == UIState.OPPONENT_SEARCH )
            {
                Activate();
            }
            else
            {
                Deactivate();
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
