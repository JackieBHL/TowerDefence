using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    // Start is called before the first frame update
    public float shootSpeed;
    public float rotationSpeed;
    public Transform target;
    public float attackRange;

    public Transform child;

    protected float cools;

    public GameObject bullet;
    public float cost;

    public GameObject[] bulletSpawnPositions;

    public GameObject flash;

    protected AudioSource src;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        GetComponent<CircleCollider2D>().radius = attackRange;
        cools = shootSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && target == null)
        {
            target = collision.transform;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && target == null)
        {
            target = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && target == collision.transform)
        {
            target = null;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //Debug.Log(target.gameObject);
            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
            if (cools >= 0)
            {
                cools -= Time.deltaTime;
            }
            else
            {
                Shoot();
            }
        }
    }
    public virtual void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        cools = shootSpeed;
    }
    private void LateUpdate()
    {
        child.transform.rotation = Quaternion.identity;
    }
}

