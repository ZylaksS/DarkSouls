using UnityEngine;

namespace DarkSouls.Player
{
    [CreateAssetMenu(fileName = "Player Locomotion Settings", menuName = "Game/Settings/Player/Locomotion")]
    public class PlayerLocomotionSettings : ScriptableObject
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;

        public float MoveSpeed => moveSpeed;
        public float RotationSpeed => rotationSpeed;
    }
}