using System;
using Code.Interfaces;

namespace Code.Services
{
    public class TextFilterService : ITextFilter
    {
        public event Action<string> OnTextFiltered;
        
        public void SetFilter(string text)
        {
            OnTextFiltered?.Invoke(text);
        }
    }
}