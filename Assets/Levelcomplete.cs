using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("Level" + currentLevel, 1); // Mark level as completed
            SceneManager.LoadScene(currentLevel + 1); // Load next level
        }
    }
}
