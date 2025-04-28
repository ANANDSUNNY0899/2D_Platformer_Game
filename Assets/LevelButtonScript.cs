using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonScript : MonoBehaviour
{
    public int levelIndex; // Assign the level number in Inspector

    private void OnMouseDown()
    {
        SceneManager.LoadScene(levelIndex); // Load assigned level
    }
}
