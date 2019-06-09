using System.Collections;
using System.Collections.Generic;
using LB.SuperUI.PopUpSystem;
using UnityEngine;

public class PopUpSystemSample : MonoBehaviour
{
    public LB_PopUpPresenter PopUpPresenter;
    private int popUpNamePrefixInt;

    private LB_PopUp activePopup;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            popUpNamePrefixInt++;
            var popUpSettings = new PopUpSettings
            {
                Type = PopUpType.Warning,
                hasOkeyButton = true,
                hasCloseButton = true,
                hasCancelButton = true,
                Title = "Test-Pop-Up-" + popUpNamePrefixInt,
                Content = "lorem ipsum dolar sit amed dans eder halay çeker."
            };

            activePopup = PopUpPresenter.PresentPopUp(popUpSettings);
            activePopup.OnPopUpResponseComeEvent += ActivePopup_OnPopUpResponseCome;
        }
    }

    void ActivePopup_OnPopUpResponseCome(PopUpResponseType responseType)
    {
        switch (responseType)
        {
            case PopUpResponseType.OkButtonClicked:
                Debug.Log("OK BUTTON CLICKED!!!!");
                break;
            case PopUpResponseType.CloseButtonClicked:
                Debug.Log("CLOSE BUTTON CLICKED!!!!");
                break;
            case PopUpResponseType.CancelButtonClicked:
                Debug.Log("CANCEL BUTTON CLICKED!!!!");
                break;
            default:
                break;
        }
    }

}
