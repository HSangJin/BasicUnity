using UnityEngine;

public class MoveWithGravity : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 5.0f; //점프힘
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 move = new Vector3(Input.GetAxis("Horizental"), 0, Input.GetAxis("Vertical"));
        //Space 키를 누르면 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Rgidbody : 물리효과를 추가해 중력을 적용합니다.
            //AddForce : 점프를 위해 오브젝트에 힘을 줍니다.
            //ForceMode.Impulse : 순간적으로 힘을 가하는 옵션
            //move.z = jumpForce;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
