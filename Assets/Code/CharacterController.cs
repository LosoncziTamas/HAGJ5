using UnityEngine;

namespace Code
{
    public class CharacterController : MonoBehaviour
    {
        public float speed;
        private void Update()
        {
            if (Input.GetButton("Vertical"))
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    transform.position += Vector3.up * speed * Time.deltaTime;
                }
                else
                {
                    transform.position += Vector3.down * speed * Time.deltaTime;
                }
            }
        }
    }
}
