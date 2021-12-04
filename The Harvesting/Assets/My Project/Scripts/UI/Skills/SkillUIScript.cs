using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    public class SkillUIScript : MonoBehaviour
    {
        [SerializeField] GameManager _gameManager;
        public Sprite DefaultSprite;
        public List<Image> Icons;
        void Start()
        {
            DisplaySkillIcons();
        }

        public void Update()
        {
            //UpdateSkillsRechargeUI();
        }

        public void DisplaySkillIcons()
        {
            int index = 0;
            foreach(Skill skill in _gameManager.PlayerCore.SkillController.Abilities)
            {
                Icons[index].sprite = skill.Icon;
                index++;
                //print("SKILL IS : " + skill.Name);
            }
        }


        /*private void UpdateSkillsRechargeUI()
        {
            for(int i = 0; i< Icons.Count; i++)
            {
                Icons[i].fillAmount = SkillController.SkillRecharge(i, out _);
            }
        }*/

    }
}