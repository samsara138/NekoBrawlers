#if UNITY_EDITOR
using HandyInspector;
#endif
using UnityEngine;
using UnityEngine.UI;

namespace RTSFramework.Interactables.Skills
{
    public abstract class RTSSkill : MonoBehaviour
    {
        public string SkillName;
        public string SkillDesc;

        public int CooldownSec;
        public bool IsAvailable;


        public Image Icon;

#if UNITY_EDITOR
        [Button]
#endif
        public abstract void UseSkill();

        public abstract void OnClickGround(Vector3 Point);

        public abstract void OnDeselect();
    }

}
