using UnityEngine;
using TMPro;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public LeaderboardManager leaderboardManager;
    public TextMeshProUGUI finalScoreText;

    private int cheeseCount = 0;
    private string playerName;

    void Start()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "Guest");
        cheeseCount = PlayerPrefs.GetInt("CheeseCount", 0);

        if (finalScoreText != null)
        {
            finalScoreText.text = "Cheese Count: " + cheeseCount;
        }

        if (leaderboardManager != null)
        {
            leaderboardManager.AddScore(playerName, cheeseCount);
        }
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
