using UnityEngine;

public class Billboarding : MonoBehaviour
{
    public Transform targetCamera;

    void LateUpdate()
    {
        if (targetCamera != null)
        {
            // Get the position of the camera
            Vector3 cameraPosition = targetCamera.position;

            // Calculate the direction from the sprite to the camera
            Vector3 direction = (cameraPosition - transform.position).normalized;

            // Rotate the sprite's parent to face the camera
            transform.LookAt(cameraPosition);

            // Adjust the rotation to account for how SpriteRenderer works (might need a 180-degree rotation)
            //transform.Rotate(0, 180, 0);
        }
    }
}
