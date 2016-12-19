using UnityEngine;

public class UserData : MonoBehaviour {

	//ApplicationKey
	const string CONSUMER_KEY = "Input your CONSUMER_KEY";
	const string CONSUMER_SECRET = "Input your CONSUMER_SECRET";



	//UserInfoField
	const string PLAYER_PREFS_TWITTER_USER_ID           = "TwitterUserID";
    const string PLAYER_PREFS_TWITTER_USER_SCREEN_NAME  = "TwitterUserScreenName";
	const string PLAYER_PREFS_TWITTER_USER_TOKEN        = "TwitterUserToken";
	const string PLAYER_PREFS_TWITTER_USER_TOKEN_SECRET = "TwitterUserTokenSecret";

	public Twitter.AccessTokenResponse AccessTokenResponse;

    void Awake()
    {
        LoadTwitterUserInfo();
    }

	public UserData()
	{
		//LoadTwitterUserInfo ();
	}

	public bool checkStatus()
	{
		bool ret = false;
		if (!string.IsNullOrEmpty(AccessTokenResponse.UserId)&&
			!string.IsNullOrEmpty(AccessTokenResponse.ScreenName)&&
			!string.IsNullOrEmpty(AccessTokenResponse.Token)&&
			!string.IsNullOrEmpty(AccessTokenResponse.TokenSecret)) 
		{
			Debug.Log(PlayerPrefs.GetString(PLAYER_PREFS_TWITTER_USER_ID));
			ret = true;
		}
		return ret;
			
	}

    

    public Twitter.AccessTokenResponse getUserData()
    {
        AccessTokenResponse.UserId = PlayerPrefs.GetString(PLAYER_PREFS_TWITTER_USER_ID);
        AccessTokenResponse.ScreenName = PlayerPrefs.GetString(PLAYER_PREFS_TWITTER_USER_SCREEN_NAME);
        AccessTokenResponse.Token = PlayerPrefs.GetString(PLAYER_PREFS_TWITTER_USER_TOKEN);
        AccessTokenResponse.TokenSecret = PlayerPrefs.GetString(PLAYER_PREFS_TWITTER_USER_TOKEN_SECRET);

        return AccessTokenResponse;
    }

	public void setUserData(Twitter.AccessTokenResponse response)
	{
		PlayerPrefs.SetString(PLAYER_PREFS_TWITTER_USER_ID, response.UserId);
		PlayerPrefs.SetString(PLAYER_PREFS_TWITTER_USER_SCREEN_NAME, response.ScreenName);
		PlayerPrefs.SetString(PLAYER_PREFS_TWITTER_USER_TOKEN, response.Token);
		PlayerPrefs.SetString(PLAYER_PREFS_TWITTER_USER_TOKEN_SECRET, response.TokenSecret);
	}

    public void LoadTwitterUserInfo()
    {
        AccessTokenResponse = new Twitter.AccessTokenResponse();

        AccessTokenResponse.UserId = PlayerPrefs.GetString(PLAYER_PREFS_TWITTER_USER_ID);
        AccessTokenResponse.ScreenName = PlayerPrefs.GetString(PLAYER_PREFS_TWITTER_USER_SCREEN_NAME);
        AccessTokenResponse.Token = PlayerPrefs.GetString(PLAYER_PREFS_TWITTER_USER_TOKEN);
        AccessTokenResponse.TokenSecret = PlayerPrefs.GetString(PLAYER_PREFS_TWITTER_USER_TOKEN_SECRET);
    }




}
