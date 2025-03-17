using UnityEngine;

public class Monster : MonoBehaviour
{
    public int hp = 100;
    public float speed = 3f;
    public float delay = 1f;
    public Transform m1;
    public Transform m2;
    public GameObject bullet;
    public GameObject item;

    void Start()
    {
        //한번 함수 호출
        Invoke("CreateBullet", delay);
    }

    void CreateBullet()
    {
        Instantiate(bullet, m1.position, Quaternion.identity);
        Instantiate(bullet, m2.position, Quaternion.identity);

        Invoke("CreateBullet", delay);
    }

    //private void FixedUpdate()
    //{
    //    transform.Translate(Vector3.down * speed * Time.deltaTime);
    //}
    void Update()
    {
        //아래 방향으로 움직여라
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    //미사일에 따른 데미지 입는 함수
    public void Damage(int attack)
    {
        hp -= attack;
        if (hp < 0)
        {
            ItemDrop();
            Destroy(gameObject);
        }
    }

    public void ItemDrop()
    {
        //아이템 생성
        Instantiate(item, transform.position, Quaternion.identity);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
