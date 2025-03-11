using UnityEngine;

public class Player_Control : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] BoxCollider2D collider;
    [SerializeField] Player_Anim anim;
    public bool isAttack { get; private set; } = false;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Vector2 posLimit;

    void Start()
    {
        anim.PlayAnim(Player_Anim.Player_PlayAnim.idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            collider.size = new Vector2(1.1f, 0.75f);
            isAttack = true;
            anim.PlayAnim(Player_Anim.Player_PlayAnim.attack);
        }
        else if(isAttack)
        {
            collider.size = Vector2.one * 0.5f;
            isAttack = false;
        }

        Vector3 pos = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        if (pos.x > 0 && posLimit.x <= transform.position.x)
            return;
        if (pos.x < 0 && -posLimit.x >= transform.position.x)
            return;
        if (pos.y > 0 && posLimit.y <= transform.position.y)
            return;
        if (pos.y < 0 && -posLimit.y+2f >= transform.position.y)
            return;
        transform.Translate(pos * moveSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (anim.isPadding)
                bullet.SetFlip(!bullet.GetFlip());
            else
            {
                Destroy(bullet.gameObject);
                health -= 1;
                if (health < 0) anim.PlayAnim(Player_Anim.Player_PlayAnim.death, () =>
                {

                });
                else
                    anim.PlayAnim(Player_Anim.Player_PlayAnim.hit);
            }
        }
    }
}
