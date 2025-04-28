// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class LevelManager : MonoBehaviour
// {
//     public GameObject[] levelPrefabs;
//     public GameObject backgroundPrefab;
//     public GameObject cloudPrefab;
//     public GameObject mountainPrefab;

//     private GameObject backgroundInstance;
//     private GameObject cloudInstance;
//     private GameObject mountainInstance;
//     private int currentLevelIndex;
//     private GameObject currentLevelInstance;
//     public Transform player;
//     private Rigidbody2D playerRb;
//     private Transform cameraTransform;

//     void Start()
//     {
//         currentLevelIndex = PlayerPrefs.GetInt("UnlockedLevel", 0);
//         playerRb = player.GetComponent<Rigidbody2D>();
//         cameraTransform = Camera.main.transform;
//         LoadBackgroundLayers();
//         LoadLevel(currentLevelIndex);
//     }

//     void LoadBackgroundLayers()
//     {
//         backgroundInstance = CreateLayer(backgroundPrefab, -3);
//         cloudInstance = CreateLayer(cloudPrefab, -2);
//         mountainInstance = CreateLayer(mountainPrefab, -1);
//     }

//     void LoadLevel(int index)
//     {
//         if (index < levelPrefabs.Length)
//         {
//             if (currentLevelInstance != null)
//             {
//                 Destroy(currentLevelInstance);
//             }
//             currentLevelInstance = Instantiate(levelPrefabs[index], Vector3.zero, Quaternion.identity);
//             ResetPlayerPosition();
//         }
//         else
//         {
//             Debug.Log("All levels completed!");
//         }
//     }

//     public void SelectLevel(int levelIndex)
//     {
//         PlayerPrefs.SetInt("UnlockedLevel", levelIndex);
//         PlayerPrefs.Save();
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads the game scene
//     }

//     void ResetPlayerPosition()
//     {
//         if (player != null)
//         {
//             playerRb.linearVelocity = Vector2.zero;
//             player.position = new Vector3(-38.72f, 24.8f, player.position.z);
//         }
//     }

//     public void CompleteLevel()
// {
//     currentLevelIndex++;
//     PlayerPrefs.SetInt("UnlockedLevel", currentLevelIndex);
//     PlayerPrefs.Save();
//     LoadLevel(currentLevelIndex);
// }

// }








using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelPrefabs;
    public GameObject backgroundPrefab;
    public GameObject cloudPrefab;
    public GameObject mountainPrefab;

    private GameObject backgroundInstance;
    private GameObject cloudInstance;
    private GameObject mountainInstance;
    private int currentLevelIndex;
    private GameObject currentLevelInstance;
    public Transform player;
    private Rigidbody2D playerRb;
    private Transform cameraTransform;

    void Start()
    {
        currentLevelIndex = PlayerPrefs.GetInt("UnlockedLevel", 0);
        playerRb = player.GetComponent<Rigidbody2D>();
        cameraTransform = Camera.main.transform;
        LoadBackgroundLayers();
        LoadLevel(currentLevelIndex);
    }

    void LoadBackgroundLayers()
    {
        backgroundInstance = CreateLayer(backgroundPrefab, -3);
        cloudInstance = CreateLayer(cloudPrefab, -2);
        mountainInstance = CreateLayer(mountainPrefab, -1);
    }

    // ✅ Added missing CreateLayer function
    GameObject CreateLayer(GameObject prefab, int sortingOrder)
    {
        if (prefab == null) return null;

        GameObject instance = Instantiate(prefab, cameraTransform.position, Quaternion.identity);
        SetSortingLayer(instance, sortingOrder);
        return instance;
    }

    void SetSortingLayer(GameObject obj, int sortingOrder)
    {
        if (obj == null) return;

        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            renderer.sortingOrder = sortingOrder;
        }
    }

    void LoadLevel(int index)
    {
        if (index < levelPrefabs.Length)
        {
            if (currentLevelInstance != null)
            {
                Destroy(currentLevelInstance);
            }
            currentLevelInstance = Instantiate(levelPrefabs[index], Vector3.zero, Quaternion.identity);
            ResetPlayerPosition();
        }
        else
        {
            Debug.Log("All levels completed!");
        }
    }

    public void SelectLevel(int levelIndex)
    {
        PlayerPrefs.SetInt("UnlockedLevel", levelIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ResetPlayerPosition()
    {
        if (player != null)
        {
            playerRb.linearVelocity = Vector2.zero;
            player.position = new Vector3(-38.72f, 24.8f, player.position.z);
        }
    }

    public void CompleteLevel()
    {
        if (currentLevelIndex < levelPrefabs.Length - 1)
        {
            currentLevelIndex++;
            PlayerPrefs.SetInt("UnlockedLevel", currentLevelIndex);
            PlayerPrefs.Save();
            LoadLevel(currentLevelIndex);
        }
        else
        {
            Debug.Log("All levels completed!");
            Debug.Log("Completed");
        }
    }
}
