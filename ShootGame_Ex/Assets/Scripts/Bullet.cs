using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] SpriteRenderer renderer;
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        //오른쪽으로 이동
        float _direction = renderer.flipY ? -1f : 1f;
        transform.Translate(new Vector3(0, _direction * moveSpeed * Time.deltaTime, 0));
        if(transform.position.x <= -10f || transform.position.x >= 15f)
            Destroy(gameObject);
        
    }

    public void SetFlip(bool setFlip) { renderer.flipY = setFlip; }
    public bool GetFlip() { return renderer.flipY; }
}
