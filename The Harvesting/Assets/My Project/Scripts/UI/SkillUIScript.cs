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
        public Image Skill1;
        public Image Skill2;
        public Image Skill3;
        public Image Skill4;
        public Image Skill5;
        public Image Skill6;
        public Image Skill7;

        // Start is called before the first frame update
        void Start()
        {
            Skill1.sprite = PlayerData.Skill1.Icon? PlayerData.Skill1.Icon: DefaultSprite;
            Skill2.sprite = PlayerData.Skill2.Icon? PlayerData.Skill2.Icon: DefaultSprite;
            Skill3.sprite = PlayerData.Skill3.Icon? PlayerData.Skill3.Icon: DefaultSprite;
            Skill4.sprite = PlayerData.Skill4.Icon? PlayerData.Skill4.Icon : DefaultSprite;
            Skill5.sprite = PlayerData.Skill5.Icon? PlayerData.Skill5.Icon : DefaultSprite;
            Skill6.sprite = PlayerData.Skill6.Icon? PlayerData.Skill6.Icon : DefaultSprite;
            Skill7.sprite = PlayerData.Skill7.Icon? PlayerData.Skill7.Icon : DefaultSprite;

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}