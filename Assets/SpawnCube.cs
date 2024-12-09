using System.Collections;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public GameObject[] spawnables;  // Array of spawnable objects
    public float howOften = 2f;      // Time interval between spawns

    private GameManager Manager;

    private void Start()
    {
        GameObject managerObject = GameObject.FindWithTag("GameManager");
        if (managerObject != null)
        {
            Manager = managerObject.GetComponent<GameManager>();
        }
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Get the round value from GameManager
            int currentRound = Manager.round;

            // Adjust the maximum random number based on the current round, aiming for a max of 12 rounds
            int spawnThreshold = Mathf.Clamp(10 + currentRound, 10, 20);  // Adjusts the threshold dynamically

            // Generate a random number based on the round, with more diverse ranges as rounds progress
            int randomNumber = Random.Range(1, spawnThreshold);

            if (randomNumber <= 9)  // More common spawn
            {
                Instantiate(spawnables[0], transform.position, transform.rotation);
            }
            else  // Rare spawn (the further into the game, the more diverse the spawnables)
            {
                int spawnIndex = Mathf.Clamp(randomNumber - 9, 0, spawnables.Length - 1);
                Instantiate(spawnables[spawnIndex], transform.position, transform.rotation);
            }

            // Wait for the specified interval before the next spawn
            yield return new WaitForSeconds(howOften);
        }
    }
}
