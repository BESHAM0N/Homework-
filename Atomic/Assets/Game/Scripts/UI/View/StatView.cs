using TMPro;
using UnityEngine;

namespace SampleGame
{
    public sealed class StatView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text valueText;

        public void SetText(string health)
        {
            valueText.text = health;
        }
        
        public void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }
    }
}