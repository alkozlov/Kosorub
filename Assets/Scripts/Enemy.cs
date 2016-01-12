using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {
        public float Speed = 15.0f;
        public Transform Soul;

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            this._rigidbody2D = this.GetComponent<Rigidbody2D>();
        }

        // Use this for initialization
        private void Start()
        {
            this._rigidbody2D.velocity = Vector2.left * this.Speed;
        }

        private void FixedUpdate()
        {
            //if (!this._renderer.isVisible)
            //{
            //    Destroy(this.gameObject);
            //}
        }

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            switch (otherCollider.gameObject.tag)
            {
                case "Weapon":
                    {
                        Weapon weapon = otherCollider.gameObject.GetComponent<Weapon>();
                        if (weapon != null)
                        {
                            if (weapon.AttackState == AttackState.Attacks)
                            {
                                Instantiate(this.Soul, this.transform.position, Quaternion.identity);
                                Destroy(this.gameObject);
                            }
                        }
                    } break;
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }
    }
}
