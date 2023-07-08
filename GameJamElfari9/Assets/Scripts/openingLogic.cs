using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class openingLogic : MonoBehaviour
{
    // every door is dependent on the logical value of a number of switches (LEDs)
    [SerializeField] private GameObject[] ledArray;
    // Start is called before the first frame update
    private Animator animator;
    // "operators are + for "or", * for "and" and 1 for "not""
    // it will use something similar to post fix writing
    // so "++1*" means (not((a or b ) or c ))and d
    [SerializeField] private string equation = "";
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    private bool ValueOfLed(int index)
    {
        if (index < ledArray.Length)
        {
            return ledArray[index].GetComponent<ledTogglingLogic>().isOn();
        }
        else return false;
    }

    // this method will contain the logical equation (so the combination of ands and ors and logical variables "leds")
    private bool DoorEquation()
    {
        bool finalValue = ValueOfLed(0);
        int currentOperatorIndex=1;
        for (int i =0; i< equation.Length; i++)
        {
            if (equation[i] == '+')
            {
                finalValue = finalValue || ValueOfLed(currentOperatorIndex);
                currentOperatorIndex++;
            }
            else if (equation[i] == '*')
            {
                finalValue = finalValue && ValueOfLed(currentOperatorIndex);
                currentOperatorIndex++;
            }
            else if (equation[i] == '1')
            {
                finalValue = !finalValue;
            }
        }
        return finalValue;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("open", DoorEquation());
    }
}
