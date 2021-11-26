using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class CamFollowPlayerScript : MonoBehaviour
    {
        public Transform Player;
        private Camera myCam;
        private float xOffset, yOffset, zOffset;
        void Start()
        {
            myCam = gameObject.GetComponent<Camera>();
            xOffset = myCam.transform.position.x - Player.transform.position.x;
            yOffset = myCam.transform.position.y - Player.transform.position.y;
            zOffset = myCam.transform.position.z - Player.transform.position.z;
        }

        // Update is called once per frame
        void Update()
        {
            MoveCamera();
        }

        private void MoveCamera()
        {
            myCam.transform.position = new Vector3(Player.transform.position.x + xOffset, Player.transform.position.y + yOffset, Player.transform.position.z + zOffset);
        }
    }
}