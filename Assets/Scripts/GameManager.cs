using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { Menu, Playing, GameOver }

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;

    public GameState State { get; private set; }
    public int Score { get; private set; }
    public int HighScore { get; private set; }

    public bool IsGameOver => State == GameState.GameOver;

    private const string HighScoreKey = "HighScore";

    private void Awake()
    {
        Instance = this;
        HighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        State = GameState.Menu;
        Time.timeScale = 0f;

        if (startPanel != null) startPanel.SetActive(true);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    public void StartGame()
    {
        if (State != GameState.Menu) return;

        State = GameState.Playing;
        Time.timeScale = 1f;

        if (startPanel != null) startPanel.SetActive(false);
    }

    public void AddScore()
    {
        if (State != GameState.Playing) return;
        Score++;
    }

    public void GameOver()
    {
        if (State == GameState.GameOver) return;

        State = GameState.GameOver;
        Time.timeScale = 0f;

        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt(HighScoreKey, HighScore);
            PlayerPrefs.Save();
        }

        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}