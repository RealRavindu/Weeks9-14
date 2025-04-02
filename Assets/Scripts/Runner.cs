using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Runner : MonoBehaviour
{
    
    Coroutine outsideZone;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator timer()
    {
        t += Time.deltaTime;
        if (t> 2)
        {
            runnerDeath();
        }
        yield return null;
    }

    public void runnerDeath()
    {
        Debug.Log("Runner death has occured");
    }
}
