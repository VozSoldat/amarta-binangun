using System;
using UnityEngine;

namespace VozSoldat.GlobalVariable
{
    [Serializable]
    public class VarReference<WrappedType, VariableType> where VariableType : GlobalVariable<WrappedType, VariableType>
    {
        public bool UseConstant = true;
        public WrappedType ConstantValue;
        public VariableType Variable;

        public VarReference() { }

        public VarReference(WrappedType value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public WrappedType Value
        {
            get => UseConstant ? ConstantValue : Variable.Value;
            set
            {
                if (UseConstant)
                    ConstantValue = value;
                else
                    Variable.Value = value;
            }
        }

        // Implicit conversion to WrappedType
        public static implicit operator WrappedType(VarReference<WrappedType, VariableType> reference)
            => reference.Value;

        // Implicit conversion from WrappedType (optional)
        public static implicit operator VarReference<WrappedType, VariableType>(WrappedType value)
            => new VarReference<WrappedType, VariableType>(value);

        // Optional: forward common members (if struct/class)
        public override string ToString() => Value?.ToString() ?? "null";
    }
}
