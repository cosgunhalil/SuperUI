using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LB_PopUp : LB_UIObject, LB_Poolable
{

    List<MessageAction> delegates = new List<MessageAction>();

    public TextMeshProUGUI PopUpTitleContainer;
    public TextMeshProUGUI PopUpContentContainer;

    public delegate void MessageAction(PopUpResponseType responseType);

    private event MessageAction OnPopUpResponseCome;

    public event MessageAction OnPopUpResponseComeEvent 
    {
        add 
        {
            OnPopUpResponseCome += value;
            delegates.Add(value);
        }

        remove 
        {
            OnPopUpResponseCome -= value;
            delegates.Remove(value);
        }
    }

    [SerializeField]
    protected LB_Button OkButton;
    [SerializeField]
    protected LB_Button CancelButton;
    [SerializeField]
    protected LB_Button CloseButton;

    public void OnActivated()
    {
        gameObject.SetActive(true);
        PlayActivateAnimation();
    }

    public void OnDeactivate()
    {
        RemoveAllEvents();
        PlayDeactivateAnimation();
        gameObject.SetActive(false);
    }

    public void Initialize()
    {
        PreInit();
        Init();
        SetupButtons();
    }

    private void SetupButtons()
    {
        OkButton.Init();
        CloseButton.Init();
        CancelButton.Init();

        OkButton.OnPointerUpEvent += OkButton_OnPointerUpEvent;
        CloseButton.OnPointerUpEvent += CloseButton_OnPointerUpEvent;
        CancelButton.OnPointerUpEvent += CancelButton_OnPointerUpEvent;
    }

    void OkButton_OnPointerUpEvent()
    {
        if(OnPopUpResponseCome != null) 
        {
            OnPopUpResponseCome( PopUpResponseType.OkButtonClicked );
        }
    }

    void CloseButton_OnPointerUpEvent()
    {
        if (OnPopUpResponseCome != null)
        {
            OnPopUpResponseCome(PopUpResponseType.CloseButtonClicked);
        }
    }

    void CancelButton_OnPointerUpEvent()
    {
        if (OnPopUpResponseCome != null)
        {
            OnPopUpResponseCome(PopUpResponseType.CancelButtonClicked);
        }
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

    private void RemoveAllEvents()
    {
        foreach (MessageAction ma in delegates)
        {
            OnPopUpResponseCome -= ma;
        }

        delegates.Clear();
    }
}

public enum PopUpResponseType
{
    OkButtonClicked,
    CloseButtonClicked,
    CancelButtonClicked
}
