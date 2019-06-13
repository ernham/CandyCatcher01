using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // 스타트 함수 밖에 변수 선언
    //Apple 인스턴스화
    public GameObject applePrefab;
    public GameObject candyPrefab;
    public float candyDropRate = 0.2f;
    // 사과나무가 움직이는 속도(미터/초)
    // 사과나무는 사과를 드롭하는 주체로 자동으로 움직임
    public float speed = 10f;

    // 사과나무가 움직일 수 있는 좌우 거리
    public float leftAndRightEdge = 5f;

    // 사과나무가 방향을 바꾸는 확률
    // 사과나부는 일정확률로 방향을 바꿈
    public float chanceChangeDirections = 0.2f;

    // 사과가 인스턴스화되는 속도(생성속도)
    public float secondsBetweenAppleDrops = 1f;

    
    
    void Start()
    {
        //사과를 1초에 하나씩 드롭(시간 수정가능)
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }
    void DropApple()
        {
        float dropSelect = Random.value;
        Debug.Log(dropSelect+"이면 뭐지?");
                

        if (dropSelect <= candyDropRate)
        {
        GameObject candy = Instantiate(candyPrefab) as GameObject;
        candy.transform.position = transform.position;
        Debug.Log("캔디가 떨어지네요");

        } else if(dropSelect > candyDropRate)
        {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
        Debug.Log("이번엔 사과네요.");
        }

        
    }
    
    void Update()
    {
        // 사용자의 이동여부 체크
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // 사과의 방향 바꾸기 체크
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //오른쪽 이동
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //왼쪽 이동
        } 
    }

    private void FixedUpdate()
    {
        //임의로 방향 바꾸기
        if (Random.value < chanceChangeDirections)
        {
            speed *= -1; // 방향 바꾸기
        }
    }
}
