using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public Transform Player;
        public Transform SoulBag;
        public Vector2 PlayerSpawn = new Vector2(-7, 0);

        private LevelManager _levelManager;
        private UIManager _uiManager;
        private Kosorub _kosorub;
        private Health _health;

        // Game level variables
        private Int32 _souls;

        private void Awake()
        {
            //Check if Instance already exists
            if (Instance == null)
            {
                //if not, set Instance to this
                Instance = this;
            }
            //If Instance already exists and it's not this:
            else
            {
                if (Instance != this)
                {
                    //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one Instance of a GameManager.
                    Destroy(this.gameObject);
                }
            }

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(this.gameObject);

            this._levelManager = this.GetComponent<LevelManager>();
            this._uiManager = this.GetComponent<UIManager>();

            this.InitGame();
        }

        private void InitGame()
        {
            // Activate level
            this._levelManager.SetupScene();
        }

        private void Start()
        {
            // Instantiate player on scene
            Transform instantiatedPlayer = Instantiate(this.Player, this.PlayerSpawn, Quaternion.identity) as Transform;
            Instantiate(this.SoulBag);
            if (instantiatedPlayer != null)
            {
                this._kosorub = instantiatedPlayer.GetComponent<Kosorub>();
                this._health = instantiatedPlayer.GetComponent<Health>();

                // Game variables
                this._souls = 0;

                this._uiManager.SetSouls(this._souls);
                this._uiManager.SetHealth(this._health.Healthpoints);
            }
        }

        public void CollectSoul()
        {
            this._souls++;
            this._uiManager.SetSouls(this._souls);
        }

        public void DamagePlayer(Int32 damage)
        {
            this._health.DecreaseHealth(1);
            this._uiManager.SetHealth(this._health.Healthpoints);
        }
    }
}
