using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helix.Components.Controls.Controllers;
using Helix.Components.GameEngine.Enemy.Spawn;

namespace Helix.Components.GameEngine
{
    public class GameEngine : MonoBehaviour
    {
        private User _user;
        private static GameEngine _instance;
        private GameObject player;
        public float cameraHeight = 9;

        public int wave = 0;
        public List<GameObject> spawnNodes = new List<GameObject>();


        void Awake()
        {
            if (GameEngine._instance == null)
            {
                GameEngine._instance = this;
            }
        }

        void Start()
        {
            this._user = gameObject.AddComponent<User>(); //Instantiate the user
            this.player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            CameraFollow();
        }

        public static GameEngine GetInstance()
        {
            return GameEngine._instance;
        }

        private void CameraFollow()
        {
            Vector3 playerPosition = this.player.transform.position;
            float angle = Camera.main.transform.rotation.eulerAngles.x;

            float offset = Mathf.Tan(Mathf.Deg2Rad * angle) * cameraHeight;
            Camera.main.transform.position = new Vector3(playerPosition.x, cameraHeight, playerPosition.z - offset);
        }

        private GameObject[] GetSpawnNodes()
        {
            return GameObject.FindGameObjectsWithTag("SpawnNode");
        }


    }
}