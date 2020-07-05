using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupManager : MonoBehaviour
{
    public GameObject notEnoughPopup;
    public GameObject unlockPopup;

    public int pencilCount;
    public int pencilsToUnlock;

    public TextMeshProUGUI pencilsToUnlockText;
    public TextMeshProUGUI notEnoughPencilsText;
    public TextMeshProUGUI unlockContentText;


    public void OnUnlock(int id)
    {
        if (GameHandler.gameHandler.pencils >= pencilsToUnlock)
        {
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
    }

    public void ToUnlockGuess(int id)
    {
        unlockPopup.SetActive(true);

        switch (id)
        {
            case 1:
                unlockContentText.text = "To Unlock Animals Use";
                pencilsToUnlock = 10;
                pencilsToUnlockText.text = pencilsToUnlock.ToString();
                break;

            case 2:
                unlockContentText.text = "To Unlock Birds Use";
                pencilsToUnlock = 20;
                pencilsToUnlockText.text = pencilsToUnlock.ToString();
                break;

            default:
                break;
        }
    }
}
