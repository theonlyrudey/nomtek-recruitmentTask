using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements
{
    public class SpawnableObjectElement : MonoBehaviour
    {
        [SerializeField] private Image thumbnailImage;
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI labelText;

        private string label;
        
        public event Action<string> OnButtonClicked;

        public bool Enabled
        {
            set => gameObject.SetActive(value);
        }
        
        public void Initialize(string label, Sprite thumbnail)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnButtonClickedHandler);
            this.label = label;
            thumbnailImage.sprite = thumbnail;
            labelText.text = label;
        }

        private void OnButtonClickedHandler()
        {
            OnButtonClicked?.Invoke(label);
        }
    }
}
