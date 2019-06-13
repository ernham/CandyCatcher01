using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    // 사과가 삭제되는 범위값
    public static float bottomY = -20f;
    
    // X축이 범위를 벗어 났을 때 사라지게 하니 어색함
    // 좌/우 벽을 만들어 사과가 닿았을 때 튕겨지도록 수정 예정
    //public static float bottomX = 9f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //범위값과 현재 위치를 비교해서 삭제 여부 판단
        // 
        //if (transform.position.y < bottomY || transform.position.x < -bottomX || transform.position.x > bottomX)
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            // 메인 카메라의 ApplePicker 컴포넌트에 대한 참조 얻기

            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            // apScript의 공용 AppleDestroyed() 메서드를 호출
            apScript.AppleDestroyed();
        }
        
    }
}
