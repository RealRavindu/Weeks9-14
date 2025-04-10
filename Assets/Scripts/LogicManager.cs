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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

   

