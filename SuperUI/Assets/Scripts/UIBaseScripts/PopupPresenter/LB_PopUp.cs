using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LB_PopUp : LB_UIObject, LB_Poolable
{
    public LB_Button OkButton;
    public LB_Button CancelButton;
    public LB_Button CloseButton;
    public TextMeshProUGUI PopUpTitleContainer;
    public TextMeshProUGUI PopUpContentContainer;

    public void OnActivated()
    {
        PlayActivateAnimation();
    }

    public void OnDeactivate()
    {
        PlayDeactivateAnimation();
    }

    public void Initialize()
    {
        PreInit();
        Init();
    }

    public void ApplySettings(object info)
    {
        var data = (PopUpSettings)info;
        SetPopUpBackgroundImage(data.Type);
        SetPopupInfoImage(data.Type);
        AddOkeyButton(data.hasOkeyButton);
        AddCloseButton(data.hasCloseButton);
        AddCancelButton(data.hasCancelButton);
        SetPopUpTitle(data.Title);
        SetPopUpContent(data.Content);

        PlayActivateAnimation();
    }

    private void SetPopUpContent(string content)
    {
        PopUpContentContainer.text = content;
    }

    private void SetPopUpTitle(string title)
    {
        PopUpTitleContainer.text = title;
    }

    private void AddCancelButton(bool hasCancelButton)
    {
        CancelButton.gameObject.SetActive(hasCancelButton);
    }

    private void AddCloseButton(bool hasCloseButton)
    {
        CloseButton.gameObject.SetActive(hasCloseButton);
    }

    private void AddOkeyButton(bool hasOkeyButton)
    {
        OkButton.gameObject.SetActive(hasOkeyButton);
    }

    private void SetPopupInfoImage(PopUpType type)
    {
        //get image from popUpSkinData
    }

    private void SetPopUpBackgroundImage(PopUpType type)
    {
        //return popUpSkinData.GetPopUpBackgroundImage(type); 
    }
}
