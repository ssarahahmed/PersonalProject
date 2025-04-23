using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class InstructionManager : MonoBehaviour
{
    public TextMeshProUGUI instructionText;
    private int pageIndex = 0;

    private string[] instructions = new string[]
    {
        "You are a ball come to life, and this is your last chance to escape!",
        "Use the arrow keys to move.",
        "Use the spacebar to jump.",
        "Collect all the cheese to win and escape!",
        "Avoid the enemies and stay full or you’ll lose health.",
        "Good luck! Click Next to begin."
    };

    void Start()
    {
        UpdateInstruction();
    }

    public void NextPage()
    {
        if (pageIndex < instructions.Length - 1)
        {
            pageIndex++;
            UpdateInstruction();
        }
        else
        {
            SceneManager.LoadScene("MiniGame");
        }
    }

    public void PrevPage()
    {
        if (pageIndex > 0)
        {
            pageIndex--;
            UpdateInstruction();
        }
    }

    void UpdateInstruction()
    {
        instructionText.text = instructions[pageIndex];
    }
}
