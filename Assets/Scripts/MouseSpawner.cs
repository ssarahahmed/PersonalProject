using UnityEngine;

public class MouseSpawner : MonoBehaviour
{
    public GameObject mousePrefab;
    public Transform player;
    public float spawnInterval = 10f;
    public Transform[] spawnPoints;

    void Start()
    {
        if (!GameManager.GameStarted) return;

        InvokeRepeating(nameof(SpawnMouse), 2f, spawnInterval);
    }

    void SpawnMouse()
    {
        if (spawnPoints.Length == 0 || player == null || mousePrefab == null)
            return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject mouse = Instantiate(mousePrefab, spawnPoint.position, spawnPoint.rotation);

        AIMouseController controller = mouse.GetComponent<AIMouseController>();
        if (controller != null)
        {
            controller.player = player;
        }
    }
}
