using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class clockTimer : MonoBehaviour
{
    public List<Transform> hands;
    public UnityEvent chimeAlert;
    public float t;
    public float hourDuration = 3;
    public float rotationSpeed = 100;
    private Vector3 minimumOffset = new Vector3(0, 0, 1);
    private Vector3 maximumOffset = new Vector3(0, 0, -1);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform r in hands)
        {
            Vector3 currentRotation = r.eulerAngles;
            currentRotation.z += -rotationSpeed * Time.deltaTime;
            r.eulerAngles = currentRotation;
            if (r.eulerAngles.z > maximumOffset.z && r.eulerAngles.z < minimumOffset.z )
            {
                chimeAlert.Invoke();
            }
        }
    }
}
