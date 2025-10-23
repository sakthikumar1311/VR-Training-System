using UnityEngine;

public class VehicleKinematicController : MonoBehaviour {
    public float maxSpeed = 20f;
    public float acceleration = 5f;
    public float steeringSpeed = 60f; // degrees per second

    private float currentSpeed = 0f;

    void Update() {
        float throttle = Input.GetAxis("Vertical"); // VR mapping will override
        float steer = Input.GetAxis("Horizontal");

        // Simple acceleration
        currentSpeed = Mathf.MoveTowards(currentSpeed, throttle * maxSpeed, acceleration * Time.deltaTime);
        transform.position += transform.forward * currentSpeed * Time.deltaTime;

        // Steering
        float steerAmount = steer * steeringSpeed * Time.deltaTime;
        transform.Rotate(0f, steerAmount, 0f);
    }
}
