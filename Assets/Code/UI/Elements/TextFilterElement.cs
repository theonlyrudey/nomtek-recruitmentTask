using System;
using Code.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI.Elements
{
    public class TextFilterElement : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [Inject] private ITextFilter textFilter;
        
        private void OnEnable()
        {
            inputField.onValueChanged.AddListener(OnValueChangedHandler);
        }

        private void OnValueChangedHandler(string value)
        {
            textFilter.SetFilter(value);
        }
    }
}