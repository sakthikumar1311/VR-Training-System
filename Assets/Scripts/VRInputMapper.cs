using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRInputMapper : MonoBehaviour {
    public VehicleKinematicController vehicleController;
    public XRController rightController;
    public XRController leftController;

    void Update() {
        // Map VR inputs
        float throttle = rightController.activateInteractionState.value; // Right trigger
        float brake = leftController.activateInteractionState.value; // Left trigger
        float steer = rightController.axis2D.x; // Right thumbstick X

        // Override Input axes for vehicle
        InputManager.SetAxis("Vertical", throttle - brake);
        InputManager.SetAxis("Horizontal", steer);

        // Grip for lane assist toggle (example)
        if (rightController.selectInteractionState.activatedThisFrame) {
            // Toggle lane assist
            Debug.Log("Lane Assist Toggled");
        }
    }
}

// Note: InputManager is not standard; this is pseudo-code. In practice, use Input System or direct assignment.
