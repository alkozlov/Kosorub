using UnityEngine;

namespace Assets.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        public GameObject EnemyManager;

        // Use this for initialization
        private void Start()
        {
            
        }

        // Update is called once per frame
        private void Update()
        {

        }

        public void SetupScene()
        {
            Instantiate(this.EnemyManager);
        }
    }
}
