using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class Select_file_Mgr : MonoBehaviour {
	[SerializeField]
    Dropdown dropdown;
	Messenger messenger;
	Audio_Source audio_source;
	string[] fileList;
	// Use this for initialization
	void Start () {
		messenger = GameObject.Find("Messenger").GetComponent<Messenger>();
		audio_source = GameObject.Find("Audio Source").GetComponent<Audio_Source>();
		draw_dropdown();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void draw_dropdown(){
		fileList = Directory.GetFiles("output", "*.txt");
		foreach(string f in fileList){
			dropdown.options.Add(new Dropdown.OptionData { text = f.Split('.','\\')[1] });
		}
		dropdown.RefreshShownValue();	
	}

	public void click_next(){
		if(messenger.Input_Nmae(fileList[dropdown.value].Split('.','\\')[1])){
			audio_source.open_view();
			SceneManager.LoadScene ("View");
		}else{
			audio_source.blip();
		}
	}

}
