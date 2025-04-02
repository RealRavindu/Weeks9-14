using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundScript : MonoBehaviour
{
    SpriteRenderer sr;
    public UnityEvent onClick;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        if (sr.bounds.Contains(mousePos) && Input.GetMouseButtonDown(0))
        {
            onClick.Invoke();
        }
       
    }


}
