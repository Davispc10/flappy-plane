using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  private Rigidbody2D rd;
  [SerializeField] private float velocity = 5f;

  void Start()
  {
    rd = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    UpPlayer();
    VelocityLimit();
  }

  public void UpPlayer()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      rd.velocity = Vector2.up * velocity;
    }
  }

  public void VelocityLimit()
  {
    if (rd.velocity.y < -velocity)
    {
      rd.velocity = Vector2.down * velocity;
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    SceneManager.LoadScene(0);
  }
}
