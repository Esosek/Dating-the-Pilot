using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{

    public string[] dialogueNames;
    public string[] speechText;

    public Text dialogueBox;
    public GameObject introPlane;

    public void StartGame()
    {
        GameManager.instance.StartGameplay();
        StopMotor();
        FindObjectOfType<RandomVoice>().nextSpeak = 5f;
        gameObject.SetActive(false);
        Destroy(introPlane);
    }

    public void PlayDialogue(int dialogueIndex)
    {
        AudioManager.instance.Play(dialogueNames[dialogueIndex]);
        dialogueBox.text = speechText[dialogueIndex];
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            StartGame();
        }
    }

    public void StopMotor()
    {
        AudioManager.instance.Stop("Motor Running");
    }

    private void Start()
    {
        Cursor.visible = false;
    }
}
