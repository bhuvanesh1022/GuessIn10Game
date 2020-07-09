using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayFabLogin : MonoBehaviour
{
    private string UserEmail, UserPassword,Username;
    public GameObject LoginPanel;
    public TextMeshProUGUI DisplayError;

    public GameObject AddloginPanel;
    public GameObject RecoveryButton;
    public void Start()
    {
       // PlayerPrefs.DeleteAll();
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Please change the titleId below to your own titleId from PlayFab Game Manager.
            If you have already set the value in the Editor Extensions, this can be skipped.
            */
            PlayFabSettings.staticSettings.TitleId = "B3B9E";
        }
        //var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        //PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        if (PlayerPrefs.HasKey("EMAIL"))
        {
            UserEmail = PlayerPrefs.GetString("EMAIL");
            UserPassword = PlayerPrefs.GetString("PASSWORD");
            var request = new LoginWithEmailAddressRequest { Email = UserEmail, Password = UserPassword };
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
        }
//        else
//        {
//#if UNITY_ANDROID
//            var requestAndroid = new LoginWithAndroidDeviceIDRequest { AndroidDeviceId = ReturnMobileId(), CreateAccount = true };
//            PlayFabClientAPI.LoginWithAndroidDeviceID(requestAndroid, OnLoginAndroidSuccess, OnLoginAndroidFailure);
//#endif
//#if UNITY_IOS
//            var requestIOS=new LoginWithIOSDeviceIDRequest{DeviceId = ReturnMobileId(), CreateAccount = true};
//            PlayFabClientAPI.LoginWithIOSDeviceID(requestAndroid, OnLoginAndroidSuccess, OnLoginAndroidFailure);

//#endif
      //  }
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        DisplayError.text = "Congratulations, you made your first successful API call!";
        PlayerPrefs.SetString("EMAIL", UserEmail);
        PlayerPrefs.SetString("PASSWORD", UserPassword);
       // LoginPanel.SetActive(false);
        SceneManager.LoadScene("Wrapper");
    }
    private void OnLoginAndroidSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        DisplayError.text = "Congratulations, you made your first successful API call!";
        PlayerPrefs.SetString("EMAIL", UserEmail);
        PlayerPrefs.SetString("PASSWORD", UserPassword);
        // LoginPanel.SetActive(false);
        SceneManager.LoadScene("Wrapper");
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        DisplayError.text = "Congratulations, you made your first successful API call!";

        PlayerPrefs.SetString("EMAIL",UserEmail);
        PlayerPrefs.SetString("PASSWORD", UserPassword);
        //LoginPanel.SetActive(false);
        SceneManager.LoadScene("Wrapper");

    }
    private void OnLoginFailure(PlayFabError error)
    {
        var Registerrequest = new RegisterPlayFabUserRequest { Email = UserEmail, Password = UserPassword,Username=Username};
        PlayFabClientAPI.RegisterPlayFabUser(Registerrequest, OnRegisterSuccess, OnRegisterFailure);
    }
    private void OnLoginAndroidFailure(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
        DisplayError.text = error.ErrorMessage;
        Invoke("Stopinvoke",1f);
    }
    void Stopinvoke()
    {
        DisplayError.text = "";
    }
    public void GetUserEmail(string emailIn)
    {
        UserEmail = emailIn;
    }
    public void GetUserPassword(string passwordIn)
    {
        UserPassword = passwordIn;

    }
    public void GetUserName(string usernameIn)
    {
        Username = usernameIn;
    }
    public void OnClickLogin()
    {
        var request = new LoginWithEmailAddressRequest { Email = UserEmail, Password = UserPassword };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);

    }

    public static string ReturnMobileId()
    {
        string deviceId = SystemInfo.deviceUniqueIdentifier;
        return deviceId;
    }

    public void openAddLogin()
    {
        AddloginPanel.SetActive(true);
    }
    public void OnClickAddLogin()
    {
        var addLoginrequest = new AddUsernamePasswordRequest { Email = UserEmail, Password = UserPassword, Username = Username };
        PlayFabClientAPI.AddUsernamePassword(addLoginrequest, OnAddLoginSuccess, OnRegisterFailure);

    }
    private void OnAddLoginSuccess(AddUsernamePasswordResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        DisplayError.text = "Congratulations, you made your first successful API call!";
        PlayerPrefs.SetString("EMAIL", UserEmail);
        PlayerPrefs.SetString("PASSWORD", UserPassword);
        // LoginPanel.SetActive(false);
        SceneManager.LoadScene("Wrapper");
    }

}