using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody targetRb;

    public int point;
    //参数
    public float minSpeed = 12;
    public float maxSpeed = 16;
    public float maxTorque = 10;

    public ParticleSystem explosionParticle;

    private GameManager gameManager;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        //Debug.Log(Vector3.up * Random.Range(minSpeed, maxSpeed));
        targetRb.AddForce(RandomSpeed(), ForceMode.Impulse);
        //添加选择
        targetRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);

        transform.position = RandomSpeedPosition();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (gameManager.gameStarts)
        {
            gameManager.UpdateScore(point);
        
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }
    }

    public void OnTriggerEnter(Collider other)
    {
            Destroy(gameObject);
        if (!gameObject.CompareTag("bed"))
        {
            gameManager.GameOver();
        }
    }


    Vector3 RandomSpeed()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    Vector3 RandomSpeedPosition()
    {
        return new Vector3(Random.Range(-4, 4), -2);
    }
}
