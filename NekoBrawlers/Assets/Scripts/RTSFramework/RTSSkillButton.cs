using RTSFramework.Interactables.Skills;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RTSFramework.UI
{
    public class RTSSkillButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject btnObj;

        [SerializeField]
        private TextMeshProUGUI skillNameText;

        [SerializeField]
        private Button button;

        private RTSSkill currentSkill;

        void Start()
        {
            button.onClick.AddListener(OnClick);
            Hide();
        }

        public void ShowSkill(RTSSkill skill)
        {
            btnObj.SetActive(true);
            currentSkill = skill;
            skillNameText.SetText(skill.SkillName);
        }

        public void OnClick()
        {
            if (currentSkill)
            {
                currentSkill.UseSkill();
            }
        }

        public void Hide()
        {
            btnObj.SetActive(false);
        }

    }
}

