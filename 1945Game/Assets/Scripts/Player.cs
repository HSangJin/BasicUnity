using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //스피드
    public float moveSpeed = 5f;
    Animator anim;
    //public Launcher launcher;
    public GameObject[] bullet; //총알 추후 4개 배열로 만들예정
    public Transform pos = null;

    //아이템
    public int bulletCount = 0;
    [SerializeField] GameObject powerup; //private 인스펙터에서 사용하는 방법

    //레이저
    public GameObject lazer;
    public float gValue = 0f;

    public Image gauge;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet[bulletCount < bullet.Length ? bulletCount : bullet.Length - 1], pos.position, Quaternion.identity);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            gValue += Time.deltaTime;
            if(gValue >= 1f)
            {
                GameObject go = Instantiate(lazer, pos.position, Quaternion.identity);
                Destroy(go, 3f);
                gValue = 0f;
            }
            gauge.fillAmount = gValue;
        }
        else
        {
            gValue -= Time.deltaTime;
            if(gValue <= 0f)
                gValue = 0f;
            gauge.fillAmount = gValue;
        }

        transform.Translate(new Vector3(moveX, moveY, 0));

        //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드좌표로 변환
        transform.position = worldPos; //좌표를 적용한다.
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

            GameObject go = Instantiate(powerup, pos.position, Quaternion.identity);
            Destroy(go, 1f);
        }
    }
}
