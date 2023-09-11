using CustomEditor.ShowIfAttribute;
using RTSFramework.Interactables.Buildings;
using RTSFramework.Interactables.Units;
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

        [ShowIf("InteractableType", "Unit")]
        public RTSUnit RTSUnit;

        [ShowIf("InteractableType", "Buliding")]
        public RTSBuilding RTSBuilding;

        public bool IsUnit => InteractableType == InteractableType.Unit;

        public bool IsBuilding => InteractableType == InteractableType.Buliding;
    }
}

