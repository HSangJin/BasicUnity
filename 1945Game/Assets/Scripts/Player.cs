using UnityEngine;

public class Player : MonoBehaviour
{
    //스피드
    public float moveSpeed = 5f;
    Animator anim;
    public Launcher launcher;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //방향키에 따른 움직임
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        if(moveX > 0f && transform.position.x >= 3f)
            moveX = 0f;
        if(moveX < 0f && transform.position.x <= -3f)
            moveX = 0f;
        
        anim.SetBool("left", Input.GetAxis("Horizontal") <= -0.5f);
        anim.SetBool("right", Input.GetAxis("Horizontal") >= 0.5f);

        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        if(moveY > 0f && transform.position.y >= 6f)
            moveY = 0f;
        if(moveY < 0f && transform.position.y <= -4f)
            moveY = 0f;

        anim.SetBool("up", moveX == 0f && Input.GetAxis("Vertical") >= 0.5f);

        transform.Translate(new Vector3 (moveX, moveY, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Destroy(collision.gameObject);
            if (launcher.count > 4)
                return;
            launcher.count += 1;
        }
    }
}
