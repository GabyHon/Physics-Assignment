using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puckScript : MonoBehaviour
{
    // Creating the instance of the scoring script
    public ScoringScript ScoreScriptInstance;
    public decreaseScore DecreaseScoreScriptInstance;
    public static bool wasGoal { get; private set; }

    public float MaxSpeed;

    //keeping track of the rigidbody
    private Rigidbody2D rigidBod;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBod = GetComponent<Rigidbody2D>();
        wasGoal = false;
    }

    private void OnTriggerEnter2D(Collider2D crossedGoal)
    {
        // don't want goals before the puck is reset to starting position after a previous goal
        if (!wasGoal)
        {
            if (crossedGoal.tag == "AIGoal")
            {
                ScoreScriptInstance.Increment(ScoringScript.Score.PlayerScore);
                //DecreaseScoreScriptInstance.Increment(decreaseScore.Score.PlayerScore);
                wasGoal = true;
                StartCoroutine(ResetPuck(false));
            }
            else if (crossedGoal.tag == "PlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoringScript.Score.AiScore);
                wasGoal = true;
                StartCoroutine(ResetPuck(true));
            }
        }
    }

    private IEnumerator ResetPuck(bool didTheAIScore)
    {
        // number is the amount of seconds to wait
        yield return new WaitForSecondsRealtime(0.5f);
        wasGoal = false;

        // reset position and velocity of the rigidbody
        rigidBod.velocity = rigidBod.position = new Vector2(0, 0);

        if (didTheAIScore)
            rigidBod.position = new Vector2(-2, 0);
        else
            rigidBod.position = new Vector2(2, 0);
    }

    public void RecentrePuck()
    {
        rigidBod.position = new Vector2(-0.09f, 0.04f);
    }

    private void FixedUpdate()
    {
        rigidBod.velocity = Vector2.ClampMagnitude(rigidBod.velocity, MaxSpeed);
    }
}
