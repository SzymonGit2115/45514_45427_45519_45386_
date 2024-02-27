using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentNullAndTrack : MonoBehaviour
{
    [SerializeField] List<Transform> transforms;
    // Start is called before the first frame update
    private void Awake()
    {
        foreach(var item in transforms) 
        {
            item.parent = null;
        
        }
    }


    private void OnDestroy()
    {
        foreach(var item in transforms) 
        {
            if(item) Destroy(item.gameObject);
        }
    }

}
