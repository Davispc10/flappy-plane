using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
  [SerializeField] private float timer = 2f;

  [SerializeField] private GameObject obstacle;
  [SerializeField] private Vector3 position;
  [SerializeField] private float limitY = 1.37f;

  [SerializeField] private float tMin = 1f;
  [SerializeField] private float tMax = 3f;

  private float score = 0f;
  [SerializeField] private TextMeshProUGUI scoreUI;

  private int level = 1;
  [SerializeField] private float nextLevel = 10f;
  [SerializeField] private TextMeshProUGUI levelUI;

  [SerializeField] private AudioClip levelUpAudio;

  [SerializeField] private GameManager manager;

  private Vector3 cameraPosition;

  void Start()
  {
    cameraPosition = Camera.main.transform.position;
  }

  void Update()
  {
    Score();
    CreateObstacle();
    UpLevel();
  }

  private void Score()
  {
    score += Time.deltaTime * level;
    scoreUI.text = Mathf.Round(score).ToString();
    manager.finalScore = scoreUI.text;
  }

  private void UpLevel()
  {
    levelUI.text = "Nível: " + level.ToString();
    manager.finalLevel = levelUI.text;

    if (score > nextLevel)
    {
      level++;
      nextLevel *= 2;
      AudioSource.PlayClipAtPoint(levelUpAudio, cameraPosition);
    }
  }

  private void CreateObstacle()
  {
    timer -= Time.deltaTime;

    if (timer <= 0)
    {
      timer = Random.Range(tMin / level, tMax);
      position.y = Random.Range(-limitY, limitY);
      Instantiate(obstacle, position, Quaternion.identity);
    }
  }

  public int ReturnLevel()
  {
    return level;
  }
}
