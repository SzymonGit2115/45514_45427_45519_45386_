using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableController : MonoBehaviour
{
    [field: SerializeField] public Mesh PlaceableMesh { get; private set; }
    [field: SerializeField] public float PlaceableCost { get; private set; }
}
