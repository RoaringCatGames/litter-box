using UnityEngine;
using UnityEngine.Events;

namespace TwoScoopGames.Events {
  public class GameEventListener : MonoBehaviour {

    public GameEvent subject;
    public UnityEvent response;

    private void OnEnable() {
      subject.RegisterListener(this);
    }

    private void OnDisable() {
      subject.UnregisterListener(this);
    }

    public void OnEventRaised() {
      response.Invoke();
    }
  }
}
