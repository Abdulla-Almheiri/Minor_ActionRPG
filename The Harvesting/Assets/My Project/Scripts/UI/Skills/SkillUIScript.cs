using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    public class SkillUIScript : MonoBehaviour
    {
        public IPlayerCore PlayerCore { get; protected set; }
        public Sprite DefaultSprite;
        public List<Image> Icons;
        public List<Image> IconsBackground;
        public Image PrimaryWSIcon;
        public Image PrimaryWSIconBackground;
        public Image SecondaryWSIcon;
        public Image SecondaryWSIconBackground;

        public void Update()
        {
            UpdateSkillsRechargeUI();
        }

        public void AssignSkillIcons()
        {
            int index = 0;
            foreach(Skill skill in PlayerCore.SkillController.Abilities)
            {
                Icons[index].sprite = skill.Icon;
                IconsBackground[index].sprite = skill.Icon;
                index++;
                //print("SKILL IS : " + skill.Name);
            }

            if (PlayerCore.SkillController.PrimaryWeaponSkill != null)
            {
                PrimaryWSIcon.sprite = PlayerCore.SkillController.PrimaryWeaponSkill.Icon;
                PrimaryWSIconBackground.sprite = PrimaryWSIcon.sprite;
            } else
            {
                Debug.Log("Primary skill is null");
            }


            if (PlayerCore.SkillController.SecondaryWeaponSkill != null)
            {
                SecondaryWSIcon.sprite = PlayerCore.SkillController.SecondaryWeaponSkill.Icon;
                SecondaryWSIconBackground.sprite = SecondaryWSIcon.sprite;
            }
        }


        private void UpdateSkillsRechargeUI()
        {
            for(int i = 0; i< Mathf.Min(Icons.Count, PlayerCore.SkillController.Abilities.Count) ; i++)
            {
                Icons[i].fillAmount = 1f-PlayerCore.SkillController.SkillRecharge(PlayerCore.SkillController.Abilities[i], out _);
            }

            PrimaryWSIcon.fillAmount = 1f - PlayerCore.SkillController.SkillRecharge(PlayerCore.SkillController.PrimaryWeaponSkill, out _);
        }

        public void Initialize(IPlayerCore playerCore)
        {
            PlayerCore = playerCore;
            AssignSkillIcons();
        }

        public void SetDirty()
        {
            AssignSkillIcons();
        }
    }
}