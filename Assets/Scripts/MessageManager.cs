using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : SingletonMonoBehaviour<MessageManager>
{
    [SerializeField] Text messageText;
    private string scenarioText;
    private string[] lines;
    int currentLine;
    public bool isMessageFinished;
    // Start is called before the first frame update
    void Start()
    {
        currentLine = 0;
        isMessageFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeSelf){
            if(Input.GetKeyDown(KeyCode.Return)){
                NextLine();
            }
        }
    }

    public void ActivateMessagePanel(string[] message){
        lines = message;
        this.gameObject.SetActive(true);
        currentLine = 0;
        isMessageFinished = false;
    }

    public void NextLine(){
        if(currentLine >= lines.Length){
            this.gameObject.SetActive(false);
            isMessageFinished = true;
            return;
        }
        messageText.text = lines[currentLine];
        currentLine++;
    }
}
