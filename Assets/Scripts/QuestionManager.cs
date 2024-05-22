using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public Button optionAButton;
    public Button optionBButton;
    public Button optionCButton;
    public Button optionDButton;
    public GameObject spaceship; // Reference to the spaceship
    public GameObject xrRig; // Reference to the XR Rig
    public Transform targetMarker; // Reference to the target marker
    public float spaceshipSpeed = 5f; // Speed of the spaceship movement
    public float xrRigSpeed = 5f; // Speed of the XR Rig movement

    private void Start()
    {
        // Ensure buttons are assigned
        if (optionAButton != null)
            optionAButton.onClick.AddListener(() => StartCoroutine(MoveToNextPlanet()));

        // Ensure spaceship, XR Rig, and target marker are assigned
        if (spaceship == null)
            Debug.LogError("Spaceship is not assigned.");
        if (xrRig == null)
            Debug.LogError("XR Rig is not assigned.");
        if (targetMarker == null)
            Debug.LogError("Target marker is not assigned.");
    }

    private IEnumerator MoveToNextPlanet()
    {
        Vector3 targetPosition = targetMarker.position;

        // Move the spaceship and XR Rig to the target position
        while (Vector3.Distance(spaceship.transform.position, targetPosition) > 0.1f ||
               Vector3.Distance(xrRig.transform.position, targetPosition) > 0.1f)
        {
            if (Vector3.Distance(spaceship.transform.position, targetPosition) > 0.1f)
            {
                spaceship.transform.position = Vector3.MoveTowards(spaceship.transform.position, targetPosition, spaceshipSpeed * Time.deltaTime);
            }
            if (Vector3.Distance(xrRig.transform.position, targetPosition) > 0.1f)
            {
                xrRig.transform.position = Vector3.MoveTowards(xrRig.transform.position, targetPosition, xrRigSpeed * Time.deltaTime);
            }
            yield return null;
        }
    }
}

