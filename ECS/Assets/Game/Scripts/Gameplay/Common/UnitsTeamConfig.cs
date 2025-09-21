using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame
{
    [CreateAssetMenu(fileName = "UnitsTeamConfig", menuName = "ECSGame/Common/New UnitsTeamConfig")]
    public sealed class UnitsTeamConfig : ScriptableObject
    {
        [SerializeField] private Entry[] _entries;

        Dictionary<(TeamType, UnitType), Entry> _byTuple;
        private Dictionary<string, EcsPrototype> _byViewKey;

        private void OnEnable()
        {
            _byTuple = new(_entries.Length);
            _byViewKey = new();

            foreach (var entry in _entries)
            {
                _byTuple[(entry.team, entry.type)] = entry;

                if (!string.IsNullOrWhiteSpace(entry.viewKey) && entry.prototype != null)
                    _byViewKey[entry.viewKey] = entry.prototype;
            }
        }

        public EcsPrototype GetPrototype(TeamType team, UnitType type)
        {
            if (_byTuple.TryGetValue((team, type), out var e) && e.prototype != null)
                return e.prototype;

            throw new KeyNotFoundException($"Prototype for team '{team}' and type '{type}' is not configured.");
        }
        
        public EcsPrototype GetPrototype(string viewKey)
        {
            if (_byViewKey.TryGetValue(viewKey, out var prototype)) 
                return prototype;
            
            throw new KeyNotFoundException($"Prototype for view '{viewKey}' not configured in {name}.");
        }

        public string GetViewKey(TeamType team, UnitType type)
        {
            if (_byTuple.TryGetValue((team, type), out var entry) && !string.IsNullOrWhiteSpace(entry.viewKey))
                return entry.viewKey;

            throw new KeyNotFoundException($"View key not configured for team '{team}', type '{type}'.");
        }
    }
}