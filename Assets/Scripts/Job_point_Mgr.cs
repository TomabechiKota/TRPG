using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Job_point_Mgr : MonoBehaviour {

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
		if(messenger.Decide_job_points()){
			audio_source.next_page();	
			SceneManager.LoadScene ("Distribute_points");
		}else{
			audio_source.blip();
		}
	}
}
