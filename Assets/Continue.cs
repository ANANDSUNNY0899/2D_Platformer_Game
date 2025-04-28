using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour
{
    public void LoadSavedLevel()
    {
        int savedLevel = PlayerPrefs.GetInt("SavedLevel", 0); // Default: Level 0
        SceneManager.LoadScene(savedLevel);
    }
}
