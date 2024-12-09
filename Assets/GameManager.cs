using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int round = 0;
    public int points = 0;
    public int lives = 0;
    public GameObject[] Conveyors;

    public TextMeshProUGUI Wave;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Points;
    public Animator pointAnim;

    public GameObject EndScreen;
    public TextMeshProUGUI RoundMessageText; // TextMeshProUGUI element for the round message display
    public string[] roundMessages = new string[12]; // List of messages for each round

    private void Start()
    {
        for (int i = 1; i < Conveyors.Length; i++)
        {
            Conveyors[i].SetActive(false); // Make sure all conveyors are disabled except the first one
        }
    }

    public void WRONG(int dmg)
    {
        lives -= dmg;
        Health.text = "Health: " + lives.ToString();
        if (lives <= 0)
        {
            EndScreen.SetActive(true);
            foreach (GameObject go in Conveyors)
            {
                go.SetActive(false);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Correct(int up)
    {
        points += up;
        Points.text = points.ToString();
        pointAnim.SetTrigger("NewScore");
    }

    void Update()
    {
        if (round > 0 && round % 2 == 0) // Every 2 rounds
        {
            int conveyorIndex = round / 2; // Determines which conveyor should be activated

            if (conveyorIndex < Conveyors.Length)
            {
                Conveyors[conveyorIndex].SetActive(true); // Activate the next conveyor
            }
        }

        // Define the point thresholds for each round
        int roundThreshold = 500; // Start threshold for round 1
        float difficultyMultiplier = 1.7f; // Increase difficulty by 50% per round

        // Determine the round based on points
        for (int i = 1; i <= 12; i++)
        {
            if (points >= roundThreshold)
            {
                round = i; // Set the round based on the point threshold
            }
            roundThreshold = Mathf.RoundToInt(roundThreshold * difficultyMultiplier); // Increase the threshold for the next round
        }

        Wave.text = "Round: " + round.ToString(); // Update wave display

        // Display the message when the round changes
        DisplayRoundMessage();
    }

    void DisplayRoundMessage()
    {
        if (round > 0 && round <= roundMessages.Length)
        {
            RoundMessageText.text = roundMessages[round - 1]; // Set the round message based on the round number
        }
    }
}