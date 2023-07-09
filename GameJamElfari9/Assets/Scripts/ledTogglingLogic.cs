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
    [SerializeField] private float detectionDistance = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rndr= GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position,target.transform.position) < detectionDistance && Input.GetKeyDown(KeyCode.T))
        {
            toggleState();
        }
        if (on)
        {
            rndr.material.color = onColor;
            rndr.material.SetColor("_EmissionColor", onColor);
            rndr.material.EnableKeyword("_EMISSION");
            rndr.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        }
        else
        {
            rndr.material.color = offColor;
            rndr.material.SetColor("_EmissionColor", offColor);
            rndr.material.EnableKeyword("_EMISSION");
            rndr.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
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
