using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public GameObject player;
    public GameEnding gameEnding;

    bool IsPlayerInRange;
    
    
    // Update is called once per frame
    void Update()
    {
        if (IsPlayerInRange)
        {
            Vector3 direction = player.transform.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.gameObject == player)
                {
                    //게임 오버
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            IsPlayerInRange = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
      if(other.gameObject == player)
        {
            IsPlayerInRange = false;
        }
    }









}

/*// Start is called before the first frame update
void Start()
{

}

*/

