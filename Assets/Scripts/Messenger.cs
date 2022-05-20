using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Messenger : MonoBehaviour {

	Sprite Back_ground;
	
	TextAsset csvFile;
	string line;

	int[] states = new int[16];
	string db = "";
	string player_name = "高専　太郎";
	string player_name_f = "高専　太郎";
	string player_age = "19";
	string player = "不明";
	string player_country = "日本";
	string job = "無職";
	string hobby = "特になし";
	string info_item = "アルミ缶、蜜柑";
	string info_intro = "父はシンボリルドルフ";

	List<string> skill_names = new List<string>();
	List<int> skill_points = new List<int>();
	List<int> skill_points_j = new List<int>();
	List<int> original_skill_points = new List<int>();
	List<int> OnOff = new List<int>();
	int skill_num = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	public bool  Decide_states(string n,string s,string a,string c){
		if(n =="" || s == "" || a == "" || c == ""){
			return false;
		}
		Dice_Mgr dice = GameObject.Find("Dice_Mgr").GetComponent<Dice_Mgr>();
		states = dice.all_state();
		db = dice.Get_db();
		player_name = n;
		player_name_f = player_name.Replace(" ","");
		player_name_f = player_name_f.Replace("　","");
		player_name_f = player_name_f.Replace(".","");
		player_name_f = player_name_f.Replace(",","");
		player = s;
		player_age = a;
		player_country = c;
		Read_Skill_Data();
		return true;
	}
	public bool	Decide_jobs(string j){
		Toggle_Mgr T_Mgr = GameObject.Find("Toggle_Mgr").GetComponent<Toggle_Mgr>();
		OnOff = T_Mgr.get_OnOff();
		job = j;
		if(j == ""){
			return false;
		}
		return T_Mgr.next_oK();
	}
	public bool Decide_job_points(){
		Button_Mgr_job B_Mgr_j = GameObject.Find("Button_Mgr_job").GetComponent<Button_Mgr_job>();
		if(B_Mgr_j.next_oK()){
			skill_points_j = B_Mgr_j.Get_skill_points();
			return true;
		}
		return false;
	}
	public bool Decide_hobby_points(string h){
		Button_Mgr B_Mgr = GameObject.Find("Button_Mgr").GetComponent<Button_Mgr>();
		if(h == ""){
			return false;
		}
		if(B_Mgr.next_oK()){
			hobby = h;
			skill_points = B_Mgr.Get_skill_points();
			return true;
		}
		return false;
	}

	public void Write_intro(string item,string intro){
		info_item = item;
		info_intro = intro;
	}

	void Read_Skill_Data(){
//		csvFile = Resources.Load("csv_files/skill") as TextAsset;//指定したファイルをTextAssetとして読み込み(ファイル名の.csvは不要なことに注意)　最初の行（タイトル部分）も読み込まれるのでそこは使用しない
//        StringReader reader = new StringReader(csvFile.text);//
		StreamReader reader = new StreamReader("input/skill.csv", System.Text.Encoding.GetEncoding("UTF-8"));
	    line = reader.ReadLine();
		while (reader.Peek() != -1){//最後まで読み込むと-1になる関数
            line = reader.ReadLine();//一行ずつ読み込み
			Set_Data(line.Split(','));
		}
		skill_num = skill_points.Count;
	}

	void Set_Data(string[] splited_line){
		skill_names.Add(splited_line[0]);
		if(splited_line[0] == "回避"){
			original_skill_points.Add(states[3]*2);
		}
		else if(splited_line[0] == "母国語"){
			original_skill_points.Add(states[7]*5);
		}else{
			original_skill_points.Add(int.Parse(splited_line[1]));
		}
		skill_points.Add(0);
		skill_points_j.Add(0);
	}

	public List<string> Get_s_n(){
		return skill_names;
	}
	public List<int> Get_s_p(){
		return skill_points;
	}
	public List<int> Get_o_s_p(){
		return original_skill_points;
	}
	public List<int> Get_s_p_j(){
		return skill_points_j;
	}
	public int Get_OnOff(int i){
		return OnOff[i];
	}
	public int SKILL_NUM(){
		return skill_num;
	}
	public string Get_job_name(){
		return job;
	}
	public int Get_job_point(){
		return states[14];
	}
	public int Get_hobby_point(){
		return states[15];
	}
	
	public void Save_data(){
		string file_name = player_name_f;
		StreamWriter sw = new StreamWriter("./output/"+file_name+".txt",false); // TextData.txtというファイルを新規で用意
        
		sw.WriteLine("名前\t"+player_name);
		sw.WriteLine("性別\t"+player);
		sw.WriteLine("年齢\t"+player_age);
		sw.WriteLine("出身\t"+player_country);

		sw.WriteLine("職業\t"+job);
		sw.WriteLine("趣味\t"+hobby);
		
		sw.WriteLine("STR\t"+states[0]);
		sw.WriteLine("CON\t"+states[1]);
		sw.WriteLine("POW\t"+states[2]);
		sw.WriteLine("DEX\t"+states[3]);
		sw.WriteLine("APP\t"+states[4]);
		sw.WriteLine("SIZ\t"+states[5]);
		sw.WriteLine("INT\t"+states[6]);
		sw.WriteLine("EDU\t"+states[7]);
		sw.WriteLine("SAN\t"+states[8]);
		sw.WriteLine("幸運\t"+states[9]);
		sw.WriteLine("アイデア\t"+states[10]);
		sw.WriteLine("知識\t"+states[11]);
		sw.WriteLine("ダメージボーナス\t"+db);
		sw.WriteLine("マジック・ポイント\t"+states[12]);
		sw.WriteLine("耐久力\t"+states[13]);
		sw.WriteLine("職業技能ポイント\t"+states[14]);
		sw.WriteLine("趣味技能ポイント\t"+states[15]);

		sw.WriteLine("職業技能");
		int p = 0;
		for(int i = 0;i < skill_num;i++){
			if(OnOff[i] == 1 && skill_points_j[i]>0){
				p = skill_points_j[i]+skill_points[i]+original_skill_points[i];
				sw.WriteLine(skill_names[i]+"\t"+p);
			}
		}
		sw.WriteLine("趣味技能");
		for(int i = 0;i < skill_num;i++){
			if(skill_points[i] != 0){
				p = skill_points_j[i]+skill_points[i]+original_skill_points[i];
				sw.WriteLine(skill_names[i]+"\t"+p);
			}
		}
		
		sw.WriteLine("現在のSAN\t"+states[8]+"/99");
		sw.WriteLine("現在のマジック・ポイント\t"+states[12]+"/"+states[12]);
		sw.WriteLine("現在の耐久力\t"+states[13]+"/"+states[13]);

		sw.WriteLine("持ち物など");
		sw.WriteLine(info_item);
		sw.WriteLine("紹介");
		sw.WriteLine(info_intro);
		sw.Flush();
        sw.Close();
	}

	public void Set_Back_ground(Sprite g){
		Back_ground = g;
	}
	public Sprite Get_Back_ground(){
		return Back_ground;
	}
	public bool Input_Nmae(string n){
		player_name_f = n;
		return true;
	}
	public string Get_player_name_f(){
		return player_name_f;
	}

}