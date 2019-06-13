using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    //하이스코어를 저장할 변수 세팅
    public static int score = 1000;

    void Awake()
        //
    {
        
    }

    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score:" + score;

        // 조건 체크 후 하이스코어 업데이트

       if(score > PlayerPrefs.GetInt("ApplePickerHighScore"))
        {
            PlayerPrefs.SetInt("ApplePickerHighScore", score);
        }
    }
}
