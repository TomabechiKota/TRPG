using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select_job_Mgr : MonoBehaviour {
    [SerializeField]
	InputField inputField_job;
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
		if(messenger.Decide_jobs(inputField_job.text)){
			//SceneManager.LoadScene ("Distribute_points");
			audio_source.next_page();	
			SceneManager.LoadScene ("Job_point");
		}else{
			audio_source.blip();
		}
	}
}
