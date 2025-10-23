using UnityEngine;

public class LaneChecker : MonoBehaviour {
    public Transform[] laneWaypoints; // Waypoints defining the lane center
    public float laneWidth = 3.5f; // Half-width of lane
    public float warningThreshold = 0.5f; // Offset to trigger warning

    private Transform vehicle;

    void Start() {
        vehicle = transform; // Assuming attached to vehicle
    }

    void Update() {
        float lateralOffset = CalculateLateralOffset();
        if (Mathf.Abs(lateralOffset) > warningThreshold) {
            // Trigger lane departure warning
            Debug.Log("Lane Departure Warning: Offset = " + lateralOffset);
        }
    }

    private float CalculateLateralOffset() {
        // Simple projection onto lane (assuming straight lane for simplicity)
        if (laneWaypoints.Length < 2) return 0f;

        Vector3 laneDir = (laneWaypoints[1].position - laneWaypoints[0].position).normalized;
        Vector3 toVehicle = vehicle.position - laneWaypoints[0].position;
        float alongLane = Vector3.Dot(toVehicle, laneDir);
        Vector3 projected = laneWaypoints[0].position + alongLane * laneDir;
        Vector3 lateral = vehicle.position - projected;
        return Vector3.Dot(lateral, Vector3.Cross(laneDir, Vector3.up)); // Right is positive
    }
}
