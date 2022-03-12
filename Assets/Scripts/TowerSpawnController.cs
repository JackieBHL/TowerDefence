using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawnController : MonoBehaviour
{
    GameController cont;

    SpriteRenderer rend;
    private void Awake()
    {
        cont = FindObjectOfType<GameController>();
        rend = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        if(cont.money >= cont.currentTowerCost)
        {
            cont.GiveMoney(-cont.currentTowerCost);

            Instantiate(cont.tower, transform.position, transform.rotation);
            gameObject.SetActive(false);

        }
        //Debug.Log("Spawn Tower");
        //Instantiate(cont.tower,transform.position,transform.rotation);
        //gameObject.SetActive(false);
    }
    private void OnMouseOver()
    {
        if (cont.money >= cont.currentTowerCost)
            rend.color = Color.green;
        else
            rend.color = Color.red;
    }
    private void OnMouseExit()
    {
            rend.color = Color.white;
    }
    //
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
