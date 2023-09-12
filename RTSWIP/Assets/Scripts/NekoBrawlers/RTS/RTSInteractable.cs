#if UNITY_EDITOR
using HandyInspector;
#endif
using RTSFramework.Interactables.Buildings;
using RTSFramework.Interactables.Skills;
using RTSFramework.Interactables.Units;
using RTSFramework.UI;
using System.Collections.Generic;
using UnityEngine;

namespace RTSFramework.Interactables
{
    public enum InteractableType
    {
        None = 0,
        Unit = 1,
        Buliding
    }

    public class RTSInteractable : MonoBehaviour
    {
        public InteractableType InteractableType;

#if UNITY_EDITOR
        [ShowIf("InteractableType", "Unit")]
#endif
        public RTSUnit RTSUnit;

#if UNITY_EDITOR
        [ShowIf("InteractableType", "Buliding")]
#endif

        public RTSBuilding RTSBuilding;

        public List<RTSSkill> Skills;

        public bool IsUnit => InteractableType == InteractableType.Unit;

        public bool IsBuilding => InteractableType == InteractableType.Buliding;

        [SerializeField]
        private GameObject SelectionIndicator;

        private void Start()
        {
            OnDeselect();
        }

        public void OnSelect()
        {
            SelectionIndicator?.SetActive(true);
            ShowSkills();
        }

        public void OnDeselect()
        {
            SelectionIndicator.SetActive(false);
        }

        public void ShowSkills()
        {
            RTSHUDManager.Instance.SetupSkills(Skills);
        }

    }
}

