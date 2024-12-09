using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DAKILL : MonoBehaviour
{
    private GameManager Manager;

    private void Start()
    {
        GameObject managerObject = GameObject.FindWithTag("GameManager");
        if (managerObject != null)
        {
            Manager = managerObject.GetComponent<GameManager>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != null)
        {
            if (other.gameObject.CompareTag("Square"))
            {
                Manager.WRONG(other.gameObject.GetComponent<Killed>().lives);
            }
            else
            {
                Manager.Correct(other.gameObject.GetComponent<Killed>().points);
            }
        }
        Destroy(other.gameObject);
    }
}
