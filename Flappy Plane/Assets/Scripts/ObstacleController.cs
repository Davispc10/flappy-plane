using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
  [SerializeField] private float velocity = 5f;
  [SerializeField] private GameObject me;

  void Start()
  {
    Destroy(me, 5f);
  }

  void Update()
  {
    transform.position += Vector3.left * Time.deltaTime * velocity;
  }
}
