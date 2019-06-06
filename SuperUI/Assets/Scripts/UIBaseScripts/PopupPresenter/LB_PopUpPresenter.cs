using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LB_PopUpFabric))]
public class LB_PopUpPresenter : LB_UIPanel
{
    private LB_PopUpFabric popUpFabric;
    private int activePopUpCount;

    public override void PreInit()
    {
        base.PreInit();
        popUpFabric = GetComponent<LB_PopUpFabric>();
    }

    public override void Init()
    {
        base.Init();
        popUpFabric.InitializeFabric();
    }

    private void PresentPopUp(PopUpSettings popUpSettings) 
    {
        var popUp = popUpFabric.GetPopUp(popUpSettings);
        popUp.transform.SetParent(gameObject.transform);
    }

    private void Awake()
    {
        PreInit();
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) 
        {
            var popUpSettings = new PopUpSettings
            {
                Type = PopUpType.Warning,
                hasOkeyButton = true,
                hasCloseButton = false,
                hasCancelButton = false,
                Title = "Test-Pop-Up",
                Content = "lorem ipsum dolar sit amed dans eder halay çeker."
            };
            PresentPopUp(popUpSettings);
        }
    }

}
