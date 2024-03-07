using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretBox : MonoBehaviour
{
    // 방 모델
    private RoomTemplates templates;

    // 파괴되었는지 체크
    public bool isCrash;

    // 추가되었는지 체크
    // 풀링에서 활성화할때 false로 바꿔서 활성화
    public bool isAdd;

    void Start()
    {
        // 방 모델
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    void Update()
    {
        // 애니메이션을 보여주기위해 2초뒤에 시크릿박스 반납
        if(isCrash)
        {
            Invoke("DeActive", 2f);
        }

        // 추가된 상태가 아닐때에만 리스트에 시크릿박스 추가
        if (!isAdd)
        {
            templates.secretBoxes.Add(this.gameObject);
            isAdd = true;
        }
    }

    void DeActive()
    {
        // 시크릿박스 반납
        gameObject.SetActive(false);
    }
}
