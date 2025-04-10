using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public UnityEvent collision;
    public Runner runner;
    public Catcher catcher;
    public int score = -1;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*checks for collision between players by calculating the distance between their positions using magnitude.
         * Uses the scale of the square sprite as a condition for if they touch or not.
         * If there is a collision, the event 'collision' gets invoked which has 2 listeners subscribed to it. both listeners 'un-alive' their respective objects,
         * which disables their movement. It also stops the coroutine, which stops them from getting any more bashful than they already are (red).
         */
        float distance = (runner.transform.position - catcher.transform.position).magnitude;
        if (distance < catcher.transform.localScale.x)
        {
            //Debug.Log("Collision");
            collision.Invoke();
        }


        /* This if statement checks for if either catcher or runner are alive, and even if one of them's dead it manipulates the text to show up in the center of the screen
         * and increases the size.
         * It also specifically checks to see if the runner is alive or not, and if they're dead it says 'runner loses', if not 'runner wins' because the only possibility is that
         * the catcher died. If both of them died, it doesn't matter because at the end of the day, the runner has to live. In this game, the catcher needs to adopt the mentality
         * 'if I'm going down, you're going down with me.'... It's a bit hardcore this game.
         */
        if (!runner.isAlive || !catcher.isAlive)
        {
            scoreText.rectTransform.position = Vector2.zero;
            scoreText.rectTransform.localScale = Vector2.one* 5;

            if (!runner.isAlive)
            {
                scoreText.text = "Runner loses: " + score;
            } else
            {
                scoreText.text = "Runner wins: " + score;
            }
        }
    }

    /*Interesting thing about the score is that the way the game's set up, the runner immediately detects itself as entering one of the safezones and gives himself a pat on the back with
     * a +1. So I could have just changed the 'wasHere' boolean to start off as true, but instead made the score start as -1, so it cancels out that initial first point...*/
     
    public void addScore()
    {
        score++;
        scoreText.text = score.ToString(); 

    }

    /*Since I had no way of measuring how many listeners are attached to an event, I had to use the triggered boolean to make sure I didn't add 50 trillion listeners here from this
     * function */
    public void addCollisionListeners()
    {
        //Debug.Log("Collision event listeners added");
        collision.AddListener(runner.runnerDeath);
        collision.AddListener(catcher.catcherDeath);
    }

    
}

   

