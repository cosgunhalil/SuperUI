using System.Collections;
using System.Collections.Generic;


namespace LB.SuperUI.Animation 
{
    using UnityEngine;
    using DG.Tweening;
    public class LB_ScaleAnimationComponent : LB_AnimationComponent, IAnimable
    {
        public float ActivatedScale { get => activatedScale; set => activatedScale = value; }
        public float DeactivatedScale { get => deactivatedScale; set => deactivatedScale = value; }

        private float activatedScale;
        private float deactivatedScale;

        public LB_ScaleAnimationComponent(RectTransform objectRectTransform, float animationTime) : base(objectRectTransform, animationTime)
        {
            this.objectRectTransform = objectRectTransform;
            this.animationTime = animationTime;
        }

        public void PlayForward()
        {
            objectRectTransform.DOScale(activatedScale, animationTime).SetEase(AnimationEase);
        }

        public void PlayRewind()
        {
            objectRectTransform.DOScale(deactivatedScale, animationTime).SetEase(AnimationEase);
        }
    }
}

