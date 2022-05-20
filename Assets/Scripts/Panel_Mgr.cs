using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Mgr : MonoBehaviour {
    [SerializeField]
	GameObject Panel_R;
    [SerializeField]
	GameObject Panel_jh;
    [SerializeField]
	GameObject Panel_other;
    [SerializeField]
	GameObject Button_next;
    [SerializeField]
	GameObject Button_back;
    [SerializeField]
	GameObject Panel_memo;
    [SerializeField]
	GameObject Panel_info;
    [SerializeField]
	GameObject Panel_Search;
	Audio_Source audio_source;
	// Use this for initialization
	void Start () {
		Panel_R.SetActive(true);
		Panel_jh.SetActive(false);
		Panel_other.SetActive(false);
		Button_next.SetActive(true);
		Button_back.SetActive(false);
		Panel_memo.SetActive(false);
		Panel_info.SetActive(false);
		Panel_Search.SetActive(false);
		audio_source = GameObject.Find("Audio Source").GetComponent<Audio_Source>();
	}

	public void Click_n(){
		if(Panel_R.activeSelf){
			Panel_R.SetActive(false);
			Panel_jh.SetActive(true);
			Panel_other.SetActive(false);
			Button_next.SetActive(true);
			Button_back.SetActive(true);
		}else if(Panel_jh.activeSelf){
			Panel_R.SetActive(false);
			Panel_jh.SetActive(false);
			Panel_other.SetActive(true);
			Button_next.SetActive(false);
			Button_back.SetActive(true);
		}
		audio_source.next_page_light();
	}
	public void Click_b(){
		if(Panel_jh.activeSelf){
			Panel_R.SetActive(true);
			Panel_jh.SetActive(false);
			Panel_other.SetActive(false);
			Button_next.SetActive(true);
			Button_back.SetActive(false);
		}else if(Panel_other.activeSelf){
			Panel_R.SetActive(false);
			Panel_jh.SetActive(true);
			Panel_other.SetActive(false);
			Button_next.SetActive(true);
			Button_back.SetActive(true);
		}
		audio_source.next_page_light();
	}
	public void Open_Memo(){
		Panel_memo.SetActive(true);
	}
	public void Close_Memo(){
		Panel_memo.SetActive(false);
	}
	public void Open_info(){
		Panel_info.SetActive(true);
	}
	public void Close_info(){
		Panel_info.SetActive(false);
	}
	public void Open_Search(){
		Panel_Search.SetActive(true);
	}
	public void Close_Search(){
		Panel_Search.SetActive(false);
	}


}
