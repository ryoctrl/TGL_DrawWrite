using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;
using System.Text;


public class SaveButton : MonoBehaviour {

	const string TweetPicture = "TweetPic";


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnClick(){
        //Application.CaptureScreenshot ("ScreenShot.png");




        //テスト用画像読み込み
        string filepath = "test.jpg";
        FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
        BinaryReader bin = new BinaryReader(fileStream);
        byte[] bytess = bin.ReadBytes((int)bin.BaseStream.Length);

        bin.Close();

        Texture2D tex = new Texture2D(400, 300, TextureFormat.ARGB32, false);
        tex.LoadImage(bytess);

        //ここまで



        //Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
        //tex.ReadPixels ( new Rect(30, 0, Screen.width, Screen.height), 0, 0);
        tex.Apply ();

		byte[] bytes = tex.EncodeToPNG();

        string text = Convert.ToBase64String(bytes);
		print (text);

		PlayerPrefs.SetString (TweetPicture, text);

		//SceneManager.LoadScene("")



		//
		//Destroy (tex);
	    File.WriteAllBytes("ScreenShotOfButton.png", bytes);

		//saved_screen_capture = true;

		SceneManager.LoadScene ("Tweet");
	}
		
}




	