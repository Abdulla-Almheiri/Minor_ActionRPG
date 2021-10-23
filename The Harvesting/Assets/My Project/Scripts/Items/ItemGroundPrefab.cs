using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Harvesting
{
    public class ItemGroundPrefab : MonoBehaviour
    {
        public TMP_Text TextUI;
        public Item Item;
        public Vector3 WorldPosition;
        // Start is called before the first frame update
        void Start()
        {
            if(Item != null)
            {
                TextUI.SetText(Item.ItemData.UnidentifiedName);
                TextUI.color = Item.Quality.Color;
            }
            MaintainPosition();
        }

        // Update is called once per frame
        void Update()
        {
            MaintainPosition();
        }

        public void MaintainPosition()
        {
            transform.position = Camera.main.WorldToScreenPoint(WorldPosition);
        }
    }
}