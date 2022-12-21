using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMessage : MonoBehaviour
{
    [SerializeField] GameObject scenarioManager;
    ScenarioManager c_scenarioManager;
    // Start is called before the first frame update
    void Start()
    {
        c_scenarioManager = scenarioManager.GetComponent<ScenarioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        c_scenarioManager.LoadScenarioFile("test");
    }
}
