using UnityEngine;
using System.Collections;

public class MoveTarget : MonoBehaviour
{
    // Define the points along the path in local space
    public Vector3[] pathPoints;

    // Speed of movement
    public float speed = 3.0f;

    public float time_paused = 1.0f;

    // Index of the current point
    private int currentPoint = 1;

    // Start position of the object
    private Vector3 startPosition;

    // Boolean to determine the direction (true = forward, false = backward)
    private bool movingForward = true;

    // Store the total number of points
    private int totalPoints;

    private Vector3 distancepoint;

    // A flag to check if we are waiting for the pause
    private bool isPaused = false;

    private void Start()
    {
        // Initialize total points and position
        totalPoints = pathPoints.Length;
        startPosition = transform.position;

        distancepoint = startPosition - pathPoints[0];
    }

    private void Update()
    {
        if (!isPaused)
        {
            MoveAlongPath();
        }
    }

    private void MoveAlongPath()
    {
        // Calculate the target point position
        Vector3 targetPoint = pathPoints[currentPoint] + distancepoint;

        // Move towards the target point
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);

        // If the object reaches the target point, go to the next point
        if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
        {
            StartCoroutine(PauseBeforeNextPoint());
        }
    }

    private IEnumerator PauseBeforeNextPoint()
    {
        // Pause for 1 second
        isPaused = true;
        yield return new WaitForSeconds(time_paused);
        isPaused = false;

        // Change the current point after the pause
        if (movingForward)
        {
            currentPoint++;
            // If we reach the last point, start moving backward
            if (currentPoint == totalPoints - 1)
            {
                movingForward = false; // Start moving backward
            }
        }
        else
        {
            currentPoint--;
            // If we reach the first point, start moving forward again
            if (currentPoint == 0)
            {
                movingForward = true; // Start moving forward
            }
        }
    }
}
