using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Runner : MonoBehaviour
{
    Coroutine testingcrs;
    Coroutine outsideZone;
    SpriteRenderer sr;
    public float speed = 5f;
    public float t;
    private bool isAlive=true;
    // Start is called before the first frame update
    void Start()
    {

        testingcrs = StartCoroutine(testing());
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && isAlive)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) && isAlive)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && isAlive)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) && isAlive)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

    }

    public IEnumerator timer()
    {
        Debug.Log("RUNNER TIMER HAS BEEN STARTED");
        while (t<5)
        {
            t += Time.deltaTime;
            float green = sr.color.g - (0.24f * Time.deltaTime);
            float blue = sr.color.b - (0.24f * Time.deltaTime);
            
            //if statement used to get when objects were completely red
            if (sr.color.g < 0)
            {
                //Debug.Log("Time for catcher red: " + t);
            }

            Color modifiedColor = new Color(sr.color.r, green, blue);
            sr.color =modifiedColor;
            yield return null;
        }
        runnerDeath();
        
    }

    public IEnumerator testing()
    {
        while (true)
        {
            Debug.Log("test");
            yield return null;
        }
    }

    public void startTimerCoroutine()
    {
        outsideZone = StartCoroutine(timer());
    }

    public void testingEvent()
    {
        Debug.Log("EVENT IS PROCCING");
    }
    public void runnerDeath()
    {
        isAlive = false;
        Debug.Log("Runner death has occured");
    }
}
