using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.UI;
using TMPro;

public class PlayFabManager : MonoBehaviour {

    [Header("UI")]
    public TMP_Text messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

   public void RegisterButton() {
        if(passwordInput.text.Length < 6){
            messageText.text = "Password too short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    public void LoginButton(){
        if(passwordInput.text.Length < 6){
            messageText.text = "Password too short!";
            return;
        }
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        messageText.text = "Registered and logged in!";
        SceneManager.LoadScene("Menu");
    }

    void OnLoginSuccess (LoginResult result){
        messageText.text = "Logged in!";
        Debug.Log("Successful login/account create!");
        SceneManager.LoadScene("Menu");
    }

    void OnError(PlayFabError error) {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }
}
