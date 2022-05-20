using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Distribute_points_Mgr : MonoBehaviour {
    [SerializeField]
	InputField inputField_hobby;
	Messenger messenger;
	Audio_Source audio_source;

	// Use this for initialization
	void Start () {
		messenger = GameObject.Find("Messenger").GetComponent<Messenger>();
		audio_source = GameObject.Find("Audio Source").GetComponent<Audio_Source>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void click_next(){
		if(messenger.Decide_hobby_points(inputField_hobby.text)){
			audio_source.next_page();	
			SceneManager.LoadScene ("Other_info");
		}else{
			audio_source.blip();
		}
	}
}
