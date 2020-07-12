using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomVoice : MonoBehaviour
{
    public List<string> sounds = new List<string>();
    public List<string> transcripts = new List<string>();
    public float timeBetweenDialogues = 15f;

    public float nextSpeak = 26f;

    public GameObject dialogueBox;
    public Text dialogueText;

    void Update()
    {
        if (sounds.Count == 0) return;

        nextSpeak -= Time.deltaTime;

        if (nextSpeak < 0f)
        {
            StartCoroutine(Speak());
            nextSpeak = timeBetweenDialogues;
        }
    }

    IEnumerator Speak()
    {
        int speakIndex = Random.Range(0, sounds.Count);

        dialogueBox.SetActive(true);
        dialogueText.text = transcripts[speakIndex];
        transcripts.Remove(transcripts[speakIndex]);

        AudioManager.instance.Play(sounds[speakIndex]);
        sounds.Remove(sounds[speakIndex]);

        Debug.Log("Random dialogue");

        yield return new WaitForSeconds(2f);

        dialogueBox.SetActive(false);
    }
}
