using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class youSpinMeRightRound : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    public Rigidbody rb;
    [SerializeField] private Vector3 nextPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == startPosition.position) 
        {
            nextPoint = endPosition.position;
        }
        if (transform.position == endPosition.position)
        {
            nextPoint = startPosition.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPoint, Time.deltaTime);
    }
}
