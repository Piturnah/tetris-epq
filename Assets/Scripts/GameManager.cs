using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float horizontalInput = 0;
    public static float verticalInput = 0;
    public static float rotateInput = 0;

    public static float horizontalAxis = 0;
    public static float verticalAxis = 0;
    public static float rotationAxis = 0;

    float previousFallTime;
    float fallDelay = 1f;

    private void Update()
    {
        DetectInput();
    }
    void DetectInput()
    {
        horizontalAxis = 0;
        verticalAxis = 0;
        rotationAxis = 0;

        horizontalAxis = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            rotationAxis = Input.GetAxisRaw("Rotate");
        }
    }
}
