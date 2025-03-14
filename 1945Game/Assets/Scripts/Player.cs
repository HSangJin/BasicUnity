using UnityEngine;

public class Player : MonoBehaviour
{
    //스피드
    public float moveSpeed = 5f;
    Animator anim;
    //public Launcher launcher;
    public GameObject[] bullet; //총알 추후 4개 배열로 만들예정
    public Transform pos = null;
    public int bulletCount = 0;

    //아이템

    //레이저


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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet[bulletCount < bullet.Length ? bulletCount : bullet.Length - 1], pos.position, Quaternion.identity);
        }

        transform.Translate(new Vector3 (moveX, moveY, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            //if (launcher.count > 4)
            //    return;
            //launcher.count += 1;
            bulletCount += 1;
        }
    }
}
