using System;
using UnityEngine;

namespace LitterBox.Components {
  public class LifetimeComponent : MonoBehaviour {

    /// <summary>
    /// This property determines how long the object will be "Alive". After
    /// this many seconds of active time the object will be removed.
    /// </summary>
    public float lifetimeSeconds = -1f;

    /// <summary>
    /// This property can be toggle to stop/start the tracking of the
    /// object's lifetime. When FALSE the elapsedTime will not be
    /// increased. When TRUE the elapsedTime will be tracked.
    /// </summary>
    public bool isActive = true;

    private float elapsedTime = 0f;

    void Update() {
      if(isActive) {
        float delta = Mathf.Clamp(Time.deltaTime, 0f, 1f/30f);
        elapsedTime += delta;

        if(lifetimeSeconds > 0 && elapsedTime >= lifetimeSeconds) {
          Destroy(gameObject);
        }
      }
    }
  }
}