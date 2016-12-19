
using UnityEngine;
//using UnityEditor;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//[InitializeOnLoad]
public class opening : MonoBehaviour {
	public UserData userData;
	// Use this for initialization
	void Start () {
		
        GameObject obj = new GameObject();
		userData = obj.AddComponent<UserData>();

	}
	
	// Update is called once per frame
	void Update () {

	}

    void checkStatus()
    {
        if (userData.checkStatus())
        {
            userData.LoadTwitterUserInfo();
            SceneManager.LoadScene("TimeLine");
        }
        else
        {
            SceneManager.LoadScene("Regist");
        }
    }



	public void OnClickStartButton(){
		checkStatus();
	}

	public void OnClickDeleteButton(){
		PlayerPrefs.DeleteAll ();
	}

	public void OnClickDrawButton(){
		SceneManager.LoadScene ("Paint");
	
	}


}
