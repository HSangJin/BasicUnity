using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        if(transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }
}
