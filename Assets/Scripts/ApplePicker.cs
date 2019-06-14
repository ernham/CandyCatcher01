using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ApplePicker : MonoBehaviour
{
    //사과를 받아낼 바구니 오브젝트
    public GameObject basketPrefab;

    //오브젝트 생성 수량(3개가 1개의 바구니가 됨)
    public int numBaskets = 3;

    //생성될 바구니의 높이
    public float basketBottomY = -14f;

    //오브젝트와 오브젝트의 세로 간격
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;



    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
    for (int i=0; i<numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void AppleDestroyed()
    {
        //  사과를 놓쳤을 때 떨어지는 사과 모두 삭제
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach ( GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        //바구니 하나를 삭제함
        //basketList에서 마지막 바구니의 인덱스를 얻음
        int basketIndex = basketList.Count - 1;

        //해당 Basket 게임 오브젝트의 참조를 얻음
        GameObject tBasketGO = basketList[basketIndex];

        //리스트에서 해당 바구니를 제거하고 게임오브젝트를 삭제함
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        //게임을 HighScore에 영향을 주지 않고 재시작
        //바구니목록의 수를 세어 0일 경우 씬 새로 호출
        //using UnityEngine.SceneManagement;가 있어야 SceneManager사용 가능
        if (basketList.Count == 0)
        {
           SceneManager.LoadScene("_Scene_0");
        

            

        }
    }
}
