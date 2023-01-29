using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
  public float speed;
  public float rotationSpeed;
  public float verticalInput;

  private float accelerator = 0f;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    // get the user's vertical input
    verticalInput = Input.GetAxis("Vertical");
    var a = Input.GetKey("a");
    var z = Input.GetKey("z");
    if (a)
    {
      accelerator = Mathf.Min(10000, accelerator + 1);
    }
    else if (z)
    {
      accelerator = Mathf.Max(0, accelerator - 1);
    }

    // move the plane forward at a constant rate
    var v = Vector3.forward * speed * accelerator;
    Debug.Log("v:" + v);
    transform.Translate(Vector3.forward * speed * accelerator);

    // tilt the plane up/down based on up/down arrow keys
    transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
  }
}
