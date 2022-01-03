using UnityEngine;

namespace Code
{
    public class Move : MonoBehaviour
    {
        public Vector2 direction;
        public float speed;
        
        public void Update()
        {
            transform.position += (Vector3)(direction * Time.deltaTime * speed);
        }
    }
}
