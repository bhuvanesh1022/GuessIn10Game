using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupManager : MonoBehaviour
{
    public GameObject notEnoughPopup;
    public GameObject unlockPopup;
    public GameObject SuccessPopup;
    public GameObject currentPopup;

    public int pencilsToUnlock;

    public TextMeshProUGUI pencilsToUnlockText;
    public TextMeshProUGUI notEnoughPencilsText;
    public TextMeshProUGUI unlockContentText;

    private int unlockingType;

    public void OnUnlock()
    {
        if (GameHandler.gameHandler.pencils >= pencilsToUnlock)
        {
            GameHandler.gameHandler.types[unlockingType] = true;
            GameHandler.gameHandler.pencils -= pencilsToUnlock;
            UIManager.uim.CloseNow();

            UIManager.uim.buttons[unlockingType].transform.parent.gameObject.SetActive(false);
            SuccessPopup.SetActive(true);
            currentPopup = SuccessPopup;
            SuccessPopup.GetComponentInChildren<TextMeshProUGUI>().text = string.Format("You have Successfully Unlocked {0}!", UIManager.uim.buttons[unlockingType].name);

            Debug.Log("Unlocked");
        }
        else
        {
            Debug.Log("NotEnoughPencil");
            NotEnoughPencil();
        }
    }

    public void NotEnoughPencil()
    {
        notEnoughPencilsText.text = (pencilsToUnlock - GameHandler.gameHandler.pencils).ToString();
        notEnoughPopup.SetActive(true);
        currentPopup.SetActive(false);
        currentPopup = notEnoughPopup;
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
                pencilsToUnlock = 20;
                break;

            default:
                break;
        }

        pencilsToUnlockText.text = pencilsToUnlock.ToString();
    }
}
