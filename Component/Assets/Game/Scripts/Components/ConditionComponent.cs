using System;
using UnityEngine;

namespace Component
{
    public class ConditionComponent: MonoBehaviour
    {
        protected AndCondition AndCondition = new();
        
        public void AddCondition(Func<bool> condition)
        {
            AndCondition.AddCondition(condition);
        }
    }
}