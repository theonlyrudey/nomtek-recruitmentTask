using System;
using Code.UI.Elements;
using DG.Tweening;
using UnityEngine;

namespace Code.UI.Views
{
    public class ObjectsLoaderPopupView : MonoBehaviour
    {
        [SerializeField] private Transform contentParent;
        [SerializeField] private RectTransform viewRectTransform;
        [SerializeField] private float showAnimationDuration;
        [SerializeField] private float hideAnimationDuration;
        [SerializeField] private AnimationCurve animationCurve;

        public Transform ContentParent => contentParent;
        
        private float shownXPosition;
        private float hiddenXPosition;
        
        private void Awake()
        {
            shownXPosition = viewRectTransform.anchoredPosition.x;
            hiddenXPosition = -shownXPosition;
            viewRectTransform.DOAnchorPosX(hiddenXPosition, 0);
        }

        public void Show()
        {
            viewRectTransform.DOAnchorPosX(shownXPosition ,showAnimationDuration).SetEase(animationCurve);
        }
        
        public void Hide()
        {
            viewRectTransform.DOAnchorPosX(hiddenXPosition, hideAnimationDuration).SetEase(animationCurve);
        }
    }
}