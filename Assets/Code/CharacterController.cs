using UnityEngine;

namespace Code
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameProperties _gameProperties;

        private Vector3 _startPos;

        private void Awake()
        {
            _startPos = transform.position;
        }

        private void Update()
        {
            var speed = _gameProperties.characterSpeed;
            var gravity = _gameProperties.characterGravity;
            var offset = transform.position.y > _startPos.y ? Vector3.down * gravity * Time.deltaTime : Vector3.zero;
            if (Input.GetButton("Vertical"))
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    offset += Vector3.up * speed * Time.deltaTime;
                }
                else
                {
                    offset += Vector3.down * speed * Time.deltaTime;
                }
            }
            transform.position += offset;
        }
    }
}
