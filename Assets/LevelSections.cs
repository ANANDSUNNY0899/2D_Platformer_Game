using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons;

    void Start()
    {
        for (int i = 1; i < levelButtons.Length; i++)
        {
            if (PlayerPrefs.GetInt("Level" + i, 0) == 0)
            {
                levelButtons[i].interactable = false; // Lock if not completed
            }
        }
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
