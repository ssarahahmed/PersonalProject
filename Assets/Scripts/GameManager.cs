using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameStarted = false;

    public GameObject player;
    public MonoBehaviour playerController;
    public GameObject enemy;
    public MonoBehaviour enemyMovement;
    public GameObject titleScreen;
    public HealthTimer healthTimer;
    public GameObject saveButton;

    private void Start()
    {
        GameStarted = false;
       
        if (playerController != null) playerController.enabled = false;
        if (enemyMovement != null) enemyMovement.enabled = false;
        if (healthTimer != null) healthTimer.enabled = false;
    }

    public void StartGame()
    {
        GameStarted = true;

        if (playerController != null) playerController.enabled = true;
        if (enemyMovement != null) enemyMovement.enabled = true;
        if (healthTimer != null)
        {
            healthTimer.enabled = true;
            healthTimer.StartTimer();
        }

        if (titleScreen != null) titleScreen.SetActive(false);
        if (saveButton != null) saveButton.SetActive(false);
    }
}

