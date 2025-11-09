using UnityEngine;

namespace VozSoldat.GlobalVariable
{
    public abstract class NumericGlobalVariable<WrappedType, ConcreteSelf> : GlobalVariable<WrappedType, ConcreteSelf> where ConcreteSelf : NumericGlobalVariable<WrappedType, ConcreteSelf>
    {
        public void ApplyChange(WrappedType amount)
        {
            object result = null;

            if (typeof(WrappedType) == typeof(float))
                result = (float)(object)Value + (float)(object)amount;
            else if (typeof(WrappedType) == typeof(int))
                result = (int)(object)Value + (int)(object)amount;
            else if (typeof(WrappedType) == typeof(double))
                result = (double)(object)Value + (double)(object)amount;
            else if (typeof(WrappedType) == typeof(Vector3))
                result = (Vector3)(object)Value + (Vector3)(object)amount;
            else
                throw new System.InvalidOperationException(
                    $"Type {typeof(WrappedType)} does not support addition.");

            Value = (WrappedType)result;

            // OnChange?.Invoke();
        }

        public void ApplyChange(ConcreteSelf amount)
        {
            ApplyChange(amount.Value);

        }
    }
}