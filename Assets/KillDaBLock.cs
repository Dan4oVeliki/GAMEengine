using System.Collections;
using UnityEngine;

public class KillDaBlock : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        Killed killedComponent = collision.gameObject.GetComponent<Killed>();

        if (killedComponent != null)
        {
            if (collision.gameObject.CompareTag("Square"))
            {
                Manager.Correct(killedComponent.points);
            }
            else
            {
                Manager.WRONG(killedComponent.lives);
            }

            Destroy(collision.gameObject);
        }
        else
        {
            Debug.LogWarning("Collided object does not have the Killed component: " + collision.gameObject.name);
        }
    }
}
