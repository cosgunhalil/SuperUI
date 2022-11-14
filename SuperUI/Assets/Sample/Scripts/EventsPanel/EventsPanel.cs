namespace VoxelPixel.SampleApp.UI 
{
    using LB.SuperUI.BaseComponents;
    using UnityEngine;

    public class EventsPanel : LB_UIPanel
    {
        public override void Setup()
        {
            Debug.Log(gameObject.name + "Setup()");
        }
    }
}
