
namespace LB.SuperUI.BaseComponents 
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    public class LB_UIPanel : MonoBehaviour
    {

        public LB_UIObject[] UIObjects;

        protected UIState panelType;
        protected Canvas panelCanvas;
        protected RectTransform panelRectTransform;

        protected float animationTime;

        public virtual void PreInit()
        {
            PreInitUIObjects();
        }

        //must be abstract - todo refactor
        public virtual void Init()
        {
            animationTime = .5f;
            panelCanvas = GetComponent<Canvas>();
            panelRectTransform = GetComponent<RectTransform>();

            InitUIObjects();
            SetAnimationTime();

            CalculateObjectCoordinates();
        }

        private void SetAnimationTime()
        {
            for (int i = 0; i < UIObjects.Length; i++)
            {
                UIObjects[i].SetAnimationTime(animationTime);
            }
        }

        private void CalculateObjectCoordinates()
        {
            var canvasSize = GetCanvasSize();

            for (int i = 0; i < UIObjects.Length; i++)
            {
                UIObjects[i].CalculateCoordinates(canvasSize);
            }
        }

        public virtual void LateInit()
        {
            LateInitUIObjects();
        }

        public virtual void Activate()
        {
            panelCanvas.enabled = true;
            panelCanvas.sortingOrder = 1;
            StopCoroutine("DeactivateWithAnimation");
            PlayActivateAnimations();
        }

        public virtual void Deactivate()
        {
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

        private void PreInitUIObjects()
        {
            for (int i = 0; i < UIObjects.Length; i++)
            {
                UIObjects[i].PreInit();
            }
        }

        private void InitUIObjects()
        {
            for (int i = 0; i < UIObjects.Length; i++)
            {
                UIObjects[i].Init();
            }
        }

        private void LateInitUIObjects()
        {
            for (int i = 0; i < UIObjects.Length; i++)
            {
                UIObjects[i].LateInit();
            }
        }

        public void PlayActivateAnimations()
        {
            for (int i = 0; i < UIObjects.Length; i++)
            {
                UIObjects[i].PlayActivateAnimation();
            }
        }

        public void PlayDeactivateAnimations()
        {
            for (int i = 0; i < UIObjects.Length; i++)
            {
                UIObjects[i].PlayDeactivateAnimation();
            }
        }

        public void OnDestroyCalled()
        {

        }

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

