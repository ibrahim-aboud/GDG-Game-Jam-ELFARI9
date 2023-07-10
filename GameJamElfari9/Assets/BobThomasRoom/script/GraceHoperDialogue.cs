using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class GraceHoperDialogue : MonoBehaviour
{
    public TMP_Text dialogueText;
    private Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();

    private bool isDisplayingDialogue = false;

    private void Start()
    {
        // Example usage: Adding dialogues to the queue
        dialogueQueue.Enqueue(new Dialogue("", 6));
        dialogueQueue.Enqueue(new Dialogue("Welcome, young traveler! You've arrived at an important moment in history. Yes, this is indeed my domain the birthplace of modern computing. I am Grace Hopper, and it's a pleasure to have you here.", 5));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Thank you, Ms. Hopper! I've read so much about you and your contributions to the field of computer science. It's an honor to meet you.", 3));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("The pleasure is mine, dear student. It warms my heart to see the curiosity and passion in your eyes. The world of technology has come a long way since my time, but it's important to understand and appreciate its roots.", 5));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue(" I couldn't agree more! Your work with programming languages and the development of the first compiler revolutionized the way we build software today. And I heard you were involved in the discovery of the first computer bug. Is that true?", 5));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Ah, the famous story! It brings a smile to my face every time I recall it. Yes, it's true. Back in 1947, while working on the Mark II computer, we encountered a glitch. Upon investigation, we found an actual moth trapped between the relays. That little critter became known as the first 'bug' in computer science history. Now, knowing this story, let's go and capture all the bugs.", 5));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue(" Awesome! And how did you find that bug?", 2));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue(" It was quite a challenge trying to find it. Let's take you on a similar challenge. Enter this maze and capture the bug at the end of the labyrinth.", 3));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        
        



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

