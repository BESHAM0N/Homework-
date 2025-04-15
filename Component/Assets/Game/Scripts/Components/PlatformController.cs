using UnityEngine;

namespace Component
{
    public class PlatformController : MonoBehaviour
    {
        private const string PLATFORM_TAG = "Platform";
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(PLATFORM_TAG))
                transform.parent = collision.transform;
        }
        
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(PLATFORM_TAG))
                transform.parent = null; 
        }
    }
}