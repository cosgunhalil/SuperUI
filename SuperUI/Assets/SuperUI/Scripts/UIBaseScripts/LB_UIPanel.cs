﻿
namespace LB.SuperUI.BaseComponents 
{
    using LB.SuperUI.Helpers.Observer;
    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Canvas))]
    public abstract class LB_UIPanel : LB_Object
    {
        [SerializeField]
        protected LB_UIObject[] uIObjects;

        protected UIState panelType;
        protected Canvas panelCanvas;
        protected RectTransform panelRectTransform;

        protected const float animationTime = .5f;

        protected ISubject<UIStateChangedEventArgs> uiManager;

        protected abstract void RegisterEvents();
        protected abstract void UnRegisterEvents();

        public abstract void Setup();

        public void InjectUIManagerDependency(ISubject<UIStateChangedEventArgs> uiManager) 
        {
            this.uiManager = uiManager;
        }

        public override void PreInit()
        {
            SetAnimationTime(animationTime);

            for (int i = 0; i < uIObjects.Length; i++)
            {
                uIObjects[i].PreInit();
            }
        }

        private void SetAnimationTime(float animationTime)
        {
            for (int i = 0; i < uIObjects.Length; i++)
            {
                uIObjects[i].SetAnimationTime(animationTime);
            }
        }

        public override void Init()
        {
            panelCanvas = GetComponent<Canvas>();
            panelRectTransform = GetComponent<RectTransform>();

            Setup();

            var canvasSize = GetCanvasSize();

            for (int i = 0; i < uIObjects.Length; i++)
            {
                uIObjects[i].Init();
                uIObjects[i].Setup(canvasSize);
            }

            RegisterEvents();
        }

        public override void LateInit()
        {
            for (int i = 0; i < uIObjects.Length; i++)
            {
                uIObjects[i].LateInit();
            }
        }

        public void Activate()
        {
            if (panelCanvas.enabled) 
            {
                return;
            }

            panelCanvas.enabled = true;
            panelCanvas.sortingOrder = 1;
            StopCoroutine("DeactivateWithAnimation");
            PlayActivateAnimations();
        }

        public void Deactivate()
        {
            if (!panelCanvas.enabled) 
            {
                return;
            }

            StartCoroutine("DeactivateWithAnimation");
        }

        private IEnumerator DeactivateWithAnimation()
        {
            PlayDeactivateAnimations();
            panelCanvas.sortingOrder = 2;

            yield return new WaitForSeconds(animationTime);
            panelCanvas.sortingOrder = 0;
            panelCanvas.enabled = false;
        }

        public void PlayActivateAnimations()
        {
            for (int i = 0; i < uIObjects.Length; i++)
            {
                uIObjects[i].PlayActivateAnimation();
            }
        }

        public void PlayDeactivateAnimations()
        {
            for (int i = 0; i < uIObjects.Length; i++)
            {
                uIObjects[i].PlayDeactivateAnimation();
            }
        }

        public void OnDestroyCalled()
        {
            UnRegisterEvents();

            for (int i = 0; i < uIObjects.Length; i++)
            {
                uIObjects[i].OnUIObjectDestroy();
            }
        }

        //
        private Vector2 GetCanvasSize()
        {
            Vector2 screenSize = new Vector2(Screen.width, Screen.height);
            CanvasScaler canvasScaler = GetComponent<CanvasScaler>();
            var m_ScreenMatchMode = canvasScaler.screenMatchMode;
            var m_ReferenceResolution = canvasScaler.referenceResolution;
            var m_MatchWidthOrHeight = canvasScaler.matchWidthOrHeight;

            float scaleFactor = 0;
            float logWidth = Mathf.Log(screenSize.x / m_ReferenceResolution.x, 2);
            float logHeight = Mathf.Log(screenSize.y / m_ReferenceResolution.y, 2);
            float logWeightedAverage = Mathf.Lerp(logWidth, logHeight, m_MatchWidthOrHeight);
            scaleFactor = Mathf.Pow(2, logWeightedAverage);

            return new Vector2(screenSize.x / scaleFactor, screenSize.y / scaleFactor);
        }
    }

}

