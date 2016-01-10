using UnityEngine;
using System.Collections;

public class guard : MonoBehaviour//Made by Joni Silén
{
    public Transform player, thisguard;
    public float DistanceToPlayer;
    NavMeshAgent navComponent;

    void Start()
    {
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;//löytää pelaajan vaikkei olis kaan drag & dropattu inspectorissa
    }
    void Update()
    {
        if (cameras.guardsalerted==true)//jos kamerat nähneet --> tee
        {
            thisguard.GetComponent<Animator>().SetTrigger("is running");//muuta anim state
            DistanceToPlayer = Vector3.Distance(transform.position, player.position);//miten distance lasketaan
            if (DistanceToPlayer > 6)
            {
            navComponent.SetDestination(player.position);//laittaa nav meshin kulkemaan pelaajan luokse
            }
            else if (DistanceToPlayer < 6)
            {
                navComponent.velocity = Vector3.zero;
                navComponent.Stop();// stoppaa nav meshin liukumisen sen käynnistyksen jälkeen
                thisguard.GetComponent<Animator>().SetTrigger("is aiming");//muuta anim state
                Vector3 fwd = thisguard.TransformDirection(Vector3.forward);
                if (Physics.Raycast(transform.position, fwd, 7))
                {
                    StartCoroutine("waitasec");//tee coroutine odotus               
                }
            }//etkai vain varasta näitä opetusmateriaaliksesi? hyi sinua
        }
    }
    IEnumerator waitasec()
    {
        yield return new WaitForSeconds(0.6f);//odottaa 2 sekunttia
        Application.LoadLevel("fail state");//go to fail state sceneen/levelliin
    }
}