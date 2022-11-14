namespace VoxelPixel.SampleApp.UI
{
    using LB.SuperUI.BaseComponents;
    using LB.SuperUI.Helpers.Observer;
    using UnityEngine;

    public class MainMenuPanel : LB_UIPanel
    {
        [SerializeField]
        private LB_Button playButton;

        public override void Setup()
        {
            Debug.Log(gameObject.name + "Setup()");
        }

        protected override void RegisterEvents()
        {
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
            if (playButton != null)
            {
                playButton.OnPointerDownEvent -= PlayButton_OnPointerDownEvent;
            }
        }
    }
}


