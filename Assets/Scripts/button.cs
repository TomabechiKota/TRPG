using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {
	Text_Mgr text;
	Button_Mgr B_Mgr;
	Text_Mgr_job_states text_j;
	Button_Mgr_job B_Mgr_j;
//	Text_Mgr_v text_v;
	Button_Mgr_v B_Mgr_v;

	int type = 0;
	int num = 0;
	int field = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick(){
		if(field == 0){
			text_j.click();
			B_Mgr_j.click(type,num);
		}
		if(field == 1){
			text.click();
			B_Mgr.click(type,num);
		}
		if(field == 2){
			//text_v.click();
			B_Mgr_v.click(type,num);
		}
    }

	public void set_type(int t,int n,int f){
		type = t;
		num = n;
		field = f;
		if(field == 0){
			B_Mgr_j = GameObject.Find("Button_Mgr_job").GetComponent<Button_Mgr_job>();
			text_j = GameObject.Find("Text_Mgr_job_states").GetComponent<Text_Mgr_job_states>();
		}
		if(field == 1){
			B_Mgr = GameObject.Find("Button_Mgr").GetComponent<Button_Mgr>();
			text = GameObject.Find("Text_Mgr").GetComponent<Text_Mgr>();
		}
		if(field == 2){
			B_Mgr_v = GameObject.Find("Button_Mgr_v").GetComponent<Button_Mgr_v>();
			//text_v = GameObject.Find("Text_Mgr").GetComponent<Text_Mgr>();
		}
	}
}
