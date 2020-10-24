
namespace LB.SuperUI.Animation 
{
    using DG.Tweening;
    using UnityEngine;
    public class LB_MoveAnimationComponent : LB_AnimationComponent, IAnimable
    {
        public Vector2 DeactivatedCoordinate { get => deactivatedCoordinate; set => deactivatedCoordinate = value; }
        public Vector2 ActivatedCoordinate { get => activatedCoordinate; set => activatedCoordinate = value; }


        private Vector2 activatedCoordinate;
        private Vector2 deactivatedCoordinate;

        public LB_MoveAnimationComponent(RectTransform objectRectTransform, float animationTime) : base(objectRectTransform, animationTime)
        {
            this.objectRectTransform = objectRectTransform;
            this.animationTime = animationTime;
        }

        public void PlayForward()
        {
            objectRectTransform.DOAnchorPos(ActivatedCoordinate, animationTime).SetEase(Ease.InOutSine);
        }

        public void PlayRewind()
        {
            objectRectTransform.DOAnchorPos(DeactivatedCoordinate, animationTime).SetEase(Ease.InOutSine);
        }
    }
}
