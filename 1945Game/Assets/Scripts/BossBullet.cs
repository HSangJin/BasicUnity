using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 3f;
    Vector2 vec2 = Vector2.down;


    void Update()
    {
        transform.Translate(vec2 * speed * Time.deltaTime);
    }

    public void Move(Vector2 vec)
    {
        vec2 = vec;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //미사일 지움
            Destroy(gameObject);
        }
    }
}
