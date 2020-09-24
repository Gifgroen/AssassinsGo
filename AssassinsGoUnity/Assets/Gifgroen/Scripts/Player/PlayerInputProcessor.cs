using UnityEngine;
using UnityEngine.InputSystem;

namespace Gifgroen.Player
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerInputProcessor : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private PlayerController playerController;
#pragma warning restore 0649

        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
        }

        // ReSharper disable once UnusedMember.Global
        public void Move(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }

            var input = context.ReadValue<Vector2>();
            if (input.x != 0)
            {
                if (input.x < 0f)
                {
                    playerController.MoveLeft();
                }
                else if (input.x > 0f)
                {
                    playerController.MoveRight();
                }
            }
            else if (input.y != 0)
            {
                if (input.y < 0f)
                {
                    playerController.MoveBackward();
                }
                else if (input.y > 0f)
                {
                    playerController.MoveForward();
                }
            }
        }
    }
}