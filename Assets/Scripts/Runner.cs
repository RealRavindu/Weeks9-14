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
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        outsideZone = null;
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

    /*The timer coroutine of the runner that runs until it reaches 5 seconds and changes the color of the object according to the time. If the coroutine reaches
     * more than 5 seconds, it breaks out of the loop and the runner dies.*/
    public IEnumerator timer()
    {
        while (t < 5)
        {
            //Debug.Log("Runner timer is ticking: " + t);
            t += Time.deltaTime;
            colorChanger();
            yield return null;
        }
        runnerDeath();

    }

    /*The start timer coroutine function first checks if there is no coroutine already running before starting a new one.*/
    public void startTimerCoroutine()
    {
        if(outsideZone == null)
        {
            outsideZone = StartCoroutine(timer());
        }
    }

    /*The stop timer CR function first checks if there is a coroutine running, then it ends it and sets the CR variable 'outsideZone' to null so that it's empty*/
    public void stopTimerCoroutine()
    {
        if (outsideZone != null)
        {
            StopCoroutine(outsideZone);
            outsideZone = null;
        }
    }

    /*The color changer function first creates two floats called green and blue. The way I thought of going about this was by reducing the green and blue values gradually.
     * Since color in unity goes from 0 to 1 and not 0 to 255 like in processing, I had to essentially go from 1 to 0 in 5 seconds. So I took t and divided it by 5 so that
     * when it reaches 5, it's essentially reaching 1 and then I subtracted that value from 1 so that it's decreasing and not increasing from 0 to 1.
     * This value is then set to green and blue. I then make a new color called modifiedColor which is the sprite's red and then the new green and blue float.
     * then I set the sprite renderer's color to that new color.*/
    public void colorChanger()
    {
        float green = (1 - t / 5f);
        float blue = (1 - t / 5f);
        Color modifiedColor = new Color(sr.color.r, green, blue);
        sr.color = modifiedColor;
    }

    /*Sets the bool isAlive to false so the player cannot move and stops the coroutine so that t doesn't tick anymore and the gameObject doesn't get any redder.*/
    public void runnerDeath()
    {
        isAlive = false;
        StopCoroutine(outsideZone);
    }
}
