using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    public class SkillUIScript : MonoBehaviour
    {
        public PlayerData PlayerData;
        public Sprite DefaultSprite;
        public List<Image> Icons;

        void Start()
        {
            var skills = PlayerData.Skills;
            for (int i = 0; i < skills.Count; i++)
            {
                if(skills[i].Icon != null)
                {
                    Icons[i].sprite = skills[i].Icon;
                } else
                {
                    Icons[i].sprite = DefaultSprite;
                }
            }

        }
    }
}