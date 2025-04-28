// using UnityEngine;

// public class ParallaxEffect : MonoBehaviour
// {
//     public Transform player;  // Assign the player object
//     public float parallaxFactor = 0.5f;  // Adjust speed for each layer

//     private Vector3 lastPlayerPosition;

//     void Start()
//     {
//         lastPlayerPosition = player.position;
//     }

//     void Update()
//     {
//         Vector3 deltaMovement = player.position - lastPlayerPosition;
//         transform.position += new Vector3(deltaMovement.x * parallaxFactor, 0, 0);
//         lastPlayerPosition = player.position;
//     }
// }





using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform cameraTransform;  // Assign the Main Camera in the Inspector
    public float parallaxFactor = 0.5f;  // Adjust speed for each layer

    private Vector3 lastCameraPosition;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform; // Automatically finds the main camera
        }
        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxFactor, deltaMovement.y * parallaxFactor, 0);
        lastCameraPosition = cameraTransform.position;
    }
}
