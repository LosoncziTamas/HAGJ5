using UnityEngine;

namespace Code
{
    [CreateAssetMenu]
    public class GameProperties : ScriptableObject
    {
        public float bulletSpeed;
        public float characterSpeed;
        public float characterGravity;
        public Rect boundaries;
    }
}