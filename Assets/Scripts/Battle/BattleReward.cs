using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleReward : MonoBehaviour
{
    public static BattleReward instance;
    public TextMeshProUGUI xpText, itemText;
    public GameObject rewardScreen;
    public string[] rewardItems;
    public int xpEarned;
    public bool markCompleteQuest;
    public string questToMark;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenRewardScreen(int xp, string[] rewards)
    {
        xpEarned = xp;
        rewardItems = rewards;

        xpText.text = xpEarned + "xp earned";
        itemText.text = "";

        for(int i =0; i < rewardItems.Length; i++)
        {
            itemText.text += rewards[i] + "\n";
        }
        rewardScreen.SetActive(true);
    }
    public void CloseRewardScreen()
    {
        for(int i = 0; i <GameManager.instance.playerStats.Length; i++)
        {
            if(GameManager.instance.playerStats[i].gameObject.activeInHierarchy)
            {
                GameManager.instance.playerStats[i].AddExp(xpEarned);
            }
        }
        for (int i = 0; i <rewardItems.Length; i++)
        {
            GameManager.instance.AddItem(rewardItems[i]);
        }
            rewardScreen.SetActive(false);
        GameManager.instance.battleActive = false;
        if(markCompleteQuest)
        {
            QuestManager.instance.MarkQuestComplete(questToMark);
        }
    }
}
