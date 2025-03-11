using UnityEngine;

public class Player : MonoBehaviour
{
    //움직이는 속도 정의
    public float moveSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        MoveControl();
    }

    void MoveControl()
    {
        //지정한 Axis를 통해 키의 방향을 판단하고 속도와 프레임 판정을 곱해 이동량을 정한다.
        float distaceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        if (transform.position.x >= 2.5f && distaceX > 0f)
            return;
        if (transform.position.x <= -2.5f && distaceX < 0f)
            return;
        //이동량 만큼 실제로 이동을 해주는 함수
        transform.Translate(distaceX, 0, 0);
    }
}
