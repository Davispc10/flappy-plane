using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
  private Rigidbody2D rd;
  [SerializeField] private float velocity = 5f;
  
  [SerializeField] private GameObject puff;

  void Start()
  {
    rd = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    UpPlayer();
    VelocityLimit();
    LoseOnGoOutScreen();
  }

  public void UpPlayer()
  {
    if (Input.GetMouseButtonDown(0))
    {
      rd.velocity = Vector2.up * velocity;
      CreatePuffPrefab();
    }
  }

  private void CreatePuffPrefab()
  {
    GameObject puffObject = Instantiate(puff, transform.position, Quaternion.identity);
    Destroy(puffObject, 1f);
  }

  public void VelocityLimit()
  {
    if (rd.velocity.y < -velocity)
    {
      rd.velocity = Vector2.down * velocity;
    }
  }

  private void LoseOnGoOutScreen()
  {
    if (transform.position.y > 5f ||  transform.position.y < -5f)
    {
      SceneManager.LoadScene(2);
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    SceneManager.LoadScene(2);
  }
}
