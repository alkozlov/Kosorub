using UnityEngine;

namespace Assets.Scripts
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource EffectsSource;               //Drag a reference to the audio source which will play the sound effects.
        public AudioSource MusicSource;                 //Drag a reference to the audio source which will play the music.
        public static SoundManager Instance;            //Allows other scripts to call functions from SoundManager.             
        public float LowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
        public float HighPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.

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
        }

        //Used to play single sound clips.
        public void PlaySingle(AudioClip clip)
        {
            //Set the clip of our EfxSource audio source to the clip passed in as a parameter.
            this.EffectsSource.clip = clip;

            //Play the clip.
            this.EffectsSource.Play();
        }
    }
}
