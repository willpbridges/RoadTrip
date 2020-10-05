using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveCar : MonoBehaviour
{
    // Base car values
    [Tooltip("How much force the car engine has.")] 
    [SerializeField] double enginePower = 15.0;

    [Tooltip("The maximum amount the car can be steered in one direction.")] 
    [SerializeField] double maxSteer = 10.0;

    // Calculating how fast car is moving
    [Tooltip("Current speed the car is traveling at.")]
    [SerializeField] double speed = 0.0;
    //Vector3 previousPosition = ;

    // Input from player
    double gas;
    double brake;
    double steer;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //vel = 
        gas = Input.GetAxis("Vertical") * enginePower * Time.deltaTime;
        steer = Input.GetAxis("Horizontal") * enginePower * Time.deltaTime;
        rb.AddForce(transform.forward * (float) gas, ForceMode.Impulse);
        //rb.MoveRotation(steer);
    }
}
