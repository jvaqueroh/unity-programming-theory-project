using UnityEngine;

namespace Assets.Scripts
{
    public abstract class MovingObject: MonoBehaviour
    {
        [SerializeField] protected readonly float zBoundary = -7.0f;

        protected virtual void Update()
        {
            Debug.Log("MovingObject.Update");
            CheckBoundaries();
        }

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
