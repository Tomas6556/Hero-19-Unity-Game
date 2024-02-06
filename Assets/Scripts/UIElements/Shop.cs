using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    public static Shop instance;

    public GameObject shopMenu, buyMenu, sellMenu;

    public TextMeshProUGUI goldText;

    public string[] itemsForSale;

    public ItemButton[] buyItemButtons;
    public ItemButton[] sellItemButtons;

    public Items selectedItem;
    public TextMeshProUGUI buyItemName, buyItemDescription, buyItemValue;
    public TextMeshProUGUI sellItemName, sellItemDescription, sellItemValue;
    private int selectedItemQuantity;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void OpenShop()
    {
        shopMenu.SetActive(true);

        GameManager.instance.shopActive = true;

        goldText.text = GameManager.instance.currentGold.ToString() + "£";
    }

    public void CloseShop()
    {
        shopMenu.SetActive(false);

        GameManager.instance.shopActive = false;
    }

    public void OpenBuyMenu()
    {
        buyItemButtons[0].Press();
        buyMenu.SetActive(true);
        sellMenu.SetActive(false);

        for (int i = 0; i < buyItemButtons.Length; i++)
        {
            buyItemButtons[i].buttonValue = i;

            if (itemsForSale[i] != "")
            {
                buyItemButtons[i].ButtonImage.gameObject.SetActive(true);
                buyItemButtons[i].ButtonImage.sprite = GameManager.instance.GetItemDetails(itemsForSale[i]).itemSprite;
                buyItemButtons[i].amountText.text = "";
            }
            else
            {
                buyItemButtons[i].ButtonImage.gameObject.SetActive(false);
                buyItemButtons[i].amountText.text = "";
            }
        }
    }

    public void OpenSellMenu()
    {
        sellItemButtons[0].Press();
        buyMenu.SetActive(false);
        sellMenu.SetActive(true);

        GameManager.instance.SortItems();

        ShowSellItems();
    }

    public void SelectBuyItem(Items buyItem)
    {
        selectedItem = buyItem;

        buyItemName.text = selectedItem.itemName;
        buyItemDescription.text = selectedItem.description;
        buyItemValue.text = "Value: " + selectedItem.value + "£";
    }

    public void SelectSellItem(Items sellItem, int sellItemQuality)
    {
        selectedItem = sellItem;
        selectedItemQuantity = sellItemQuality;
        sellItemName.text = selectedItem.itemName;
        sellItemDescription.text = selectedItem.description;
        sellItemValue.text = "Value: " + Mathf.FloorToInt(selectedItem.value * 0.5f).ToString() + "£";

    }

    private void ShowSellItems()
    {
        for (int i = 0; i < sellItemButtons.Length; i++)
        {
            sellItemButtons[i].buttonValue = i;

            if (GameManager.instance.itemsHeld[i] != "")
            {
                sellItemButtons[i].ButtonImage.gameObject.SetActive(true);
                sellItemButtons[i].ButtonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[i]).itemSprite;
                sellItemButtons[i].amountText.text = GameManager.instance.numberOfItems[i].ToString();
            }
            else
            {
                sellItemButtons[i].ButtonImage.gameObject.SetActive(false);
                sellItemButtons[i].amountText.text = "";
            }
        }
    }

    public void BuyItem()
    {
        if (selectedItem != null)
        {


            if (GameManager.instance.currentGold >= selectedItem.value)
            {
                GameManager.instance.currentGold -= selectedItem.value;

                GameManager.instance.AddItem(selectedItem.itemName);

            }

            goldText.text = GameManager.instance.currentGold.ToString() + "£";
        }
    }
    public void SellItem()
    {
        if(selectedItem != null)
        {
            GameManager.instance.currentGold += Mathf.FloorToInt(selectedItem.value * 0.5f);

            GameManager.instance.RemoveItem(selectedItem.itemName);

            selectedItemQuantity--;
            if(selectedItemQuantity <= 0)
            {
                selectedItem = null;
            }
        }

        goldText.text = GameManager.instance.currentGold.ToString() + "£";

        ShowSellItems();
    }
}
