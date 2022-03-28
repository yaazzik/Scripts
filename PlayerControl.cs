using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject laserPrefabs;
    public float fireRate = 0.3f;
    public float nextFire;
    private int PlayerLifes = 5;

    [SerializeField]
    private int Speed = 6;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        SpaceMovement();

        if (Input.GetMouseButton(0)){
            if(Time.time > nextFire){
                Instantiate(laserPrefabs, transform.position + new Vector3(0, 0.877f, 0), Quaternion.identity);
                nextFire = Time.time + fireRate;            
            }
        }
    }
        private void SpaceMovement()
        {

            float HorizonInput = Input.GetAxis("Horizontal");
            float VertInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.right * Time.deltaTime * Speed * HorizonInput);
            transform.Translate(Vector3.up * Time.deltaTime * Speed * VertInput);

            if (transform.position.y > 4)
            {
                transform.position = new Vector3(transform.position.x, 4, 0);
            }
            else if (transform.position.y < -4.07f)
            {
                transform.position = new Vector3(transform.position.x, -4.07f, 0);
            }

            if (transform.position.x > 9.7f)
            {
                transform.position = new Vector3(-9.7f, transform.position.y, 0);
            }
            else if (transform.position.x < -9.7f)
            {
                transform.position = new Vector3(9.7f, transform.position.y, 0);
            }
        }
    public void LifeSubstraction()
    {
        PlayerLifes--;

        if (PlayerLifes < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
