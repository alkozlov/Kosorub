using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {

        private Text _lblSouls;
        private Text _lblHealth;

        private void Awake()
        {
            this._lblSouls = GameObject.Find("lblSouls").GetComponent<Text>();
            this._lblHealth = GameObject.Find("lblHealth").GetComponent<Text>();
        }

        public void SetSouls(Int32 souls)
        {
            this._lblSouls.text = souls.ToString();
        }

        public void SetHealth(Int32 health)
        {
            this._lblHealth.text = health.ToString();
        }
    }
}
