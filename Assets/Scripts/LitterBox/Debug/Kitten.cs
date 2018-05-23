using System;
using UnityEngine;

namespace LitterBox.Debug
{
  public class Kitten
  {
    /// <summary>
    /// This is an Extension to Unity's Debug.Log, but automatically
    ///   concats multipl objects passed in for you. It will also
    ///   only log if Debug.isDebugBuild is on.
    /// </summary>
    /// <param name="inputs">Any items that you want to log. They will be concatenated through their ToString() implementations</param>
    public static void Log(params object[] inputs) {
      Meow(inputs);
    }

    /// <summary>
    /// This is an Extension to Unity's Debug.LogError, but automatically
    ///   concats multipl objects passed in for you. It will also
    ///   only log if Debug.isDebugBuild is on.
    /// </summary>
    /// <param name="inputs">Any items that you want to log. They will be concatenated through their ToString() implementations</param>
    public static void LogError(params object[] inputs) {
      Roar(inputs);
    }

    /// <summary>
    /// This is a fun Alias to LitterBox.Debug.Kitten.Log
    /// </summary>
    /// <param name="inputs">Any items that you want to log. They will be concatenated through their ToString() implementations</param>
    public static void Meow(params object[] inputs)
    {
      if (UnityEngine.Debug.isDebugBuild) {
        UnityEngine.Debug.Log(String.Concat(inputs));
      }
    }

    /// <summary>
    /// This is a fun Alias to LitterBox.Debug.Kitten.Roar
    /// </summary>
    /// <param name="inputs">Any items that you want to log. They will be concatenated through their ToString() implementations</param>
    public static void Roar(params object[] inputs) {
      if (UnityEngine.Debug.isDebugBuild) {
        UnityEngine.Debug.LogError(string.Concat(inputs));
      }
    }
  }
}