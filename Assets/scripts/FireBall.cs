using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float Speed;
    public float lifetime;
    public float damage = 10;
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DestroyFireBall", lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveFixedUdpate();
    }

    private void MoveFixedUdpate ()

    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var EnemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (EnemyHealth != null)
        {

            EnemyHealth.value -= damage;
            if (EnemyHealth.value <=0)
            {
                Destroy(EnemyHealth.gameObject);
            }    
        }
        DestroyFireBall();
    }
        private void DestroyFireBall()
        {
            Destroy(gameObject);

        }
    
}
