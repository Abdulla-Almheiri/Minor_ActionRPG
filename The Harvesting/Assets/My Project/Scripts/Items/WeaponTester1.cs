using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class WeaponTester1 : MonoBehaviour
    {
        public WeaponTemplate WeaponTemplate;
        private WeaponItem _weapon;
        // Start is called before the first frame update
        void Start()
        {
            _weapon = WeaponTemplate.Generate(10, 10);
           foreach(ItemStat itemStat in _weapon.Attributes)
            {
                Debug.Log("Stat " + itemStat.Attribute.name + "  is  :   " + itemStat.Value);
            }

            Debug.Log("Damage is  :   " + _weapon.DamageValue);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}