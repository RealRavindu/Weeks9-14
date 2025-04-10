using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherSafezone : MonoBehaviour
{
    public GameObject catcher;
    private SpriteRenderer sr;
    private Catcher catcherScript;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        catcherScript = catcher.GetComponent<Catcher>();
    }

    // Update is called once per frame
    void Update()
    {

        /*This script is relatively simple since we don't have to keep track of scores or do any other complex calculation. It just resets the coroutine and the timer t of the catcher
         * when it's within the bounds and if not, it calls the function to start a coroutine. This function actually checks if there's already a coroutine running, so it automatically
         * prevents 50 trillion coroutines from being started by this piece of code! :D*/
        if (sr.bounds.Contains(catcher.transform.position))
        {
            catcherScript.t = 0;
            catcherScript.stopTimerCoroutine();
            
            //Debug.Log("catcher is in SF!");
        } else
        {
            //Debug.Log("catcher is out of SF");
            catcherScript.startTimerCoroutine();
        }
    }
}
