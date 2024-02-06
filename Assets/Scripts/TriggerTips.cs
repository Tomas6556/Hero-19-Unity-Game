using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTips : MonoBehaviour
{
    public GameObject TipWindow;


    public void CloseQuestWindon()
    {
        TipWindow.SetActive(false);
    }


}
