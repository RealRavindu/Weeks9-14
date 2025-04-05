using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Runner : MonoBehaviour
{
    Coroutine outsideZone;
    SpriteRenderer sr;
    float speed = 5f;
    float t;
    // Start is called before the first frame update
    void Start()
    {
       sr = gameObject.GetComponent<SpriteRenderer>();
       outsideZone = StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

    }

    public IEnumerator timer()
    {
        while (true)
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
            if (t > 5)
            {
                runnerDeath();
                StopCoroutine(outsideZone);
            }
            yield return null;
        }
        
    }

    public void runnerDeath()
    {
        Debug.Log("Runner death has occured");
    }
}
