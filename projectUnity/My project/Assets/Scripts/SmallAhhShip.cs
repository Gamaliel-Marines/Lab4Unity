using System.Collections;
using UnityEngine;

public class SmallAhhShip : MonoBehaviour
{
    public float moveSpeed = 5f;      // Speed of the spaceship movement
    public float rotationSpeed = 2f;  // Speed of the spaceship rotation
    public float sideLength = 10f;    // Length of each side of the square

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
        // Move the spaceship towards the previous corner
        transform.position = Vector3.MoveTowards(transform.position, squareCorners[currentCornerIndex], moveSpeed * Time.deltaTime);

        // Rotate the spaceship towards the previous corner
        Vector3 directionToPreviousCorner = squareCorners[(currentCornerIndex - 1 + squareCorners.Length) % squareCorners.Length] - transform.position;
        Quaternion rotationToPreviousCorner = Quaternion.LookRotation(directionToPreviousCorner);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToPreviousCorner, rotationSpeed * Time.deltaTime);

        // Check if the spaceship has reached the previous corner, then move to the previous one
        if (Vector3.Distance(transform.position, squareCorners[currentCornerIndex]) < 0.1f)
        {
            currentCornerIndex = (currentCornerIndex - 1 + squareCorners.Length) % squareCorners.Length;
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
