using UnityEngine;

public class ForwardRadar : MonoBehaviour {
    public float maxDistance = 50f;
    public float ttcThreshold = 2.5f; // seconds

    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance)) {
            Rigidbody rb = hit.collider.attachedRigidbody;
            float relSpeed = 0f;
            if (rb != null) relSpeed = Mathf.Max(0f, (GetComponentInParent<Rigidbody>()?.velocity.magnitude ?? 0) - rb.velocity.magnitude);
            float distance = hit.distance;
            if (relSpeed > 0f) {
                float ttc = distance / relSpeed;
                if (ttc < ttcThreshold) {
                    // trigger warning
                    Debug.Log("TTC warning: " + ttc);
                }
            }
        }
    }
}
