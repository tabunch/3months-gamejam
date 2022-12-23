using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject scenarioManager;
    private ScenarioManager c_scenarioManager;
    private string currentSceneName;
    private void Awake() {
        c_scenarioManager = scenarioManager.GetComponent<ScenarioManager>();
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
        currentSceneName = "";
    }
    // Start is called before the first frame update
    void Start()
    {
        c_scenarioManager = scenarioManager.GetComponent<ScenarioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentSceneName)
        {
            case "Opening":
                if(c_scenarioManager.IsScenarioFinished()){
                    SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
                }
                break;
        }
    }

    private void OnSceneLoaded(Scene loaded, LoadSceneMode mode){
        currentSceneName = loaded.name;
        switch (currentSceneName)
        {
            case "Opening":
                c_scenarioManager.LoadScenarioFile("opening");
                /*
                while(!c_scenarioManager.IsScenarioFinished()){
                    new WaitForSeconds(0.1f);
                }
                */
                break;
        }
    }
}
