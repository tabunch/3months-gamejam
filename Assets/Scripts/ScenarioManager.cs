using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : SingletonMonoBehaviour<ScenarioManager>
{
    TextAsset scenarioText;
    string[] scenarios;
    string delimiter;
    [SerializeField] GameObject MessageWindow;
    MessageManager messageManager;
    // Start is called before the first frame update
    void Start()
    {
        delimiter = "@br\n";
        messageManager = MessageWindow.GetComponent<MessageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScenarioFile(string fileName){
        scenarioText = Resources.Load<TextAsset>("Scenarios/" + fileName);
        if(scenarioText == null){
            Debug.LogError("シナリオファイルが見つかりません");
            return;
        }
        scenarios = scenarioText.text.Split(delimiter);
        messageManager.ActivateMessagePanel(scenarios);
        messageManager.NextLine();
    }
}
