using System;
using System.Linq;
using UnityEngine;

namespace LitterBox.Physics{
  [RequireComponent(typeof(Rigidbody2D))]
  public class DynamicAfterCollision2DComponent : MonoBehaviour {

    public string[] tagNamesToCollideWith = new string[] { "Player" };
    private Rigidbody2D rb2d;

    void Awake() {
      rb2d = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision) {
      if (tagNamesToCollideWith.Contains(collision.collider.tag)) {
        rb2d.freezeRotation = false;
        rb2d.constraints = RigidbodyConstraints2D.None;
      }
    }
  }
}