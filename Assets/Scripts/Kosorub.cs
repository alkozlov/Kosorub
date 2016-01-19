using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Kosorub : MonoBehaviour
    {
        public float Speed = 15.0f;
        public Transform LeftArm;
        public Transform RightArm;
        public Transform CurrentWeapon;
        public AudioClip AttackAudioClip;

        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private Weapon _currentWeapon;

        // Start first
        private void Awake()
        {
            this._rigidbody2D = this.GetComponent<Rigidbody2D>();
            this._animator = this.GetComponent<Animator>();
        }

        // Use this for initialization
        private void Start()
        {
            this.InitializeWeapon();
        }

        private void Update()
        {
            this.MoveProcessing();
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                SoundManager.Instance.PlaySingle(this.AttackAudioClip);
                this._animator.SetTrigger("AttackTrigger");
            }
        }

        #region Helpers

        private void MoveProcessing()
        {
            float directionX = Input.GetAxis("Horizontal");
            float directionY = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(this.Speed * directionX, this.Speed * directionY);
            this._rigidbody2D.velocity = movement;
        }

        private void InitializeWeapon()
        {
            if (this.CurrentWeapon != null)
            {
                Transform weapon = Instantiate(this.CurrentWeapon);
                this._currentWeapon = weapon.GetComponent<Weapon>();
                this._currentWeapon.AttachTo(this.RightArm);
            }
        }

        private void SetAttackStatus(AttackState attackState)
        {
            this._currentWeapon.AttackState = attackState;
        }

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            switch (otherCollider.gameObject.tag)
            {
                case "Enemy":
                    {
                        GameManager.Instance.DamagePlayer(1);
                        Destroy(otherCollider.gameObject);
                    } break;
            }
        }

        #endregion
    }
}
