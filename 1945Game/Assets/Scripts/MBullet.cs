using UnityEngine;

public class MBullet : MonoBehaviour
{
    public float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //미사일 지우기
            Destroy(gameObject);
        }
    }
}
