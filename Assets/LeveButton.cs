using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public GameObject levelSelectionPanel; // Assign in Inspector

    private void OnMouseDown()  // Detects when button is clicked
    {
        levelSelectionPanel.SetActive(!levelSelectionPanel.activeSelf);
    }
}
