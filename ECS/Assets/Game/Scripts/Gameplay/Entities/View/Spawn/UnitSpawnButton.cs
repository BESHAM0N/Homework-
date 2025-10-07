using System;
using System.Collections.Generic;
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
        [SerializeField] private UnitType _defaultUnit = UnitType.Archer;

        private EcsWorld _world;

        private void Awake()
        {
            _world = EcsAdmin.Systems?.GetWorld();

            if (_spawnButton != null)
                _spawnButton.onClick.AddListener(OnClick);
        }

        private void Start()
        {
            FillDropdownOptions();
            ApplyDefaultDropdownValue();
        }

        private void FillDropdownOptions()
        {
            if (_unitDropdown == null) return;

            _unitDropdown.ClearOptions();

            var options = new List<TMP_Dropdown.OptionData>
            {
                new(nameof(UnitType.Archer)),
                new(nameof(UnitType.Swordman)),
            };

            _unitDropdown.AddOptions(options);
            _unitDropdown.RefreshShownValue();
        }

        private void ApplyDefaultDropdownValue()
        {
            if (_unitDropdown == null)
                return;

            var wanted = _defaultUnit.ToString();
            int idx = _unitDropdown.options.FindIndex(o => string.Equals(o.text, wanted));

            if (idx < 0)
                idx = 0;

            _unitDropdown.SetValueWithoutNotify(idx);
            _unitDropdown.RefreshShownValue();
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
            if (_unitDropdown == null)
                return UnitType.Archer;

            var label = _unitDropdown.options[_unitDropdown.value].text;
            return Enum.TryParse(label, out UnitType type) ? type : UnitType.Archer;
        }

        private void OnClick()
        {
            EnsureWorld();

            if (_world == null)
                return;

            _world.GetEvent<BuildingSpawnEvent>().Fire(new BuildingSpawnEvent
            {
                buildingEntity = -1,
                team = _team,
                unitType = GetSelectedUnit()
            });
        }
    }
}