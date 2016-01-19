using UnityEngine;

namespace Assets.Scripts
{
    public class SoulBag : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            switch (otherCollider.gameObject.tag)
            {
                case "Soul":
                    {
                        GameManager.Instance.CollectSoul();
                        Destroy(otherCollider.gameObject);
                    }
                    break;
            }
        }
    }
}
