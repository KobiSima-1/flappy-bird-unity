using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool IsGameOver { get; private set; }

    public int Score { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        if (IsGameOver) return;

        IsGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Game Over!");
    }

    public void AddScore()
    {
        if (IsGameOver) return;
        Score++;
        Debug.Log("Score: " + Score);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}