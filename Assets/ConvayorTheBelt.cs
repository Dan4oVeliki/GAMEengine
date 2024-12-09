using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ConvayorTheBelt : MonoBehaviour
{
    public float speed;
    public GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        other.transform.Translate(target.transform.localPosition * speed * Time.deltaTime);
    }
}
