using System.Collections;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public GameObject spawnable;        // Common object to spawn
    public GameObject rareSpawnable;   // Rare object to spawn
    public float howOften = 2f;        // Time interval between spawns

    void Start()
    {
        // Start the coroutine to spawn objects
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Generate a random number between 1 and 10
            int randomNumber = Random.Range(1, 11);

            if (randomNumber < 2) // Rare spawn with 10% chance
            {
                Instantiate(rareSpawnable, transform.position, transform.rotation);
            }
            else // Common spawn for other cases
            {
                Instantiate(spawnable, transform.position, transform.rotation);
            }

            // Wait for the specified interval before the next spawn
            yield return new WaitForSeconds(howOften);
        }
    }
}
