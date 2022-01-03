using System;
using UnityEngine;

namespace Code
{
    public class CheckBoundaries : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider2D;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("OnTriggerEnter2D");
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("OnTriggerExit2D");
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            Debug.Log("OnTriggerStay2D");
        }
    }
}
