using System;

namespace TwoScoopGames.Variables {
  [Serializable]
  public class VariableReference<T, VariableT> where VariableT : Variable<T> {

    public bool UseConstant = true;
    public T ConstantValue;
    public VariableT Variable;

    public VariableReference() {}

    public VariableReference(T val) {
      UseConstant = true;
      ConstantValue = val;
    }

    public T Value {
      get {
        return UseConstant ? ConstantValue : Variable.RuntimeValue;
      }
      set {
        if (UseConstant) {
          ConstantValue = value;
        } else {
          Variable.RuntimeValue = value;
        }
      }
    }

    public static implicit operator T(VariableReference<T, VariableT> reference)
    {
      return reference.Value;
    }
  }
}
