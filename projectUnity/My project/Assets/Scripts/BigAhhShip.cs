using System.Collections;
using UnityEngine;

public class BigAhhShip : MonoBehaviour
{
    public float moveSpeed = 5f;      // Speed of the spaceship movement
    public float rotationSpeed = 2f;  // Speed of the spaceship rotation
    public float sideLength = 20f;     // Length of each side of the square

    private Vector3[] squareCorners;  // Array to store the corners of the square
    private int currentCornerIndex = 0;

    private void Start()
    {
        InitializeSquareCorners();
    }

    private void Update()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        // Move the spaceship towards the current corner
        transform.position = Vector3.MoveTowards(transform.position, squareCorners[currentCornerIndex], moveSpeed * Time.deltaTime);

        // Rotate the spaceship towards the next corner
        Vector3 directionToNextCorner = squareCorners[(currentCornerIndex + 1) % squareCorners.Length] - transform.position;
        Quaternion rotationToNextCorner = Quaternion.LookRotation(directionToNextCorner);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToNextCorner, rotationSpeed * Time.deltaTime);

        // Check if the spaceship has reached the current corner, then move to the next one
        if (Vector3.Distance(transform.position, squareCorners[currentCornerIndex]) < 0.1f)
        {
            currentCornerIndex = (currentCornerIndex + 1) % squareCorners.Length;
        }
    }

    private void InitializeSquareCorners()
    {
        // Calculate the corners of the square based on the initial position
        squareCorners = new Vector3[4];
        squareCorners[0] = transform.position + new Vector3(sideLength / 2, 0, sideLength / 2);
        squareCorners[1] = transform.position + new Vector3(sideLength / 2, 0, -sideLength / 2);
        squareCorners[2] = transform.position + new Vector3(-sideLength / 2, 0, -sideLength / 2);
        squareCorners[3] = transform.position + new Vector3(-sideLength / 2, 0, sideLength / 2);
    }
}
