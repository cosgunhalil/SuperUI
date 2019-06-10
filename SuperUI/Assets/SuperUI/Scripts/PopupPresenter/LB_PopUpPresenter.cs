
namespace LB.SuperUI.PopUpSystem 
{
    using System.Collections.Generic;
    using UnityEngine;
    using LB.SuperUI.BaseComponents;

    [RequireComponent(typeof(LB_PopUpFabric))]
    public class LB_PopUpPresenter : LB_UIPanel
    {
        private LB_PopUpFabric popUpFabric;
        private List<LB_PopUp> popUpQueue;
        private LB_PopUp activePopup;

        public override void PreInit()
        {
            base.PreInit();
            popUpQueue = new List<LB_PopUp>();
            popUpFabric = GetComponent<LB_PopUpFabric>();
        }

        public override void Init()
        {
            base.Init();
            popUpFabric.InitializeFabric();
        }

        public LB_PopUp PresentPopUp(PopUpSettings popUpSettings)
        {
            var popUp = popUpFabric.GetPopUp(popUpSettings);
            popUp.transform.SetParent(gameObject.transform);
            popUp.SetAnchorPosition(new Vector2(0, 0));
            panelCanvas.enabled = true;

            AddPopUpToQueue(ref popUp);
            SetActivePopUp();

            Activate();

            return activePopup;
        }

        private void AddPopUpToQueue(ref LB_PopUp popUp)
        {
            popUpQueue.Add(popUp);
        }

        private void SetActivePopUp()
        {
            if (activePopup != null)
            {
                activePopup.OnPopUpResponseComeEvent -= ActivePopup_OnPopUpResponseCome;
            }

            activePopup = popUpQueue[popUpQueue.Count - 1];

            activePopup.OnPopUpResponseComeEvent += ActivePopup_OnPopUpResponseCome;
        }

        private void Awake()
        {
            PreInit();
        }

        private void Start()
        {
            Init();
        }

        void Popup_OnOkButtonClicked()
        {

        }

        void Popup_OnCloseButtonClicked()
        {
            popUpFabric.PopUpRecycled(activePopup);
            popUpQueue.Remove(activePopup);

            activePopup.OnPopUpResponseComeEvent -= ActivePopup_OnPopUpResponseCome;

            if (popUpQueue.Count > 0)
            {
                SetActivePopUp();
            }
            else
            {
                Deactivate();
            }

        }

        void Popup_OnCancelButtonClicked()
        {

        }

        void ActivePopup_OnPopUpResponseCome(PopUpResponseType responseType)
        {
            switch (responseType)
            {
                case PopUpResponseType.OkButtonClicked:
                    Popup_OnOkButtonClicked();
                    break;
                case PopUpResponseType.CloseButtonClicked:
                    Popup_OnCloseButtonClicked();
                    break;
                case PopUpResponseType.CancelButtonClicked:
                    Popup_OnCancelButtonClicked();
                    break;
                default:
                    break;
            }
        }

    }

}
