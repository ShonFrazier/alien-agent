using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private Rigidbody2D rb;
  private Animator anim;
  private SpriteRenderer sprite;

  [SerializeField] private float jumpForce = 4.7f;
  [SerializeField] private float moveSpeed = 5.25f;

  // Start is called before the first frame update
  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    sprite = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  private void Update()
  {
    var dirX = Input.GetAxis("Horizontal");
    rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

    if (Input.GetButtonDown("Jump"))
    {
      rb.velocity = new Vector3(rb.velocity.x, jumpForce);
    }

    UpdateAnimationState(dirX);
  }

  private void UpdateAnimationState(float horizDir)
  {
    if (horizDir > 0f)
    {
      anim.SetBool("running", true);
      sprite.flipX = false;
    }
    else if (horizDir < 0f)
    {
      anim.SetBool("running", true);
      sprite.flipX = true;
    }
    else
    {
      anim.SetBool("running", false);
    }

  }
}
