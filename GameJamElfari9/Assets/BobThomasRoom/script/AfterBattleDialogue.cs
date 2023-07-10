using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class AfterBattleDialogue : MonoBehaviour
{
    public TMP_Text dialogueText;
    private Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();

    private bool isDisplayingDialogue = false;

    private void Start()
    {
        // Example usage: Adding dialogues to the queue
        dialogueQueue.Enqueue(new Dialogue("", 2));
        dialogueQueue.Enqueue(new Dialogue(" Did you do it? Did you defeat the Creeper?", 2));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Oh, you bet! The Reaper did its job, and the Creeper is no more!", 2));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("fantastic! You truly are a digital hero! let me now introduce my self clearly I'm Bob Thomas, the infamous creator of the Creeper and its nemesis, the Reaper.", 5));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Wait, you created the Creeper? And the Reaper too? That's quite a twist!", 3));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Yes, indeed! I'm the mastermind behind those digital troublemakers.", 2));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue(" Well, thank you for that thrilling adventure, Professor Thomas. I never thought I'd be battling against your creations!", 3));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Ah, it's all part of the coding journey, my student. The virtual world is full of surprises! ", 3));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("But I have to admit, those digital battles can be quite intense. I almost lost my mind in there!", 3));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue(" Well, it's all part of the wild world of coding and viruses. Just remember, when in doubt, Ctrl+Alt+Delete!", 3));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Haha, I'll keep that in mind. Thanks for the adventure, Professor Thomas", 2));
         dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("No problem, my brave student. Now go and conquer the next coding challenge, with less viral excitement this time!", 4));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Absolutely! But hey, can we stick to battling bugs instead of computer viruses from now on?", 3));
        dialogueQueue.Enqueue(new Dialogue("", 1));
        dialogueQueue.Enqueue(new Dialogue("Deal! Bugs are way more cuddly, I promise!", 2));
        



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

