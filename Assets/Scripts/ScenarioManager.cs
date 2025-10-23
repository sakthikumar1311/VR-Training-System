using UnityEngine;
using System.Collections.Generic;

public class ScenarioManager : MonoBehaviour {
    public enum ScenarioType {
        LaneDiscipline,
        ObstacleAvoidance,
        PedestrianEmergence,
        EmergencyBrake,
        LowVisibility
    }

    public ScenarioType currentScenario;
    public GameObject[] obstacles;
    public GameObject[] pedestrians;
    public Transform[] spawnPoints;

    private Dictionary<ScenarioType, System.Action> scenarioActions;

    void Start() {
        scenarioActions = new Dictionary<ScenarioType, System.Action>() {
            { ScenarioType.LaneDiscipline, StartLaneDiscipline },
            { ScenarioType.ObstacleAvoidance, StartObstacleAvoidance },
            { ScenarioType.PedestrianEmergence, StartPedestrianEmergence },
            { ScenarioType.EmergencyBrake, StartEmergencyBrake },
            { ScenarioType.LowVisibility, StartLowVisibility }
        };
    }

    public void StartScenario(ScenarioType type) {
        currentScenario = type;
        ResetScenario();
        if (scenarioActions.ContainsKey(type)) {
            scenarioActions[type]();
        }
    }

    private void ResetScenario() {
        // Reset vehicle position, clear obstacles, etc.
        // Implement reset logic
    }

    private void StartLaneDiscipline() {
        // Implement lane discipline scenario
        Debug.Log("Starting Lane Discipline Scenario");
    }

    private void StartObstacleAvoidance() {
        // Spawn obstacle ahead
        if (obstacles.Length > 0) {
            Instantiate(obstacles[0], spawnPoints[0].position, spawnPoints[0].rotation);
        }
        Debug.Log("Starting Obstacle Avoidance Scenario");
    }

    private void StartPedestrianEmergence() {
        // Spawn pedestrian crossing
        if (pedestrians.Length > 0) {
            Instantiate(pedestrians[0], spawnPoints[1].position, spawnPoints[1].rotation);
        }
        Debug.Log("Starting Pedestrian Emergence Scenario");
    }

    private void StartEmergencyBrake() {
        // Simulate lead vehicle braking
        Debug.Log("Starting Emergency Brake Scenario");
    }

    private void StartLowVisibility() {
        // Enable fog or low light
        RenderSettings.fog = true;
        Debug.Log("Starting Low Visibility Scenario");
    }
}
