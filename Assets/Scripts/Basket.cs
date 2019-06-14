using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Basket : MonoBehaviour
{
    
    //스코어 저장 변수
    public Text scoreGT;

    //획득한 오브젝트에 따라 스코어 개별 정의
    //추후 csv에서 스코어값을 가져와 정의할 수 있도록 한다.
    public int appleScore = 100;
    public int candyScore = 500;
   
    
   

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
        // scoreGT의 텍스트를 int로 구문 분석
        int score = int.Parse(scoreGT.text);

        // 무엇과 충돌했는지 확인
        GameObject collidedwith = coll.gameObject;
        if ( collidedwith.tag == "Apple")
        {
            //앞서 정의한 사과 획득스코어를 기존 스코어에 추가함
            score += appleScore;
            
        }
        else if (collidedwith.tag == "Candy")
        {
            //앞서 정의한 캔디 획득스코어를 기존 스코어에 추가함
            score += candyScore;

        
        }
        
        //충돌한 오브젝트 즉시 사라짐
        Destroy(collidedwith);


        //점수를 다시 문자열로 바꾸고 표시
        scoreGT.text = score.ToString();

        //기록 점수 추적
        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
