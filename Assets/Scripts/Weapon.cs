using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Weapon : MonoBehaviour
    {
        public Vector3 DefaultOffset = new Vector3(0.5f, 0.25f, 1);

        private Transform _transform;
        private AttackState _attackState;

        public AttackState AttackState
        {
            get { return this._attackState; }

            set { this._attackState = value; }
        }

        private void Awake()
        {
            this._transform = this.GetComponent<Transform>();
            this._attackState = AttackState.NotAtacks;
        }

        // Use this for initialization
        private void Start()
        {
            
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            
        }

        public void AttachTo(Transform parent)
        {
            this._transform.parent = parent;
            this.transform.localPosition = Vector3.zero + this.DefaultOffset;
            Debug.Log("Weapon attached");
        }
    }
}
