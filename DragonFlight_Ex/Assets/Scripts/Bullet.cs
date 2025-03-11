using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;
    public GameObject exposion;

    void Update()
    {
        //Y축 이동
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);

        if(transform.position.y > 7f)
            Destroy(gameObject);
        
    }

    //private void OnBecameVisible()
    //{
    //    //미사일이 화면밖으로 나갔으면 미사일 지우자
    //    Destroy(gameObject);
    //}

    //2D충돌 트리거이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //미사일과 적이 부딫혔다
        if(collision.gameObject.tag == "Enemy")
        {
            //폭발 이펙트 생성
            Instantiate(exposion, transform.position, Quaternion.identity);
            //죽음 사운드
            SoundManager.instance.SoundDie();
            //적 지우기
            Destroy(collision.gameObject);
            GamaManager.Instance.AddScore(10);
            //총알 지우기 자기자신
            Destroy(gameObject);
        }
    }
}
