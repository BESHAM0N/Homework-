using System;
using UnityEngine;
using UnityEngine.Events;

namespace Modules.Views
{
    public class View : MonoBehaviour, IView
    {
        public event Action OnShown;
        public event Action OnHidden;

        public bool IsShown => gameObject.activeInHierarchy;

        [SerializeField] private UnityEvent onShown;
        [SerializeField] private UnityEvent onHidden;

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);

        private void OnEnable()
        {
            OnShow();
            onShown?.Invoke();
            OnShown?.Invoke();
        }

        private void OnDisable()
        {
            OnHide();
            onHidden?.Invoke();
            OnHidden?.Invoke();
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnHide()
        {
        }
    }
}