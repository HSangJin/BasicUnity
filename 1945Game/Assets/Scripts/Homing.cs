using UnityEngine;

public class Homing : MonoBehaviour
{
    public GameObject target; //플레이어
    public float speed = 3f;
    Vector2 dir;
    Vector2 dirNo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        // A - B    A바라보는 벡터    플레이어 - 미사일
        dir = target.transform.position - transform.position;
        //방향벡터만 구하기 단위 벡터 정규화 노말 1의 크기로 만든다.
        dirNo = dir.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dirNo * speed * Time.deltaTime);

        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
