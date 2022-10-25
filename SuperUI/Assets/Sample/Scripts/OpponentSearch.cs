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
           
        }

        public void Notify(object sender, UIStateChangedEventArgs e)
        {
            
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
