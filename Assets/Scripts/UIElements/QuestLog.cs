using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestLog : MonoBehaviour
{

    public GameObject QuestLogWindow;
    public TextMeshProUGUI Quests1;
    public TextMeshProUGUI Quests2;
    public TextMeshProUGUI Quests3;
    public TextMeshProUGUI Quests4;
    public TextMeshProUGUI Quests5;
    public TextMeshProUGUI Quests6;
    public TextMeshProUGUI Quests7;
    public TextMeshProUGUI Quests8;
    public TextMeshProUGUI Quests9;
    public TextMeshProUGUI Quests10;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            QuestLogWindow.SetActive(true);
        }

        if(QuestManager.instance.questMarkersComplete[0])
        {
            Destroy(Quests1);
        }
        if (QuestManager.instance.questMarkersComplete[1])
        {
            Destroy(Quests2);
        }
        if (QuestManager.instance.questMarkersComplete[2])
        {
            Destroy(Quests3);
        }
        if (QuestManager.instance.questMarkersComplete[3])
        {
            Destroy(Quests4);
        }
        if (QuestManager.instance.questMarkersComplete[4])
        {
            Destroy(Quests5);
        }
        if (QuestManager.instance.questMarkersComplete[5])
        {
            Destroy(Quests6);
        }
        if (QuestManager.instance.questMarkersComplete[6])
        {
            Destroy(Quests7);
        }
        if (QuestManager.instance.questMarkersComplete[7])
        {
            Destroy(Quests8);
        }
        if (QuestManager.instance.questMarkersComplete[8])
        {
            Destroy(Quests9);
        }
        if (QuestManager.instance.questMarkersComplete[9])
        {
            Destroy(Quests10);
        }
       

    }
    public void CloseQuestWindon()
    {
        QuestLogWindow.SetActive(false);
    }

}
