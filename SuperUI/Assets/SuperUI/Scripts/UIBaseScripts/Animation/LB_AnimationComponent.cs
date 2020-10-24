
namespace LB.SuperUI.Animation 
{
    using DG.Tweening;
    using UnityEngine;
    public class LB_AnimationComponent 
    {
        public Ease AnimationEase { get => animationEase; set => animationEase = value; }

        protected RectTransform objectRectTransform;
        protected float animationTime;
        private DG.Tweening.Ease animationEase;
        public LB_AnimationComponent(RectTransform objectRectTransform, float animationTime) 
        {
            this.objectRectTransform = objectRectTransform;
            this.animationTime = animationTime;
        }
    }
}


