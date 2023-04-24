using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveRoad : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private Vector3 initialPosition;
    private float repeatingWidth;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        repeatingWidth = GetComponent<BoxCollider>().size.z / 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < initialPosition.z - repeatingWidth)
        {
            transform.position = initialPosition;
        }

        transform.position = new Vector3(initialPosition.x, initialPosition.y, transform.position.z - Time.deltaTime * speed);
    }
}
