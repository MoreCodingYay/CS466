using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float rotationSpeed = 10f; // Rotation speed in degrees per second

    void Update()
    {
        // Rotate the planet around its Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
