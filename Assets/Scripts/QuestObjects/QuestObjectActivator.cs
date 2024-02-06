using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjectActivator : MonoBehaviour
{
    public GameObject objectToActivate;

    public string QuestToCheck;

    public bool activeIfComplate;

    private bool initialCheckDone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!initialCheckDone)
        {
            initialCheckDone = true;

            CheckCompletion();
        }
    }
    public void CheckCompletion()
    {
        if(QuestManager.instance.CheckIfComplete(QuestToCheck))
        {
            objectToActivate.SetActive(activeIfComplate);


        }
    }
}
