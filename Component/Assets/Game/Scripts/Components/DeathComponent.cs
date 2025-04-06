using UnityEngine;

namespace Component
{
    public class DeathComponent : MonoBehaviour
    {
        public void Death()
        {
            gameObject.SetActive(false);
        }
    }
}