using UnityEngine;
using UnityEngine.UI;

public class Text_Mgr_state : MonoBehaviour {
    [SerializeField]
	Text state_point;
    [SerializeField]
	Text other_point;
    [SerializeField]
	GameObject D_Mgr;
	Dice_Mgr Dice;
	Audio_Source audio_source;
	bool renew = true;
	// Use this for initialization
	void Start () {
		Dice = D_Mgr.GetComponent<Dice_Mgr>();
		audio_source = GameObject.Find("Audio Source").GetComponent<Audio_Source>();
	}
	
	// Update is called once per frame
	void Update () {
		if(renew){
			draw_point();
			renew = false;
		}
	}
	
	void draw_point(){
		state_point.text = Dice.state();
		other_point.text = Dice.other();
	}
	public void click(){
		audio_source.Roll();
		renew = true;
	}
}
