using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
  [Header("Refereces")]
  public Transform orientation;
  public Transform player;
  public Transform playerObj;
  public Rigidbody rb;

  private void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  public float rotationSpeed;

  private void Update()
  {
    // Rotate orientation
    UnityEngine.Vector3 viewDir = player.position - new UnityEngine.Vector3(transform.position.x, transform.position.y, transform.position.z);
    orientation.forward = viewDir.normalized;

    // Rotate player object
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    UnityEngine.Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

    if (inputDir != UnityEngine.Vector3.zero)
        playerObj.forward = UnityEngine.Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
  }
}
