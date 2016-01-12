using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyManager : MonoBehaviour
    {
        public List<Transform> SpawnPoints;
        public Transform Enemy;
        public float SpawnTime = 4f;

        // Use this for initialization
        private void Start()
        {
            this.InvokeRepeating("SpawnEnemy", this.SpawnTime, this.SpawnTime);
        }

        // Update is called once per frame
        private void Update()
        {

        }

        private void SpawnEnemy()
        {
            Transform spawnPoint = this.SpawnPoints[Random.Range(0, this.SpawnPoints.Count)];
            Instantiate(this.Enemy, spawnPoint.position, Quaternion.identity);
        }
    }
}
