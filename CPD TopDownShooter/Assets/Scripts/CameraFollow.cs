using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Follows a game object.
/// </summary>
[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + offset;
    }
}
