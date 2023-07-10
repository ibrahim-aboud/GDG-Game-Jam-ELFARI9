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
        dialogueQueue.Enqueue(new Dialogue("", 7));
        dialogueQueue.Enqueue(new Dialogue("Sir, what's going on?  i heard your screams from the hall way!", 4));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Quick! We need to stop the Creeper before it wreaks havoc on all computer systems! I accidentally unleashed it", 5));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Don't worry, Professor! I'm ready to take on this virtual menace. What's the plan?", 4));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue(" I've got just the thing for you. ", 3));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Uh, Professor, is this some kind of joke? How will a gun defeat a computer virus?", 4));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Ah, my young warrior, that's no ordinary gun. It's the legendary 'Reaper'! It was designed by me specifically to defeat the creaper.", 5));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Well, if you say so, Professor, i feel that i've learned so much in this journey , no virus can scare me now.", 4));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("OK superman! Now, dive into the digital world and face the Creeper head-on! Show that virus who's boss!", 3));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Consider it done, Professor!", 2));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("That's the spirit! Remember, victory lies within the heart of the byte. Go forth, brave student, and conquer the virtual realm! ", 4));
        



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
