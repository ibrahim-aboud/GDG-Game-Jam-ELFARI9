using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ledTogglingLogic : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Renderer rndr;
    public bool on = false;
    [SerializeField] private Color onColor = Color.green;
    [SerializeField] private Color offColor = Color.red;
    [SerializeField] private float detectionDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rndr= GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,target.transform.position) < detectionDistance && Input.GetKeyDown(KeyCode.T))
        {
            toggleState();
        }
        if (on)
        {
            rndr.material.color = onColor;
        }
        else
        {
            rndr.material.color = offColor;
        }
    }

    void toggleState()
    {
        on = !on;
    }

    public bool isOn()
    {
        return on;
    }
}
