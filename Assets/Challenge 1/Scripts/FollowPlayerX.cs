using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
  public GameObject plane;
  public Vector3 offset = new Vector3(0, 1.5f, -10);
  private float distance;
  private Vector3 playerPrevPos;
  private Vector3 playerMoveDir;
  private float speed = 30.0f;

  private float inversedDegree = 180;


  // Start is called before the first frame update
  void Start()
  {
    distance = offset.magnitude;
    playerPrevPos = plane.transform.position;
  }

  void FixedUpdate()
  {
    var rot = Quaternion.LookRotation(plane.transform.position - transform.position);
    transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);

    // Move
    Vector3 newPosition = plane.transform.position + plane.transform.forward * offset.z + plane.transform.up * offset.y;
    transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime * speed);
  }
}
