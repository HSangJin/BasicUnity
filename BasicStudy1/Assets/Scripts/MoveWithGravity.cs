using UnityEngine;

public class MoveWithGravity : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 5.0f; //������
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 move = new Vector3(Input.GetAxis("Horizental"), 0, Input.GetAxis("Vertical"));
        //Space Ű�� ������ ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Rgidbody : ����ȿ���� �߰��� �߷��� �����մϴ�.
            //AddForce : ������ ���� ������Ʈ�� ���� �ݴϴ�.
            //ForceMode.Impulse : ���������� ���� ���ϴ� �ɼ�
            //move.z = jumpForce;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
