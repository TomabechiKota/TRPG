using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_Mgr : MonoBehaviour {
    [SerializeField]
	Sprite image_1;
    [SerializeField]
	Sprite image_2;
	
	Messenger messenger;
	// Use this for initialization
	void Start () {
		messenger = GameObject.Find("Messenger").GetComponent<Messenger>();
		int r = Random.Range(0,2);
		if(r == 0){
			messenger.Set_Back_ground(image_1);
		}else{
			messenger.Set_Back_ground(image_2);
		}
	}
	public void click_make(){
		SceneManager.LoadScene ("Roll");
	}
	public void click_view(){
		SceneManager.LoadScene ("Select_file");
	}
	
}
