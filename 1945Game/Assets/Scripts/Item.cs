using UnityEngine;

public class Item : MonoBehaviour
{
    //아이템 가속도
    public float itemVelocity = 20f;
    Rigidbody2D rig = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(itemVelocity, itemVelocity, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
