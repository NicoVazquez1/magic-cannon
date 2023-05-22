using UnityEngine;

public class movementCannon : MonoBehaviour
{
    float RotationSpeed = 85;
    Vector3 currentRotation;
    Vector3 currentChildRotation;

    void Start()
    {
    }

    void Update()
    {
        manageMovement();       
    }
    void manageMovement()
    {
        if (Input.GetKey("d")) { currentRotation.y += RotationSpeed * Time.deltaTime; }
       
        if (Input.GetKey("a")) { currentRotation.y -= RotationSpeed * Time.deltaTime; ; }

        if (Input.GetKey("w")) { currentChildRotation.x += RotationSpeed * Time.deltaTime;; }

        if (Input.GetKey("s")) { currentChildRotation.x -= RotationSpeed * Time.deltaTime;; }

        transform.eulerAngles = currentRotation;

        currentRotation.y = Mathf.Clamp(currentRotation.y, -45f, 90f);
        currentChildRotation.x = Mathf.Clamp(currentChildRotation.x, -35f, 15f);

        transform.GetChild(0).GetComponent<Transform>().localEulerAngles = currentChildRotation;
    }
}
