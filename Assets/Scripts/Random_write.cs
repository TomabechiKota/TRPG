using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Random_write : MonoBehaviour {
	
    [SerializeField]
	InputField inputField_name;
    [SerializeField]
	InputField inputField;
    [SerializeField]
	InputField inputField_age;
    [SerializeField]
	InputField inputField_country;
	Audio_Source audio_source;

	string line;
	List<string> names_f = new List<string>();
	List<string> names_p = new List<string>();
	List<string> countrys = new List<string>();

	// Use this for initialization
	void Start () {
		Read_Skill_Data();
		audio_source = GameObject.Find("Audio Source").GetComponent<Audio_Source>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void rand_name(){
		audio_source.Write_name();
		inputField_name.text = names_f[UnityEngine.Random.Range(0,names_f.Count)] +"　"+ names_p[UnityEngine.Random.Range(0,names_p.Count)];
	} 
	public void rand(){
		audio_source.Write_other();
		int r = UnityEngine.Random.Range(0,100);
		if(r < 33){
			inputField.text = "男";
		}else if(r < 66){
			inputField.text = "女";
		}else if(r < 99){
			inputField.text = "不明";
		}else{
			inputField.text = "憶えていない";
		}
	} 
	public void rand_age(){
		audio_source.Write_other();
		inputField_age.text = ""+UnityEngine.Random.Range(15,120);
	} 
	public void rand_country(){
		audio_source.Write_other();
		if(UnityEngine.Random.Range(0,100) < 30){
			inputField_country.text = countrys[UnityEngine.Random.Range(0,countrys.Count)];
		}else{
			inputField_country.text = countrys[UnityEngine.Random.Range(193,countrys.Count)];
		}
	} 

	void Read_Skill_Data(){
		StreamReader reader = new StreamReader("input/name_list_f.csv", System.Text.Encoding.GetEncoding("UTF-8"));
		while (reader.Peek() != -1){//最後まで読み込むと-1になる関数
            names_f.Add(reader.ReadLine());
		}
		reader = new StreamReader("input/name_list_p.csv", System.Text.Encoding.GetEncoding("UTF-8"));
		while (reader.Peek() != -1){//最後まで読み込むと-1になる関数
            names_p.Add(reader.ReadLine());
		}
		reader = new StreamReader("input/country_list.csv", System.Text.Encoding.GetEncoding("UTF-8"));
		while (reader.Peek() != -1){//最後まで読み込むと-1になる関数
            countrys.Add(reader.ReadLine());
		}
	}

}
