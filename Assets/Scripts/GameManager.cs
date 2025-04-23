using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public MonoBehaviour playerController;
    public GameObject enemy;
    public MonoBehaviour enemyMovement;
    public GameObject titleScreen;
    public HealthTimer healthTimer;


    public void StartGame()
    {
        playerController.enabled = true;
        enemyMovement.enabled = true;
        titleScreen.SetActive(false);
        healthTimer.StartTimer();
    }

}
