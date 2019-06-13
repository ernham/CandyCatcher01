using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //로딩 슬라이드 바 변수
    public Slider slider;

    //로딩완료 여부
    bool IsDone = false;

    float fTime = 0f;
    AsyncOperation async_operation;


    
    void Start()
    {
        StartCoroutine(StartLoad("_Scene_0"));    
    }

    
    void Update()
    {
        fTime += Time.deltaTime;
        slider.value = fTime;

        if (fTime >= 5)
        {
            async_operation.allowSceneActivation = true;
        }
    }

    public IEnumerator StartLoad(string strSceneName)
    {
        async_operation = SceneManager.LoadSceneAsync(strSceneName);
        async_operation.allowSceneActivation = false;

        if (IsDone == false)
        {
            IsDone = true;

            while (async_operation.progress < 0.9f)
            {
                slider.value = async_operation.progress;

                yield return true;
            }
        }

            
    }

}
