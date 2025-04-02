using UnityEngine;

public class Player : MonoBehaviour
{

    private int _health = 100;
    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            EventManager.Instance.TriggerEvent("PlayerHealthChanged", _health);
            if (_health <= 0)
            {
                EventManager.Instance.TriggerEvent("PlayerDied");
            }
        }
    }

    void TakeDamage(int damage)
    {
        Health -= damage;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }
}
