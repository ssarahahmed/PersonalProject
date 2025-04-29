using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    public GameObject leaderboardEntryPrefab;  
    public Transform leaderboardContainer;    
    public TextMeshProUGUI leaderboardTitle;   

    private List<LeaderboardEntry> leaderboard = new List<LeaderboardEntry>();

    [System.Serializable]
    public class LeaderboardEntry
    {
        public string playerName;
        public int cheeseCount;
    }

    void Start()
    {
      /*  leaderboard.Add(new LeaderboardEntry { playerName = "Player1", cheeseCount = 150 });
        leaderboard.Add(new LeaderboardEntry { playerName = "Player2", cheeseCount = 120 });
        leaderboard.Add(new LeaderboardEntry { playerName = "Player3", cheeseCount = 100 });

        leaderboard.Sort((x, y) => y.cheeseCount.CompareTo(x.cheeseCount));

        PopulateLeaderboard(); */
    }

    void PopulateLeaderboard()
    {
        foreach (Transform child in leaderboardContainer)
        {
            Destroy(child.gameObject);  
        }

        foreach (LeaderboardEntry entry in leaderboard)
        {
            GameObject entryObj = Instantiate(leaderboardEntryPrefab, leaderboardContainer);
            TextMeshProUGUI text = entryObj.GetComponent<TextMeshProUGUI>();
            text.text = entry.playerName + ": " + entry.cheeseCount;
        }
    }

    public void AddScore(string playerName, int cheeseCount)
    {
        leaderboard.Add(new LeaderboardEntry { playerName = playerName, cheeseCount = cheeseCount });
        leaderboard.Sort((x, y) => y.cheeseCount.CompareTo(x.cheeseCount));
        PopulateLeaderboard();
    }
}
