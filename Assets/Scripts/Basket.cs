using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Basket : MonoBehaviour
{
    
    //스코어 저장 변수
    public Text scoreGT;

   
    
   

    // Start is called before the first frame update
    void Start()
    {
      
        // ScoreCounter 게임오브젝트의 참조 서칭
        GameObject scoreGO = GameObject.Find("ScoreCounterText");
        
        //해당 게임오브젝트의 GUIText 컴포넌트를 얻음
        scoreGT = scoreGO.GetComponent<Text>();

        //시작 점수를 0으로 설정
        scoreGT.text = "0" ;


    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 현재 화면 위치를 얻음
        Vector3 mousePos2d = Input.mousePosition;

        // 카메라의 z위치만큼 3d 공간에서 마우스를 앞쪽으로 전진
        mousePos2d.z = -Camera.main.transform.position.z;

        // 2d 화면 공간의 지점을 3d 게임 세계 공간으로 변환
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2d);

        //마우스의 x 위치로 이 바구니의 x 위치를 설정
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
              

    }

    private void OnCollisionEnter(Collision coll)
    {
        // 무엇과 충돌했는지 확인
        GameObject collidedwith = coll.gameObject;
        if ( collidedwith.tag == "Apple")
        {
            Destroy(collidedwith);
        }

        // scoreGT의 텍스트를 int로 구문 분석
        int score = int.Parse(scoreGT.text);

        //사과를 받은 점수 추가
        score += 100;

        //점수를 다시 문자열로 바꾸고 표시
        scoreGT.text = score.ToString();

        //기록 점수 추적
        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
