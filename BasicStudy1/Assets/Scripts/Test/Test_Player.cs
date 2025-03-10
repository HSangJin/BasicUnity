using UnityEngine;
using UnityEngine.UI;

public class Test_Player : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Collider c;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (transform.position.x <= -5f && pos.x < 0f)
            return;
        if (transform.position.x >= 5f && pos.x > 0f)
            return;
        transform.Translate(pos * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Mob"))
        {
            enabled = false;
            text.gameObject.SetActive(true);
        }
    }
}
