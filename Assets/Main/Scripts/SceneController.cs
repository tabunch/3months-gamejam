using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : SingletonMonoBehaviour<SceneController>
{
    [SerializeField] GameObject scenarioManager;
    private ScenarioManager c_scenarioManager;
    private string currentSceneName;
    private string loadScene;
    private Color fadeColor;
    private float fadeSpeed;
    [SerializeField] GameObject stage1Exit;
    CollisionTag collisionTag;
    private void Awake() {
        c_scenarioManager = scenarioManager.GetComponent<ScenarioManager>();
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
        currentSceneName = "";
        fadeColor = Color.black;
        fadeSpeed = 1.0f;
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
                    //SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
                    Initiate.Fade("Stage1", fadeColor, fadeSpeed);
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
                break;
        }
    }
}
