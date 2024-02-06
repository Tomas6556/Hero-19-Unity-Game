using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStarter : MonoBehaviour
{
    public BattleType[] potentialBattles;
    private bool inArea;
    public bool activateOnEnter, activateOnStay, activateOnExit;
    public float timeBetweenBattles, betweenBattleValue;

    public bool deativateAfterStarting;
    public bool canNotFlee;
    public bool shoudCompleteQuest;
    public string QuestToComplete;
    
    // Start is called before the first frame update
    void Start()
    {
        betweenBattleValue = Random.Range(timeBetweenBattles * .5f, timeBetweenBattles * 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(inArea && PlayerController.instance.canMove)
        {
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                betweenBattleValue -= Time.deltaTime;
            }
            if(betweenBattleValue <= 0)
            {
                betweenBattleValue = Random.Range(timeBetweenBattles * .5f, timeBetweenBattles * 1.5f);

               StartCoroutine(StartBattleCo());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(activateOnEnter)
            {
                StartCoroutine(StartBattleCo());
            }else
            {
                inArea = true;
            }
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(activateOnExit)
            {
                StartCoroutine(StartBattleCo());
            }
            else
            {
                inArea = false;
            } 
        }
    }

    public IEnumerator StartBattleCo()
    {
        UIFade.instance.FadeToBlack();
        GameManager.instance.battleActive = true;
        int selectedBattle = Random.Range(0, potentialBattles.Length);
        BattleManager.instance.rewardItems = potentialBattles[selectedBattle].rewardItems;
        BattleManager.instance.rewardXP = potentialBattles[selectedBattle].rewardXP;

        yield return new WaitForSeconds(1.5f);

        BattleManager.instance.BattleStart(potentialBattles[selectedBattle].enemies, canNotFlee);
        UIFade.instance.FadeFromBlack();

        if(deativateAfterStarting)
        {
            gameObject.SetActive(false);
        }

        BattleReward.instance.markCompleteQuest = shoudCompleteQuest;
        BattleReward.instance.questToMark = QuestToComplete;
    }
}
