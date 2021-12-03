using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class CamFollowPlayerScript : MonoBehaviour
    {
        public IGameManager GameManager { get; protected set; }
        public Transform Player;
        private Camera myCam;
        private float xOffset, yOffset, zOffset;

        // Update is called once per frame
        void Update()
        {
            if (Player != null)
            {
                MoveCamera();
            }
        }
        public void Initialize(PlayerCore playerCore)
        {
            Player = playerCore.transform;
            myCam = gameObject.GetComponent<Camera>();
            xOffset = myCam.transform.position.x - Player.transform.position.x;
            yOffset = myCam.transform.position.y - Player.transform.position.y;
            zOffset = myCam.transform.position.z - Player.transform.position.z;
        }
        private void MoveCamera()
        {
            myCam.transform.position = new Vector3(Player.transform.position.x + xOffset, Player.transform.position.y + yOffset, Player.transform.position.z + zOffset);
        }
    }
}