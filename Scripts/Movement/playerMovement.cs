using UnityEngine;

public class playerMovement : MonoBehaviour
{
    bool Clicked = true;
    bool canMove;
    //Vector2 playerSize;

    Rigidbody2D Player;
    Vector2 startingPos;

    // Store transform of the boundary restriciton game object, to get children
    public Transform BoarderHolder;

    // Store current boundary for the player
    Boundary playerBoundary;

    Collider2D playerCollider;

    public decreaseScore decreasingScore;

    // Start is called before the first frame update
    void Start()
    {
        // Distance from the center of the paddle to the edge
        // To get the boarder of the player paddle, the radius
        //playerSize = GetComponent<SpriteRenderer>().bounds.extents;

        // Assigning the rigidbody attached to the player paddle
        // When no specification of which game object the component should be taken
        // Going to be taken from the game object that this script sits on
        // gameObject removed
        Player = GetComponent<Rigidbody2D>();
        startingPos = Player.position;
        playerCollider = GetComponent<Collider2D>();

        // setting the boundary to respective co-ordinates from the child game objects of the boundary holder
        playerBoundary = new Boundary(BoarderHolder.GetChild(0).position.y, // Top boundary, keeps track of y co-ordinate
                                      BoarderHolder.GetChild(1).position.y,
                                      BoarderHolder.GetChild(2).position.x, // Left boundary, keeps track of x co-ordinate
                                      BoarderHolder.GetChild(3).position.x);

    }

    // Update is called once per frame
    void Update()
    {
        // Left mouse button clicked
        if (Input.GetMouseButton(0))
        {
            // Same for all displays, world co-ordinates
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Check if player clicked on screen
            // Specifically when clicking on the player paddle and not somewhere and then paddle jumps to it
            if(Clicked)
            {
                Clicked = false;
                canMove = playerCollider.OverlapPoint(mousePos);
            }

            if (canMove)
            {
                // Restrict the movement
                // Clamp method
                // If the given number is less than min, method will return the min, similarly for the max
                // In between value, the method will output the given number itself, which is the actual mousePos
                Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerBoundary.Left, playerBoundary.Right),
                                                      Mathf.Clamp(mousePos.y, playerBoundary.Bottom, playerBoundary.Top));
                /*changed this: transform.position = mousePos;*/
                // need to change to this so that the physics knows at what velocity the player game object is travelling
                Player.MovePosition(clampedMousePos);
            }
        }

        else
        {
            Clicked = true;
        }
    }

    public void ResetPosition()
    {
        Player.position = startingPos;
    }
}
