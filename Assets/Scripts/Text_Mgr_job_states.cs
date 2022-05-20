using UnityEngine;
using UnityEngine.UI;

public class Text_Mgr_job_states : MonoBehaviour {
    [SerializeField]
	Text skill_name;
    [SerializeField]
	Text point;
    [SerializeField]
	Text rest;
    [SerializeField]
	Text job_name;
    [SerializeField]
	GameObject B_Mgr;
	Button_Mgr_job button;
	bool first = true;
	bool renew = true;
	// Use this for initialization
	void Start () {
		button = B_Mgr.GetComponent<Button_Mgr_job>();
	}
	
	// Update is called once per frame
	void Update () {
		if(first){
			draw_name();
			first = false;
		}
		if(renew){
			draw_point();
			renew = false;
		}
	}

	void draw_name(){
		skill_name.text = "\n";
		for(int i = 0;i<button.Get_count();i++){
			skill_name.text = skill_name.text+button.Get_skill_name(i)+"\n";
		}
		job_name.text = "職業   "+button.Get_job_name();
	}
	void draw_point(){
		point.text = "\n";
		for(int i = 0;i<button.Get_count();i++){
			point.text = point.text+button.Get_skill_point(i)+"\n";
		}
		rest.text = "残り:"+button.Get_j_point()+"pt";
	}
	public void click(){
		renew = true;
	}
}
