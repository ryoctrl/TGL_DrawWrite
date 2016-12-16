using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.SceneManagement;
using System.IO;

public class Tweet : MonoBehaviour {

    public InputField inputTweetField;

    const string CONSUMER_KEY = "SJbrS9T0QWNlkiWnH8ZbNBGWx";
    const string CONSUMER_SECRET = "wIjvWwgLo5XO7HDXfrgVF9xDAyZBaep2cEUd08a4tuTE3kyQGs";
	const string PLAYER_PREFS_TWEETPIC = "TweetPic";

    UserData userData;


    void Awake () {
		GameObject obj = new GameObject ();
		userData = obj.AddComponent<UserData>();
	}


    public void OnClickTweetButon()
    {

		Twitter.AccessTokenResponse response = userData.getUserData ();

		if (string.IsNullOrEmpty (PlayerPrefs.GetString (PLAYER_PREFS_TWEETPIC))) {
            
			string myTweet = inputTweetField.text.ToString ();

			if (!(string.IsNullOrEmpty (myTweet)) && !(myTweet.Trim () == "")) {

				string log = response.UserId + "\n";
				log += response.ScreenName + "\n";
				log += response.Token + "\n";
				log += response.TokenSecret + "\n";
				log += myTweet;
				print (log);
					
				StartCoroutine (Twitter.API.PostTweet (myTweet, CONSUMER_KEY, CONSUMER_SECRET, response,
					new Twitter.PostTweetCallback (this.OnPostTweet)));
			} else {
				inputTweetField.text = "";
			}
		} else {
            
			string picture = PlayerPrefs.GetString (PLAYER_PREFS_TWEETPIC);

            
			StartCoroutine (Twitter.API.UploadPic (picture, CONSUMER_KEY, CONSUMER_SECRET, response,
				new Twitter.UploadPicCallback (this.OnUploadPic)));

            /*
			byte[] bytes = Convert.FromBase64String (picture);

			File.WriteAllBytes ("ScreenShot.png", bytes);
            */
            PlayerPrefs.DeleteKey(PLAYER_PREFS_TWEETPIC);
		
		}

    }

    void OnPostTweet(bool success, string response)
    {
        print("OnPostTweet - " + (success ? "succedded." : "failed."));
		if (success) {
			var json = JSON.Parse (response);

			print ("TweetID:" + json ["id"]);

            SceneManager.LoadScene("TimeLine");
		} else {
			SceneManager.LoadScene("Regist");
		}
    }

	
	void OnUploadPic(bool success, string response)
	{
		print ("OnUploadPic - " + (success ? "succedded. " : "failed"));
			if(success){
				var json = JSON.Parse(response);
				print("PicID:" + json["media_id_string"]);
			}
	}


				
				
	


}
