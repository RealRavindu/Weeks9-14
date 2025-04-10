using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSafezone : MonoBehaviour
{
    public GameObject runner;
    private SpriteRenderer sr;
    private Runner runnerScript;
    public GameObject otherSafezone;
    public LogicManager logicManager;
    private RunnerSafezone otherSfScript;
    private bool triggered;
    public bool wasHere;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        runnerScript = runner.GetComponent<Runner>();
        otherSfScript = otherSafezone.GetComponent<RunnerSafezone>();
    }

    // Update is called once per frame
    void Update()
    {
        /* This if statement checks if the runner is within it's bounds. If it is, then it resets the runners time to 0 and calls a function that stops the running coroutine IF,
         * there is a running coroutine. It then removes all listeners from the collision event, so that even if the catcher runs into the runner and triggers it, nothing
         * ends up happening. The 'wasHere' boolean is used to communicate between the 2 runner safezones. When the runner enters safezone A, A tells B that the runner has entered by
         * turning it's 'wasHere' boolean to false and turning A's own bool to true. The addScore() function will only get called if the runner wasn't here, i.e. when they FIRST enter
         * the safezone. This way I can regulate how often the score gets added. the boolean triggered at the end is used so that I don't add 50 trillion listeners to the collision event.
         * Once I add listeners it sets the boolean to true so that it doesn't run again. This boolean is only set to false when the script removes all listeners. */
        if (sr.bounds.Contains(runner.transform.position))
        {
            runnerScript.t = 0;
            runnerScript.stopTimerCoroutine();
            logicManager.collision.RemoveAllListeners();
            if (!wasHere)
            {
                logicManager.addScore();
            }
            if(otherSafezone != null)
            {
                otherSfScript.wasHere = false;
                wasHere = true;
            }
            triggered = false;


            Debug.Log("runner is in SF!");
        } else
        {
            Debug.Log("Runner is not in SF");
            runnerScript.startTimerCoroutine();
            if (!triggered)
            {
                logicManager.addCollisionListeners();
                triggered = true;
            }
        }


    }
}
