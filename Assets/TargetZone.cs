using UnityEngine;
using System.Collections.Generic;

public class TargetZone : MonoBehaviour
{
    private HashSet<GameObject> ballsInside = new HashSet<GameObject>();
    public int requiredBalls = 3;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballsInside.Add(other.gameObject);
            CheckWin();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballsInside.Remove(other.gameObject);
        }
    }

    void CheckWin()
    {
        if (ballsInside.Count >= requiredBalls)
        {
            Debug.Log("YOU WIN!");
            // Optional: freeze everything or show a big win message
            Time.timeScale = 0f; // freezes the game
        }
    }
}