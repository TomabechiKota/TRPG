using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Other_info_Mgr : MonoBehaviour {
    [SerializeField]
	InputField inputField_item;
    [SerializeField]
	InputField inputField_intro;
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
		messenger.Write_intro(inputField_item.text,inputField_intro.text);
		messenger.Save_data();
		audio_source.open_view();
		SceneManager.LoadScene ("View");
	}
}
