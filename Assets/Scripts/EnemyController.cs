using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D enemyRigidbody;
    public float speed;
    public float maxHealth;
    float health;

    Transform target;
    [SerializeField]
    int currentWayPoints;
    GameController cont;
    public float rotationSpeed;
    
    float distance;

    bool canMove = true;
    public float damage;

    public float dropMoney;

    public GameObject explosion;
    void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        cont = FindObjectOfType<GameController>();
        canMove = true;
    }
    private void OnEnable()
    {
        health = maxHealth;
        currentWayPoints = 0;
        target = cont.wayPoints[currentWayPoints];
    }
    public void TakeDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            cont.GiveMoney(dropMoney);
            Instantiate(explosion,transform.position,Quaternion.identity);
            gameObject.SetActive(false);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg - 90;


        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.AngleAxis(angle,Vector3.forward),Time.deltaTime*rotationSpeed);
        if(canMove)
            enemyRigidbody.AddForce(transform.up * speed * Time.deltaTime);
        distance = Vector2.Distance(transform.position, target.position);
        if(distance <= 0.5f)
        {
            canMove = false;
            Invoke("CanMove", 1.5f);

            if(currentWayPoints < cont.wayPoints.Length-1){
                
                    currentWayPoints++;
                    target = cont.wayPoints[currentWayPoints];
                }
            else
            {
                cont.TakeDamage(damage);
                gameObject.SetActive(false);
            }


        }
        


    }
    
    void CanMove(){
        canMove = true;

    }
     
}
