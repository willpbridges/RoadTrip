using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Position of camera from object
    Vector3 offset;
    // The object for the camera to follow
    [Tooltip("The object for the camera to follow.")]
    [SerializeField] Transform followedObject;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followedObject.position + offset;
    }
}
