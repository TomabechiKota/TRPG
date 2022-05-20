using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Source : MonoBehaviour {
    [SerializeField]
	AudioClip not_fill;
    [SerializeField]
	AudioClip page;
    [SerializeField]
	AudioClip Dice;
    [SerializeField]
	AudioClip Write;
    [SerializeField]
	AudioClip Write_long;
    [SerializeField]
	AudioClip next_light;
	AudioSource audioSource;

	void Start () {
		DontDestroyOnLoad(this);
		//Componentを取得
		audioSource = GetComponent<AudioSource>();
	}

	void Update () {
	// 左
	}

	public void blip(){
		audioSource.PlayOneShot(not_fill);
	}

	public void next_page(){
		audioSource.PlayOneShot(page);
	}
	public void next_page_light(){
		audioSource.PlayOneShot(next_light);
	}
	public void open_view(){
		audioSource.PlayOneShot(Write_long);
	}

	public void Roll(){
		audioSource.PlayOneShot(Dice);
	}
	public void Write_other(){
		audioSource.PlayOneShot(Write);
	}
	public void Write_name(){
		audioSource.PlayOneShot(Write_long);
	}

}
