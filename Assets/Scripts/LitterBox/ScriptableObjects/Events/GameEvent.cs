using System.Collections.Generic;
using UnityEngine;

namespace TwoScoopGames.Events {
  [CreateAssetMenu]
  public class GameEvent : ScriptableObject {

    private readonly List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise() {
      for (var i = listeners.Count - 1; i >= 0; i--) {
        listeners[i].OnEventRaised();
      }
    }

    public void RegisterListener(GameEventListener listener) {
      if (!listeners.Contains(listener)) {
        listeners.Add(listener);
      }
    }

    public bool UnregisterListener(GameEventListener listener) {
      return listeners.Remove(listener);
    }
  }
}
