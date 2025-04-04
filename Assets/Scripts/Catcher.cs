using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    public Coroutine outsideZone;
    private float speed = 5f;
    public GameObject runner;
    public SpriteRenderer sr;
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
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

    }

    public IEnumerator timer()
    {
        while (true)
        {
            t += Time.deltaTime;
            float green = sr.color.g - (0.32f * Time.deltaTime);
            float blue = sr.color.b - (0.32f * Time.deltaTime);
            if (sr.color.g < 0)
            {
                Debug.Log("Time for catcher red: " + t);
            }
            Color modifiedColor = new Color(sr.color.r, green, blue);
            sr.color = modifiedColor;
            if (t > 3.5f)
            {
                catcherDeath();
                StopCoroutine(outsideZone);
            }
            yield return null;
        }

    }

    public void catcherDeath()
    {
        Debug.Log("Catcher died!");
    }
}
