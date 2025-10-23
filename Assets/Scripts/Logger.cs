using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class Logger : MonoBehaviour {
    public string logFileName = "telemetry.csv";
    private string logPath;
    private List<string> logBuffer = new List<string>();

    void Start() {
        logPath = Path.Combine(Application.persistentDataPath, logFileName);
        // Write header
        logBuffer.Add("Time,PositionX,PositionY,PositionZ,RotationX,RotationY,RotationZ,Speed");
    }

    void Update() {
        // Log every frame or at intervals
        string logEntry = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
            Time.time,
            transform.position.x, transform.position.y, transform.position.z,
            transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z,
            GetComponent<Rigidbody>()?.velocity.magnitude ?? 0f);
        logBuffer.Add(logEntry);
    }

    void OnApplicationQuit() {
        // Write to file
        File.WriteAllLines(logPath, logBuffer);
        Debug.Log("Telemetry logged to: " + logPath);
    }
}
