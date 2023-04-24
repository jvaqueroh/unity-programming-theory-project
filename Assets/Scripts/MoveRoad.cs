using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < initialPosition.z - 50.0f)
        {
            transform.position = initialPosition;
        }

        transform.position = new Vector3(initialPosition.x, initialPosition.y, transform.position.z - Time.deltaTime * speed);
    }
}
