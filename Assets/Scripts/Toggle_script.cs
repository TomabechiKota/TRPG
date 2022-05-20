using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle_script : MonoBehaviour {
	Toggle_Mgr T_Mgr;
	Text_Mgr_job T_Mgr_j;
	int num = 0;
	// Use this for initialization
	void Start () {
		T_Mgr = GameObject.Find("Toggle_Mgr").GetComponent<Toggle_Mgr>();
		T_Mgr_j = GameObject.Find("Text_Mgr").GetComponent<Text_Mgr_job>();
	}
	
	public void isChange(){
		T_Mgr.change(num);
		T_Mgr_j.draw_selected();
	}

	public void set_num(int n){
		num = n;
	}
}
