using UnityEngine;

public class AImovement : MonoBehaviour
{
    public float MaxMovementSpeed;
    private Rigidbody2D AI;
    private Vector2 startingPosition;

    // hold reference to the rigidbody of the puck
    public Rigidbody2D Puck;

    public Transform PlayerBoarderHolder;
    private Boundary playerBoundary;

    public Transform PuckBoarderHolder;
    private Boundary puckBoundary;

    private Vector2 targetPosition;

    // Don't want the AI to be too exact with it's position to the puck
    private bool firstTimeinOpponetsHalf = true;
    private float offSetXFromTarget;

    public decreaseScore decreasingScore;

    private void Start()
    {
        AI = GetComponent<Rigidbody2D>();
        startingPosition = AI.position;

        playerBoundary = new Boundary(PlayerBoarderHolder.GetChild(0).position.y, // Top boundary, keeps track of x co-ordinate
                                      PlayerBoarderHolder.GetChild(1).position.y,
                                      PlayerBoarderHolder.GetChild(2).position.x, // Left boundary, keeps track of x co-ordinate
                                      PlayerBoarderHolder.GetChild(3).position.x);

        puckBoundary = new Boundary(PlayerBoarderHolder.GetChild(0).position.y, 
                                      PlayerBoarderHolder.GetChild(1).position.y,
                                      PlayerBoarderHolder.GetChild(2).position.x,
                                      PlayerBoarderHolder.GetChild(3).position.x);
    }

    // FixedUpdate(), going to be moving a rigid body which involves physics
    // Updated in regular time intervals
    private void FixedUpdate()
    {
        // AI not move after a goal
        if (!puckScript.wasGoal)
        { 
            float movementSpeed;

            // If the puck is on the other half of the screen (player half), only want to move along the y-axis
            if (Puck.position.y < puckBoundary.Bottom)
            {
                if (firstTimeinOpponetsHalf)
                {
                    firstTimeinOpponetsHalf = false;
                    offSetXFromTarget = Random.Range(-1f, 1f);
                }
                // setting movement speed, smaller than maxMovementSpeed, and random
                movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);

                // startingPositon.y, whenever the puck enters player side of the screen, AI going to move to where it started and only going to move on x-axis
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x + offSetXFromTarget, playerBoundary.Left, playerBoundary.Right), 
                                                    startingPosition.y);
            }
            // puck on AI side of screen, want AI to move to puck
            else
            {
                firstTimeinOpponetsHalf = true;
                movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);

                // target position to make the AI move directly to the puck
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, playerBoundary.Left, playerBoundary.Right),
                                        Mathf.Clamp(Puck.position.y, playerBoundary.Bottom, playerBoundary.Top));
            }

                // Making the rigidbody move
                AI.MovePosition(Vector2.MoveTowards(AI.position, targetPosition, movementSpeed * Time.fixedDeltaTime));

        }
    }

    public void ResetPos()
    {
        AI.position = startingPosition;
    }
}
