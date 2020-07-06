using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupManager : MonoBehaviour
{
    public static PopupManager popupManager;


    public GameObject notEnoughPopup;
    public GameObject unlockPopup;
    public GameObject SuccessPopup;
    public GameObject currentPopup;

    public int pencilsToUnlock;

    public TextMeshProUGUI pencilsToUnlockText;
    public TextMeshProUGUI notEnoughPencilsText;
    public TextMeshProUGUI unlockContentText;

    private int unlockingType;

    private void Awake()
    {
        if (PopupManager.popupManager == null)
        {
            PopupManager.popupManager = this;
        }
        else
        {
            if (PopupManager.popupManager != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public void ToUnlockGuess(int id)
    {
        unlockPopup.SetActive(true);
        currentPopup = unlockPopup;
        unlockingType = id;

        unlockContentText.text = string.Format("To Unlock {0} Use", UIManager.uim.buttons[unlockingType].name);

        switch (id)
        {
            case 1:
                pencilsToUnlock = 10;
                break;

            case 2:
                pencilsToUnlock = 15;
                break;

            default:
                break;
        }

        pencilsToUnlockText.text = pencilsToUnlock.ToString();
    }

    public void OnUnlock()
    {
        if (GameHandler.gameHandler.pencils < pencilsToUnlock)
        {

            Debug.Log("NotEnoughPencil");
            NotEnoughPencil();
        }
        else
        {
            GameHandler.gameHandler.types[unlockingType] = true;
            GameHandler.gameHandler.pencils -= pencilsToUnlock;
            //GameHandler.gameHandler.UpdatePencils();
            //UIManager.uim.CloseNow();

            UIManager.uim.buttons[unlockingType].transform.parent.gameObject.SetActive(false);

            OnSuccessEvent("unlock", 0);

            Debug.Log("Unlocked");
        }
    }

    public void NotEnoughPencil()
    {
        notEnoughPencilsText.text = (pencilsToUnlock - GameHandler.gameHandler.pencils).ToString();
        notEnoughPopup.SetActive(true);
        currentPopup.SetActive(false);
        currentPopup = notEnoughPopup;
    }

    public void OnSuccessEvent(string curEvent, int pencils)
    {
        SuccessPopup.SetActive(true);
        currentPopup.SetActive(false);
        currentPopup = SuccessPopup;

        switch (curEvent)
        {
            case "unlock":
                SuccessPopup.GetComponentInChildren<TextMeshProUGUI>().text = string.Format
                    ("You have Successfully Unlocked {0}!", UIManager.uim.buttons[unlockingType].name);
                break;

            case "purchase":
                SuccessPopup.GetComponentInChildren<TextMeshProUGUI>().text = string.Format
                    ("You have Successfully Purchased {0} Pencils", pencils.ToString());
                break;

            default:
                break;
        }


    }
}
