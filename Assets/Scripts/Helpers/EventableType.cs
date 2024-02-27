using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

[System.Serializable]

public class EventableType<T> where T : unmanaged, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
{
    [SerializeField] private T value;
    public Action<T> OnValueChanged;

    public T Value
    {
        get => value;
        set
        {
            if (this.value.Equals(value))
                return;

            var old = this.value;
            this.value = value;
            OnValueChanged?.Invoke(old);
        }
    }

  // public void SetValue(EventableType<T> other)
  // {
  //     value = other.value;
  // }
}

