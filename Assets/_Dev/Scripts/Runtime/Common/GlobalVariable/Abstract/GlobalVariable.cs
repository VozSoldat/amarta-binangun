using System;
using UnityEngine;

namespace VozSoldat.GlobalVariable
{

    public abstract class GlobalVariable<WrappedType, ConcreteSelf> : ScriptableObject where ConcreteSelf : GlobalVariable<WrappedType, ConcreteSelf>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        // [HideInInspector]
        public WrappedType Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnChange?.Invoke();
            }
        }
        [SerializeField] protected WrappedType _value;
        public event Action OnReady;
        public Action OnChange;

        public void SetValue(WrappedType value)
        {
            Value = value;
            OnReady?.Invoke();
            // OnChange?.Invoke();
        }

        public void SetValue(ConcreteSelf value)
        {
            Value = value.Value;
            OnReady?.Invoke();
            // OnChange?.Invoke();
        }

        // public void ApplyChange(WrappedType amount)
        // {
        //     Value += amount;
        // }

        // public void ApplyChange(ConcreteSelf amount)
        // {
        //     Value += amount.Value;
        // }

        protected void OnDestroy()
        {
            Value = default;
        }
        protected void OnDisable()
        {
            Value = default;
        }
    }
}