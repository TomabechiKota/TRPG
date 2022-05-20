using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Roll_Mgr : MonoBehaviour {
	
    [SerializeField]
	InputField inputField_name;
    [SerializeField]
	InputField inputField;
    [SerializeField]
	InputField inputField_age;
    [SerializeField]
	InputField inputField_country;
	Audio_Source audio_source;
	Messenger messenger;

	// Use this for initialization
	void Start () {
		messenger = GameObject.Find("Messenger").GetComponent<Messenger>();
		audio_source = GameObject.Find("Audio Source").GetComponent<Audio_Source>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void click_next(){
		if(messenger.Decide_states(inputField_name.text,inputField.text,inputField_age.text,inputField_country.text)){
			SceneManager.LoadScene ("Select_job");
			audio_source.next_page();	
		}else{
			audio_source.blip();
		}
	}

}
