using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
  private Renderer backShader;

  private float xOffset = 0f;
  private Vector2 textureOffset;
  [SerializeField] private float offsetVelocity = 0.1f;

  void Start()
  {
    backShader = GetComponent<Renderer>();
  }

  // Update is called once per frame
  void Update()
  {
    xOffset += Time.deltaTime * offsetVelocity;
    textureOffset.x = xOffset;
    backShader.material.mainTextureOffset = textureOffset;
  }
}
