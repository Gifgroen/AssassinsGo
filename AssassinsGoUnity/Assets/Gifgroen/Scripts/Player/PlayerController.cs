using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using JetBrains.Annotations;

namespace Gifgroen.Player
{
    public class PlayerController : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private Vector3 destination;

        [SerializeField] private float tileSizeMoveDistance = 2f;

        [SerializeField] private bool isMoving = false;
        
#pragma warning restore 0649

        public Vector3 CurrentDestination => destination;

        public TweenerCore<Vector3, Vector3, VectorOptions> MoveForward()
        {
            return Move(Vector3.forward * tileSizeMoveDistance);
        }

        public TweenerCore<Vector3, Vector3, VectorOptions> MoveBackward()
        {
            return Move(Vector3.back * tileSizeMoveDistance);
        }

        public TweenerCore<Vector3, Vector3, VectorOptions> MoveLeft()
        {
            return Move(Vector3.left * tileSizeMoveDistance);
        }

        public TweenerCore<Vector3, Vector3, VectorOptions> MoveRight()
        {
            return Move(Vector3.right * tileSizeMoveDistance);
        }

        [CanBeNull]
        private TweenerCore<Vector3, Vector3, VectorOptions> Move(Vector3 newPos, float duration = 0.24f)
        {
            if (isMoving)
            {
                return null;
            }
                
            destination = transform.position + newPos;
            return transform.DOMove(destination, duration)
                .OnStart(() => isMoving = true)
                .OnComplete(() => isMoving = false);
        }
    }
}