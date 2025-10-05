using Leopotam.EcsLite;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ECSGame.Entities.View
{
    public class UnitSpawnButton : MonoBehaviour
    {
        [SerializeField] private TeamType _team = TeamType.BLUE;
        [SerializeField] private TMP_Dropdown _unitDropdown;
        [SerializeField] private Button _spawnButton;

        private EcsWorld _world;

        private void Awake()
        {
            _world = EcsAdmin.Systems?.GetWorld();

            if (_spawnButton != null)
                _spawnButton.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            if (_spawnButton != null)
                _spawnButton.onClick.RemoveListener(OnClick);
        }

        private void EnsureWorld()
        {
            if (_world == null)
                _world = EcsAdmin.Systems?.GetWorld();
        }

        private UnitType GetSelectedUnit()
        {
            if (_unitDropdown == null || _unitDropdown.options.Count == 0)
                return UnitType.Archer;

            var label = _unitDropdown.options[_unitDropdown.value].text;
            return System.Enum.TryParse(label, out UnitType type) ? type : UnitType.Archer;
        }

        private void OnClick()
        {
            EnsureWorld();
            if (_world == null) return;

            _world.GetEvent<BuildingSpawnEvent>().Fire(new BuildingSpawnEvent
            {     
                buildingEntity = -1,   
                team           = _team,     
                unitType       = GetSelectedUnit()
            });
        }
    }
}