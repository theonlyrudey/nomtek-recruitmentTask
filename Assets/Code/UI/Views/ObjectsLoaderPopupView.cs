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

        public void Show()
        {
            viewRectTransform.DOScale(Vector3.one, showAnimationDuration).SetEase(animationCurve);
        }
        
        public void Hide()
        {
            viewRectTransform.DOScale(Vector3.zero, hideAnimationDuration).SetEase(animationCurve);
        }
    }
}