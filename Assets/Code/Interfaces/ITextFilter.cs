using System;

namespace Code.Interfaces
{
    public interface ITextFilter
    {
        event Action<string> OnTextFiltered;
        void SetFilter(string text);
    }
}