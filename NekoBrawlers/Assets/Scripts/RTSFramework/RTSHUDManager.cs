using Core.Pattern;
using RTSFramework.Interactables.Skills;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RTSFramework.UI
{
    public class RTSHUDManager : Singleton<RTSHUDManager>
    {
        [SerializeField]
        private List<RTSSkillButton> skillBtns;

        public void ClearSkills()
        {
            foreach(RTSSkillButton skillBtn in skillBtns)
            {
                skillBtn.Hide();
            }
        }

        public void SetupSkills(List<RTSSkill> skills)
        {
            for(int i = 0; i < skillBtns.Count; i++)
            {
                if(i < skills.Count)
                {
                    skillBtns[i].ShowSkill(skills[i]);
                }
                else
                {
                    skillBtns[i].Hide();
                }
            }
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(GlobalParameters.SceneMainMenu);
        }
    }
}

