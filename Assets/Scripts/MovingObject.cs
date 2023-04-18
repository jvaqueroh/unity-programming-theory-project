using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class MovingObject: MonoBehaviour
    {
        [SerializeField] private readonly float zBoundary = -7.0f;

        protected virtual void CheckBoundaries()
        {
            if (transform.position.z < zBoundary)
            {
                Destroy(gameObject);
            }
        }
    }
}
