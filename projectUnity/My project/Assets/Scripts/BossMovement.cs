using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 10f; // Adjust the rotation speed as needed

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its own Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
