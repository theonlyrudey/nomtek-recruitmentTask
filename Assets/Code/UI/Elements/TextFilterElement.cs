using System;
using TMPro;
using UnityEngine;

namespace Code.UI.Elements
{
    public class TextFilterElement : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        public event Action<string> OnValueChanged;

        private void OnEnable()
        {
            inputField.onValueChanged.AddListener(OnValueChangedHandler);
        }

        private void OnValueChangedHandler(string value)
        {
            OnValueChanged?.Invoke(value);
        }
    }
}