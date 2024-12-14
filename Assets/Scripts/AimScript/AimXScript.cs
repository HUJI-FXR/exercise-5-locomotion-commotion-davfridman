using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimXScript : MonoBehaviour
{

    public float sensitivity = 100f;
    public float rotationX = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        rotationX += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationX, 0f);
    }
}
