using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1.3f;

    void Update()
    {
        //움직일 거리를 계산해 줍니다.
        float distanceY = moveSpeed * Time.deltaTime;
        //움직임을 반영합니다.
        transform.Translate(0, -distanceY, 0);

        if(transform.position.y < -5.1f)
            Destroy(gameObject);
    }

    ///// <summary> 화면 밖으로 나가 카메라에서 보이지 않으면 호출된다 </summary>
    //private void OnBecameVisible()
    //{
    //    Destroy(gameObject); //객체를 삭제한다.
    //}

    //private void OnDestroy()
    //{
    //    SoundManager.instance.SoundDie();
    //}
}
