using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LogicManager : MonoBehaviour
{
    public UnityEvent runnerLeftSF;
    public UnityEvent catcherLeftSF;
    public UnityEvent runnerEnteredSF;
    public UnityEvent catcherEnteredSF;
    public UnityEvent collision;
    public Runner runner;
    public Catcher catcher;
    public GameObject runnerSFPrefab;
    public GameObject catcherSFPrefab;
    public GameObject ground;
    private List<GameObject> runnerSafeZones = new List<GameObject>();
    private List<GameObject> catcherSafeZones = new List<GameObject>();
    public bool isInside = true;
    private int numberOfEmptySFs;
    // Start is called before the first frame update
    /*void Start()
    {
        collision.AddListener(runner.runnerDeath);
        collision.AddListener(catcher.catcherDeath);

        //spawning 2 runner safezones on either side of the ground by multiplying the width of the ground subtracted with it's own scale by -1 and then 1 to get either side of the ground.
        for (int i = -1; i < 2; i += 2)
        {
            GameObject spawnedZone = Instantiate(runnerSFPrefab);
            spawnedZone.transform.position = new Vector3(i * ((ground.transform.localScale.x / 2) - (spawnedZone.transform.localScale.x / 2)), 0, 0);
            runnerSafeZones.Add(spawnedZone);
        }

        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j += 2)
            {
                GameObject spawnedZone = Instantiate(catcherSFPrefab);
                spawnedZone.transform.position = new Vector3(i * ((ground.transform.localScale.x / 2) - (spawnedZone.transform.localScale.x / 2)), j * ((ground.transform.localScale.y / 2) - (spawnedZone.transform.localScale.y / 2)), 0);
                catcherSafeZones.Add(spawnedZone);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (runnerSafeZones[0].GetComponent<SpriteRenderer>().bounds.Contains(runner.transform.position))
        {
            if (!isInside)
            {
                runnerIsInsideSafezone();
            }
        }
        else if (runnerSafeZones[1].GetComponent<SpriteRenderer>().bounds.Contains(runner.transform.position))
        {
            if (!isInside)
            {
                runnerIsInsideSafezone();
            }
        }
        else if (isInside)
        {
            Debug.Log("runner outside");
            runnerLeftSF.Invoke();
            collision.AddListener(callRunnerDeath);
            isInside = false;
        }
        

        foreach (GameObject S in catcherSafeZones)
        {
            if (S.GetComponent<SpriteRenderer>().bounds.Contains(catcher.transform.position))
            {
                catcher.t = 0;
                //Debug.Log("catcher in safezone");
                catcherLeftSF.AddListener(catcher.startTimerCoroutine);
                catcher.StopAllCoroutines();
                break;
            }
            else
            {
                catcherLeftSF.Invoke();
                catcherLeftSF.RemoveAllListeners();
                collision.AddListener(callRunnerDeath);
            }
        }

    }

    public void runnerIsInsideSafezone()
    {
        runner.t = 0;
        collision.RemoveAllListeners();
        runner.StopAllCoroutines();
        Debug.Log("Runner is inside SF");
        isInside = true;
    }
    public void callRunnerDeath()
    {
        runnerDeath.Invoke();
    }


}*/

    private void Start()
    {
        
        //spawning 2 runner safezones on either side of the ground by multiplying the width of the ground subtracted with it's own scale by -1 and then 1 to get either side of the ground.
        for (int i = -1; i < 2; i += 2)
        {
            GameObject spawnedZone = Instantiate(runnerSFPrefab);
            spawnedZone.transform.position = new Vector3(i * ((ground.transform.localScale.x / 2) - (spawnedZone.transform.localScale.x / 2)), 0, 0);
            runnerSafeZones.Add(spawnedZone);
        }

        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j += 2)
            {
                GameObject spawnedZone = Instantiate(catcherSFPrefab);
                spawnedZone.transform.position = new Vector3(i * ((ground.transform.localScale.x / 2) - (spawnedZone.transform.localScale.x / 2)), j * ((ground.transform.localScale.y / 2) - (spawnedZone.transform.localScale.y / 2)), 0);
                catcherSafeZones.Add(spawnedZone);
            }

        }
    }
    private void Update()
    {

        //Going through each runner safezone to check whether runner is inside or not.
        //The bool isInside is being used to make sure the event is only run once.
        //If the runner is outside, the bool isInside = false and if runner is inside, isInside = true.
        //So when the runner goes outside from being inside, the code will run and invoke the event, then flip the boolean so that it won't run again.
        numberOfEmptySFs = 0;
        for(int i=0; i < 2; i++)
        {
            if (runnerSafeZones[i].GetComponent<SpriteRenderer>().bounds.Contains(runner.transform.position))
            {

            } else
            {
                numberOfEmptySFs++;
            }
        }

        if (numberOfEmptySFs < 2)
        {

        }
        
        foreach(GameObject S in runnerSafeZones)
        {
            
            if (S.GetComponent<SpriteRenderer>().bounds.Contains(runner.transform.position) && !isInside)
            {
                
                runnerEnteredSF.Invoke();
                Debug.Log("Invoking runner entered event");
                isInside = true;
            } else
            {
                if (isInside)
                {
                    runnerLeftSF.Invoke();
                    Debug.Log("Invoking runner left event");
                    isInside = false;
                    numberOfEmptySFs++;
                }
            }

        }
        if (numberOfEmptySFs == 2)
        {
            runnerLeftSF.Invoke();
        }
    }

    public void runnerEntersSF()
    {
        Debug.Log("runner entered");
        runner.t = 0;
        runner.StopAllCoroutines();
    }

    public void runnerLeavesSF()
    {
        Debug.Log("runner left");
        runner.t = 0;
        runner.startTimerCoroutine();
        collision.AddListener(runner.runnerDeath);
        collision.AddListener(catcher.catcherDeath);
    }
}
