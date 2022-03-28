using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    public int Speed = 7;
    [SerializeField]
    private GameObject enemyExplosionPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);

        if (transform.position.y < -6.2)
        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 6.2f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Laser")
        {
            Destroy(this.gameObject);
            Instantiate(enemyExplosionPrefab, transform.position, Quaterion.identity);
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Player")
        {
            PlayerControl playerControl = collision.GetComponent<PlayerControl>();

            if (playerControl != null)
            {
                playerControl.LifeSubstraction();
            }

            Instantiate(enemyExplosionPrefab, transform.position, Quaterion.identity);
            Destroy(this.gameObject);
        }
    }
}


