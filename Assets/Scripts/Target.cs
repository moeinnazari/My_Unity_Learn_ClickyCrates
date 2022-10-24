using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
   
    public float minSpeed=10f;
    public float maxSpeed=16f;
    public float maxTorque=10f;
    public float xRange=3f;
    public float posY=-2f;
    private Rigidbody PlayerRB;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explusion;
    // Start is called before the first frame update
    void Start()
    {
        
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        PlayerRB=GetComponent<Rigidbody>();
        PlayerRB.AddForce(RandomForce(),ForceMode.Impulse);
        PlayerRB.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);

        transform.position=RandomPos();
    }



    Vector3 RandomForce()
    {
        return  Vector3.up*Random.Range(minSpeed,maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque,maxTorque);
    }

    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xRange,xRange),posY,0);
    }

    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
         Destroy(gameObject);
         Instantiate(explusion,transform.position,transform.rotation);
         gameManager.UpdateScore(pointValue);    
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if(other.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }





    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-15)
        {
            Destroy(gameObject);
        }
    }
}
