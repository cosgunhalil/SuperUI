
namespace LB.SuperUI.BaseComponents 
{
    using DG.Tweening;
    using UnityEngine;

    public abstract class LB_UIObject : LB_Object
    {
        protected RectTransform objectRectTransform;
        protected Vector2 activatedCoordinate;
        protected Vector2 deactivtedCoordinate;

        protected float animationTime;
        protected float subAnimationTime;

        protected Tweener activationTween;
        protected Tweener deactivationTween;

        public override void PreInit()
        {
            
        }

        public override void Init()
        {
            objectRectTransform = GetComponent<RectTransform>();
        }

        public abstract void Setup(Vector2 canvasSize);
        public abstract void PlayActivateAnimation();
        public abstract void PlayDeactivateAnimation();

        public override void LateInit()
        {
            
        }

        public virtual void SetSize(Vector2 size)
        {

        }

        public void SetWidth(float width, bool preserveAspect)
        {
            if (preserveAspect)
            {
                var currentHeight = objectRectTransform.sizeDelta.y;
                var currentWidth = objectRectTransform.sizeDelta.x;
                var futureWidth = width;
                var futureHeight = (currentHeight * futureWidth) / currentWidth;

                objectRectTransform.sizeDelta = new Vector2(futureWidth, futureHeight);
            }
            else
            {
                objectRectTransform.sizeDelta = new Vector2(width, objectRectTransform.sizeDelta.y);
            }

        }

        public void SetAnimationTime(float animationTime)
        {
            this.animationTime = animationTime;
        }

        public void SetHeight(float height, bool preserveAspect)
        {
            if (preserveAspect)
            {
                var currentHeight = objectRectTransform.sizeDelta.y;
                var currentWidth = objectRectTransform.sizeDelta.x;
                var futureHeight = height;
                var futureWidth = (currentWidth * futureHeight) / currentHeight;

                objectRectTransform.sizeDelta = new Vector2(futureWidth, futureHeight);
            }
            else
            {
                objectRectTransform.sizeDelta = new Vector2(objectRectTransform.sizeDelta.x, height);
            }

        }

        public virtual void SetPosition(float width)
        {

        }

        public void SetAnchorMax(Vector2 anchorMax)
        {
            objectRectTransform.anchorMax = anchorMax;
        }

        public void SetAnchorMin(Vector2 anchorMin)
        {
            objectRectTransform.anchorMin = anchorMin;
        }

        public void SetAnchorPosition(Vector2 position)
        {
            objectRectTransform.anchoredPosition = position;
        }

        public virtual void OnUIObjectDestroy()
        {

        }

        public Vector2 GetSizeDelta()
        {
            return objectRectTransform.sizeDelta;
        }

        public Vector2 GetRectSize()
        {
            return objectRectTransform.rect.size;
        }

        public Vector2 GetAnchoredPosition()
        {
            return objectRectTransform.anchoredPosition;
        }

    }

}

