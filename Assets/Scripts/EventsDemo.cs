using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsDemo : MonoBehaviour
{
    public Transform banana;
    public UnityEvent OnTimerHasFinished;
    public float timerLength = 3;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if( t> timerLength)
        {
            OnTimerHasFinished.Invoke();
            t = 0;
        }
    }
    public void MouseJustEnteredImage()
    {
        Debug.Log("The mouse just entered");
        banana.localScale = Vector3.one * 1.2f;
    }
    public void MouseJustLeftedImage()
    {
        Debug.Log("The mouse just lefted");
        banana.localScale = Vector3.one;
    }
}
