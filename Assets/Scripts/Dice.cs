using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {
    [SerializeField]
    Sprite ONE;
    [SerializeField]
    Sprite TWO;
    [SerializeField]
    Sprite THREE;
    [SerializeField]
    Sprite FOUR;
    [SerializeField]
    Sprite FIVE;
    [SerializeField]
    Sprite SIX;
    [SerializeField]
	Image image;
	
	public void Set_num(int i){
		switch(i){
			case 1:
			image.sprite=ONE;
			break;
			case 2:
			image.sprite=TWO;
			break;
			case 3:
			image.sprite=THREE;
			break;
			case 4:
			image.sprite=FOUR;
			break;
			case 5:
			image.sprite=FIVE;
			break;
			case 6:
			image.sprite=SIX;
			break;
		}
	}

}
