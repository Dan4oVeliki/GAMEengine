using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvayorTheBelt : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        other.transform.Translate(new Vector3(1f,0f,0f) * speed * Time.deltaTime);
    }
}
