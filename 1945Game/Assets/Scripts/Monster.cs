using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 3f;
    public float delay = 1f;
    public Transform m1;
    public Transform m2;
    public GameObject bullet;

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

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    //void Update()
    //{
    //    //아래 방향으로 움직여라
    //    transform.Translate(Vector3.down * speed * Time.deltaTime);
    //}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
