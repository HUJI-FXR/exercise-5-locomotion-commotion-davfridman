using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private InputActionReference buttonAction; // Reference to the action
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float bulletLifetime = 3f;

     private void OnEnable()
    {
        buttonAction.action.started += OnButtonPressed;
    }

    private void OnDisable()
    {
        buttonAction.action.started -= OnButtonPressed;
    }

    private void OnButtonPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Button Pressed!");
        PerformAction();
    }

    private void PerformAction()
    {

        // Transform cameraTransform = Camera.main.transform;
        // GameObject newBullet = Instantiate(bulletPrefab, cameraTransform.position, cameraTransform.rotation);
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        newBullet.tag = "Bullet";

        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
        // rb.velocity = cameraTransform.forward * bulletSpeed;
        newBullet.SetActive(true);
        Destroy(newBullet, bulletLifetime);
    }
}
