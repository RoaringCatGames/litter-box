using System;
using UnityEngine;

namespace TwoScoopGames.Variables {
  public class Variable<T> : ScriptableObject {

    public T InitialValue;

    [NonSerialized]
    public T RuntimeValue;

    // NOTE: I think this field needs to go last because it's compile-time optional, and will cause serialization problems on devices where it doesn't exist
  #if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
  #endif

    void OnEnable() {
      RuntimeValue = InitialValue;
      this.hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
  }
}
