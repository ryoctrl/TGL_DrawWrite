using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using SimpleJSON;


public class TimeLine : MonoBehaviour {

	UserData userData;
	Twitter.AccessTokenResponse AccessToken;
    const string CONSUMER_KEY = "SJbrS9T0QWNlkiWnH8ZbNBGWx";
    const string CONSUMER_SECRET = "wIjvWwgLo5XO7HDXfrgVF9xDAyZBaep2cEUd08a4tuTE3kyQGs";


    // Use this for initialization
    void Awake () {
		GameObject obj = new GameObject ();
		userData = obj.AddComponent<UserData> ();
		AccessToken = userData.getUserData();
        StartCoroutine(Twitter.API.GetUserTimeline(AccessToken.UserId, CONSUMER_KEY, CONSUMER_SECRET, AccessToken,
                                       new Twitter.GetUserTimelineCallback(this.OnGetUserTimeline)));
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClickTweetButton()
    {
        SceneManager.LoadScene("Tweet");
    }

    void OnGetUserTimeline(bool success, string response)
    {
        print("GetUserTimeline- " + (success ? "succedded." : "failed."));

        if (success)
        {
            var json = JSON.Parse(response);
            JSONNode jsonno = new JSONNode();
            print(json);
            //string text = JsonUtility.FromJson(json, typeof
        }
    }
   


}
