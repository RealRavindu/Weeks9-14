using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSafezone : MonoBehaviour
{
    public GameObject runner;
    private SpriteRenderer sr;
    private Runner runnerScript;
    public GameObject otherSafezone;
    private RunnerSafezone otherSfScript;
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
        if (sr.bounds.Contains(runner.transform.position))
        {
            runnerScript.t = 0;
            runnerScript.stopTimerCoroutine();
            otherSfScript.wasHere = false;
            wasHere = true;
            Debug.Log("runner is in SF!");
        }
    }
}
