using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimYScript : MonoBehaviour
{
    public float sensitivity = 100f;
    private float rotationY = 0f;
    public float minY = -90f;
    public float maxY = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Accumulate vertical rotation and clamp it
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);

        // Apply rotation to the Camera object
        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
    }
}
