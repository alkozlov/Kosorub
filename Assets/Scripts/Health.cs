using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Health : MonoBehaviour
    {
        public Int32 Healthpoints = 100;

        private void Awake()
        {
            
        }

        /// <summary>
        /// Increase healthpoints by specified value.
        /// </summary>
        /// <param name="healthPoints"></param>
        public void IncreaseHealth(Int32 healthPoints)
        {
            this.Healthpoints += healthPoints;
        }

        /// <summary>
        /// Decrease healthpoints by specified value.
        /// </summary>
        /// <param name="healthPoints"></param>
        public void DecreaseHealth(Int32 healthPoints)
        {
            this.Healthpoints -= healthPoints;
        }
    }
}
