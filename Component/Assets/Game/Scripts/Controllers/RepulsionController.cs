using UnityEngine;

namespace Component
{
    public sealed class RepulsionController : MonoBehaviour
    {
        [SerializeField] private GameObject _character;
        
        private IPushComponent _pushComponent;
        private ITossComponent _tossComponent;

        private void Start()
        {
           _pushComponent = _character.GetComponent<IPushComponent>();
           _tossComponent = _character.GetComponent<ITossComponent>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            { 
               _tossComponent.Toss();
            }
            else if(Input.GetMouseButtonDown(0))
            {
                _pushComponent.Push();
            }
        }
    }
}