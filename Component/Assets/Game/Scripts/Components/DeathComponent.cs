using UnityEngine;

namespace Component
{
    public sealed class DeathComponent : MonoBehaviour
    {
        public void Death()
        {
            gameObject.SetActive(false);
        }
    }
}