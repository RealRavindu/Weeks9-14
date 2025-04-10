using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Unity.Collections.Unicode;

public class Runner : MonoBehaviour
{
    public Coroutine outsideZone;
    SpriteRenderer sr;
    public float speed = 5f;
    public float t;
    private bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {

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
        while (t < 5)
        {
            Debug.Log("Runner timer is ticking: " + t);
            t += Time.deltaTime;
            colorChanger();
            yield return null;
        }
        runnerDeath();

    }


    public void startTimerCoroutine()
    {
        Debug.Log("Runner timer coroutine is started using function");
        outsideZone = StartCoroutine(timer());
    }

    public void stopTimerCoroutine()
    {
        if (outsideZone != null)
        {
            StopCoroutine(outsideZone);
        }
    }

    public void colorChanger()
    {
        float green = (1 - t / 5f);
        float blue = (1 - t / 5f);

        //if statement used to get when objects were completely red
        if (sr.color.g < 0)
        {
            //Debug.Log("Time for catcher red: " + t);
        }

        Color modifiedColor = new Color(sr.color.r, green, blue);
        sr.color = modifiedColor;
    }
    public void runnerDeath()
    {
        isAlive = false;
        Debug.Log("Runner death has occured");
    }
}
