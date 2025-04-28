using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    private LevelManager levelManager;

    void Start()
    {
        levelManager = Object.FindFirstObjectByType<LevelManager>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelManager.CompleteLevel();
        }
    }
}
