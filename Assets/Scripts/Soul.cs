using UnityEngine;

namespace Assets.Scripts
{
    public class Soul : MonoBehaviour
    {
        public float Speed = 2.0f;

        private Transform _target;
        private Rigidbody2D _rigidbody2D;
        private ParticleSystem _soulTail;

        private void Awake()
        {
            this._rigidbody2D = this.GetComponent<Rigidbody2D>();
            this._soulTail = this.GetComponentInChildren<ParticleSystem>();
        }

        // Use this for initialization
        private void Start()
        {
            GameObject target = GameObject.FindGameObjectWithTag("SoulBag");
            if (target != null)
            {
                this._target = target.transform;
            }
            else
            {
                Debug.LogError("Soul target not found!");
            }
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            // 1
            //Vector3 direction = this._target.position - this.transform.position;
            //Quaternion rotation = Quaternion.LookRotation(direction);
            //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, 1500 * Time.deltaTime);
            //this._rigidbody2D.velocity = (this.transform.forward * this.Speed * Time.deltaTime);


            // 2
            //Vector3 direction = this._target.position - this.transform.position;
            //direction.Normalize();
            //float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //this.transform.rotation = Quaternion.Euler(0f, 0f, rotation - 90);
            //this._rigidbody2D.velocity = (direction * this.Speed);

            // 3
            var direction = this.transform.position - this._target.position;
            var newRotation = Quaternion.LookRotation(direction, Vector3.forward);
            newRotation.x = 0.0f;
            newRotation.y = 0.0f;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newRotation, Time.deltaTime * 2);
            this._rigidbody2D.velocity = -direction * this.Speed;
        }
    }
}
