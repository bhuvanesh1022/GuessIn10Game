using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    public static AdManager adManager;

    private string playStoreId = "3696407";
    private string appStoreId = "3696406";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool isTestAd;

    public int rewardedPencils;

    private void Awake()
    {
        if (AdManager.adManager == null)
        {
            AdManager.adManager = this;
        }
        else
        {
            if (AdManager.adManager != this)
            {
                Destroy(gameObject);
            }
        }
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
        rewardedPencils = 10;
    }

    private void InitializeAdvertisement()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreId, isTestAd);
            return;
        }
        Advertisement.Initialize(appStoreId, isTestAd);
    }

    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        Advertisement.Show(interstitialAd);
    }

    public void PlayRewardedVideoAd()
    {
        if (!Advertisement.IsReady(rewardedVideoAd))
        {
            return;
        }
        Advertisement.Show(rewardedVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads Ready!");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log(message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ads Started!");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                break;

            case ShowResult.Skipped:
                break;

            case ShowResult.Finished:
                if (placementId == rewardedVideoAd)
                {
                    GameHandler.gameHandler.pencils += rewardedPencils;
                    //GameHandler.gameHandler.UpdatePencils();
                    PopupManager.popupManager.OnSuccessEvent("purchase", rewardedPencils);
                }
                break;

            default:
                break;
        }
    }
}
