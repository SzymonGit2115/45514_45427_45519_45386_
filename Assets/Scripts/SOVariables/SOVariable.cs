using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOVariable<T> : ScriptableObject where T : unmanaged, IComparable<T>, IEquatable<T>
{
  // Tooltip("The Variable will be initialized in initialization process. If not forced, avoid rejestration to")]
  // SerializeField] private bool forceInitialized;
  // Tooltip("Value is true after initialization.If ForceInitialized is true, the value is negligible.")]
  // private bool initialized;
  // field: SerializeField] public EventableType<T> Variable { get; private set; }


}
