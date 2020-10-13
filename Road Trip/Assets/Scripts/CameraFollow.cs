using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //youtube.com/watch?v=Z4HA8zJhGEks

    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;

    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    private void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        // Bad? Use SmoothDamp method instead? Idk that's what the guy said
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        var direction = target.position - transform.position;
        // See above comment also about Lerp ?
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
