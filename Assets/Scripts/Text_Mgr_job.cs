using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Mgr_job : MonoBehaviour {
	
	[SerializeField]
	Text skill_name;
    [SerializeField]
	Text point;
    [SerializeField]
	Text selected;
    [SerializeField]
	Toggle_Mgr T_Mgr;
	Messenger messenger;
	
	// Use this for initialization
	void Start () {
		messenger =  GameObject.Find("Messenger").GetComponent<Messenger>();
		draw_name();
		draw_point();
		draw_selected();
	}

	void Update(){

	}

	public void draw_selected(){
		selected.text = T_Mgr.Get_OnCount() + "個選択中";
	}

	void draw_name(){
		List<string> names  = messenger.Get_s_n();
		skill_name.text = "";
		for(int i = 0;i<messenger.SKILL_NUM();i++){
			skill_name.text = skill_name.text+names[i]+"\n";
		}

	}
	void draw_point(){
		List<int> points  = messenger.Get_o_s_p();
		point.text = "";
		for(int i = 0;i<messenger.SKILL_NUM();i++){
			point.text = point.text+points[i]+"\n";
		}

	}
}
