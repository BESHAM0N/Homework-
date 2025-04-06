using UnityEngine;

namespace Component
{
    public class Cooldawn
    {
        private float _cooldownDuration;
        private float _lastActionTime;
      
        public Cooldawn(float cooldownDuration)
        {
            _cooldownDuration = cooldownDuration;
            _lastActionTime = -cooldownDuration;
        }
      
        public bool IsReady()
        {
            return Time.time - _lastActionTime >= _cooldownDuration;
        }
       
        public void ResetCooldown()
        {
            _lastActionTime = Time.time;
        }
        
        public float GetRemainingTime()
        {
            var elapsed = Time.time - _lastActionTime;
            return Mathf.Max(0, _cooldownDuration - elapsed);
        }
    }
}