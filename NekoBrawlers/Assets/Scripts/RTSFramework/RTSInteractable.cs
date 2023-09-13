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

    public abstract class RTSInteractable : MonoBehaviour
    {
        public string IteractableName;

        public InteractableType InteractableType;

        public List<RTSSkill> Skills;

        public bool IsUnit => InteractableType == InteractableType.Unit;

        public bool IsBuilding => InteractableType == InteractableType.Buliding;

        [SerializeField]
        private GameObject SelectionIndicator;

        public bool IsSelected = false;

        private void Start()
        {
            OnDeselect();
        }

        public virtual void OnSelect()
        {
            SelectionIndicator?.SetActive(true);
            ShowSkills();
        }

        public virtual void OnDeselect()
        {
            foreach (var skill in Skills)
            {
                skill.OnDeselect();
            }
            SelectionIndicator.SetActive(false);
        }

        public virtual void OnClickGround(Vector3 point)
        {
            foreach (RTSSkill skill in Skills)
            {
                skill.OnClickGround(point);
            }
        }

        public void ShowSkills()
        {
            RTSHUDManager.Instance.SetupSkills(Skills);
        }

    }
}

