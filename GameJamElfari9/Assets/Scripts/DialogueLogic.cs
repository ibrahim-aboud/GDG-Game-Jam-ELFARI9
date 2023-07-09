using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueLogic : MonoBehaviour
{
    [SerializeField] private string[]  lines;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float textSpeed;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        text.text = string.Empty;
        startDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(text.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
            }
        }
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length -1 )
        {
            index++;
            text.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
