using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LogicManager : MonoBehaviour
{
    public UnityEvent runnerDeath;
    public UnityEvent catcherDeath;
    public UnityEvent collision;
    public Runner runner;
    public Catcher catcher;
    public GameObject runnerSFPrefab;
    public GameObject catcherSFPrefab;
    public GameObject ground;
    private List<GameObject> runnerSafeZones = new List<GameObject>();
    private List<GameObject> catcherSafeZones = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //spawning 2 runner safezones on either side of the ground by multiplying the width of the ground subtracted with it's own scale by -1 and then 1 to get either side of the ground.
        for (int i = -1; i < 2; i+=2)
        {
            GameObject spawnedZone = Instantiate(runnerSFPrefab);
            spawnedZone.transform.position = new Vector3(i *( (ground.transform.localScale.x / 2) - (spawnedZone.transform.localScale.x / 2)), 0, 0);
            runnerSafeZones.Add(spawnedZone);
        }

        for (int i = -1; i < 2; i ++)
        {
            for (int j = -1; j < 2; j+=2)
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
        
    }

}
