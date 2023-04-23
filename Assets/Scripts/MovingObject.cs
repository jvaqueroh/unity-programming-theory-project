using UnityEngine;

namespace Assets.Scripts
{
    public abstract class MovingObject: MonoBehaviour
    {
        [SerializeField] protected readonly float zBoundary = -7.0f;

        protected virtual void Update()
        {
            CheckBoundaries();
            Move();
        }

        protected abstract void Move();

        protected virtual void CheckBoundaries()
        {
            if (transform.position.z < zBoundary)
            {
                OnOutOfBoundaries();
            }
        }

        protected virtual void OnOutOfBoundaries()
        {
            Destroy(gameObject);
        }
    }
}
