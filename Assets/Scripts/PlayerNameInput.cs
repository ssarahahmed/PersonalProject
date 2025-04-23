using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    public InputField playerNameInputField;  
    public string playerName;               

    public void SavePlayerName()
    {
        playerName = playerNameInputField.text;
        PlayerPrefs.SetString("PlayerName", playerName); 
        PlayerPrefs.Save();
    }
}
