using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour {

	const string CONSUMER_KEY = "SJbrS9T0QWNlkiWnH8ZbNBGWx";
	const string CONSUMER_SECRET = "wIjvWwgLo5XO7HDXfrgVF9xDAyZBaep2cEUd08a4tuTE3kyQGs";


	public InputField InputPIN;


    UserData userData;

	Twitter.AccessTokenResponse AccessTokenResponse;

    string Token;



    // Use this for initialization
    void Awake () {
        GameObject obj = new GameObject();
        userData = obj.AddComponent<UserData>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClickAddButton()
    {
        StartCoroutine(Twitter.API.GetRequestToken(CONSUMER_KEY, CONSUMER_SECRET, new Twitter.RequestTokenCallback(this.OnRequestTokenCallback)));
    }

    void OnRequestTokenCallback(bool success, Twitter.RequestTokenResponse response)
    {
        if (success)
        {
            string log = "OOnRequestTokenCallback - succeeded";
            log += "\n      Token : " + response.Token;
            log += "\n      TokenSecret : " + response.TokenSecret;
            print(log);

			Token  = response.Token;
            print(Token);
            Twitter.API.OpenAuthorizationPage(response.Token);
        }
        else
        {
            print("OnRequestTokenCallback - failed.");
        }
    }

    public void OnClickEnterPINButton()
    {
		string PIN = InputPIN.text.ToString ();
        
		StartCoroutine(Twitter.API.GetAccessToken(CONSUMER_KEY, CONSUMER_SECRET, Token, PIN, 
													new Twitter.AccessTokenCallback(this.OnAccessTokenCallback)));
    }

    void OnAccessTokenCallback(bool success, Twitter.AccessTokenResponse response)
    {
        if (success)
        {
            string log = "OnAccessTokenCallback - succeeded";
            log += "\n    UserId : " + response.UserId;
            log += "\n    ScreenName : " + response.ScreenName;
            log += "\n    Token : " + response.Token;
            log += "\n    TokenSecret : " + response.TokenSecret;
            print(log);

            AccessTokenResponse = response;

			userData.setUserData (response);
			SceneManager.LoadScene("TimeLine");
        }
        else
        {
            print("OnAccessTokenCallback - failed.");
        }
    }


}
