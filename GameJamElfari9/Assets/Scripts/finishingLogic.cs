using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishingLogic : MonoBehaviour
{

    [SerializeField] private GameObject targetObject;
    [SerializeField] private GameObject mesuringObject;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(targetObject.transform.position,transform.position )< Vector3.Distance(targetObject.transform.position, mesuringObject.transform.position) && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("StartClassScene");
        }
    }
}
