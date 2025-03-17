using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float speed = 4.0f;
    //공격력
    public int attack = 10;
    //이펙트
    public GameObject effect;


    void Update()
    {
        //미사일 위쪽 방향으로 움직이기
        //위의 방향 * 스피드 * 타임
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    //화면밖으로 나갈경우
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            //이펙트 생성
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);
            //1초뒤에 지우기
            Destroy(go, 1f);

            ////아이템 생성
            //Spawn.instance.SpawnItem(collision.transform.position);
            //몬스터
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<Monster>().Damage(attack);

            //미사일 삭제
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Boss"))
        {
            //이펙트 생성
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);
            //1초뒤에 지우기
            Destroy(go, 1f);

            //미사일 삭제
            Destroy(gameObject);
        }
    }
}
