using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class DialogueDisplay : MonoBehaviour
{
    public TMP_Text dialogueText;
    private Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();

    private bool isDisplayingDialogue = false;

    private void Start()
    {
        // Example usage: Adding dialogues to the queue
        dialogueQueue.Enqueue(new Dialogue("Hello!", 2));
        dialogueQueue.Enqueue(new Dialogue("How are you?", 3));

        // Start displaying the dialogue
        StartCoroutine(DisplayDialogue());
    }

    private IEnumerator DisplayDialogue()
    {
        while (dialogueQueue.Count > 0)
        {
            Dialogue currentDialogue = dialogueQueue.Dequeue();
            isDisplayingDialogue = true;

            dialogueText.text = currentDialogue.speech;

            yield return new WaitForSeconds(currentDialogue.time);

            dialogueText.text = "";
            isDisplayingDialogue = false;
        }
    }
}

[System.Serializable]
public class Dialogue
{
    public string speech;
    public float time;

    public Dialogue(string speech, float time)
    {
        this.speech = speech;
        this.time = time;
    }
}
