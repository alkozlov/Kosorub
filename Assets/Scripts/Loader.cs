using UnityEngine;

namespace Assets.Scripts
{
    public class Loader : MonoBehaviour
    {
        public GameObject GameManagerObject;              //GameManager prefab to instantiate.
        public GameObject SoundManagerObject;             //SoundManager prefab to instantiate.

        private void Awake()
        {
            //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
            if (GameManager.Instance == null)
            {
                //Instantiate GameManagerObject prefab
                Instantiate(this.GameManagerObject);
            }

            //Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
            if (SoundManager.Instance == null)
            {
                //Instantiate SoundManagerObject prefab
                Instantiate(this.SoundManagerObject);
            }
        }
    }
}