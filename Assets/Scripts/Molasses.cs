using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molasses : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    var orbVel = collision.attachedRigidbody.velocity;
    var newVel = orbVel * 0.25f;
    Debug.Log($"collision - orbVel {orbVel}  newVel {newVel}");
    collision.attachedRigidbody.velocity = newVel;
  }
}
