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
    // Start is called before the first frame update
    void Start()
    {
        currentLine = 0;
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
    }

    public void NextLine(){
        if(currentLine >= lines.Length){
            this.gameObject.SetActive(false);
            return;
        }
        messageText.text = lines[currentLine];
        currentLine++;
    }
}
