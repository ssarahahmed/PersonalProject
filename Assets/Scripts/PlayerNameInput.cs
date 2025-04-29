using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNameInput : MonoBehaviour
{
    public TMP_InputField playerNameInputField;  
    private string playerName;

  /*  void Start()
    {
        playerNameInputField.onValueChanged.AddListener(delegate { SavePlayerName(); });
    }*/

    public void SavePlayerName()
    {
        playerName = playerNameInputField.text;  
        PlayerPrefs.SetString("PlayerName", playerName);  
        PlayerPrefs.Save();  
    }

}
