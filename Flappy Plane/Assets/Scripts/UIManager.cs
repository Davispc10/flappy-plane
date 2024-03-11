using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI levelUI;
  [SerializeField] private TextMeshProUGUI scoreUI;
  [SerializeField] private GameManager instance;

  void Start()
  {
    scoreUI.text = instance.finalScore;
    levelUI.text = instance.finalLevel;
  }
}
 