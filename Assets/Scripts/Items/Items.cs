using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [Header("Items Type")]
    public bool isItem;
     public bool isWeapon;
    public bool isArmor;
    
    public string itemName, description;
    [Header("Items Value")]
    public int value;

    public Sprite itemSprite;
    [Header("Items Details")]
    public int ammountToChange;
    public bool affectHP, affectMP, affectStr;
    public int  weponStr, armorStr;
    public bool faceCovering;
    public static Items instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use(int charToUseOn)
    {
        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];

        if(isItem)
        {
            if(affectHP)
            {
                selectedChar.currentHP += ammountToChange;

                if(selectedChar.currentHP > selectedChar.maxHP)
                {
                    selectedChar.currentHP = selectedChar.maxHP;
                }
            }

            if (affectMP)
            {
                selectedChar.currentMP += ammountToChange;

                if (selectedChar.currentMP > selectedChar.maxMP)
                {
                    selectedChar.currentMP = selectedChar.maxMP;
                }
            }
            if(affectStr)
            {
                selectedChar.strength += ammountToChange;
            }


        }
        if(isWeapon)
        {
            if(selectedChar.equippedWpn != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedWpn);

            }
            selectedChar.equippedWpn = itemName;
            selectedChar.wpnPwr = weponStr;
            AudioManager.instance.PlaySFX(7);
        }

        if(isArmor)
        {
            if (selectedChar.equippedArmr != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedArmr);

            }
            selectedChar.equippedArmr = itemName;
            selectedChar.armorPwr = armorStr;
        }

        GameManager.instance.RemoveItem(itemName);
    }
    
 }

