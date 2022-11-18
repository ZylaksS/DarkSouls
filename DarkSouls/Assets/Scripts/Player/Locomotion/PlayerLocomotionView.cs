using UnityEngine;

namespace DarkSouls.Player
{
    public class PlayerLocomotionView : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;

        public void UpdateVelocity(Vector3 velocity)
        {
            rigidbody.velocity = velocity;
        }
    }
}