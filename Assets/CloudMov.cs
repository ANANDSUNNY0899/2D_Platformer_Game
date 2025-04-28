using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float speed = 1f; // Speed of cloud movement
    public float resetPosition = 10f; // When to reset cloud position
    public float startPosition = -10f; // Starting position

    void Update()
    {
        // Move clouds to the right
        transform.position += Vector3.right * speed * Time.deltaTime;

        // Reset position when cloud moves off-screen
        if (transform.position.x > resetPosition)
        {
            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }
    }
}
