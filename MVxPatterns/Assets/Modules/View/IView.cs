using System;

namespace Modules.Views
{
    public interface IView
    {
        event Action OnShown;
        event Action OnHidden;

        bool IsShown { get; }

        void Show();
        void Hide();
    }
}