using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    //가장 처음 스타트씬을 호출하는 함수
    public void LoadStartScene()
    {
        SceneManager.LoadScene("_Scene_Start");
    }

    //스타트씬에서 게임씬을 호출하는 함수
    //스타트 버튼의 On click 이벤트에 함수를 넣어 사용
    public void LoadGameScene()
    {
        SceneManager.LoadScene("_Scene_0");
    }

    //로딩씬을 호출하는 함수
    public void LoadLodingScene()
    {
        SceneManager.LoadScene("_Scene_Loding");
    }
}
