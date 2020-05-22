

namespace LB.SuperUI.Sample
{
    using LB.SuperUI.BaseComponents;
    using UnityEngine;

    public class CommonsPanel : LB_UIPanel
    {
        public override void Init()
        {
            base.Init();
            Debug.Log(gameObject.name + " init");
        }
    }
}

