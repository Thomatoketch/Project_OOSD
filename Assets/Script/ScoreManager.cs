using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;

    public static void AddPoints(int points)
    {
        score += points;
        Debug.Log("Points: " + score);
    }
}
