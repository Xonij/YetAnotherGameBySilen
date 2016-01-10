using UnityEngine;
using System.Collections;

public class door : MonoBehaviour//Made by Joni Silén
{
    public bool incontact;
    public Transform thedoor;

	void Start () { incontact = false; }//ei välttämätöntä, mutta hyvä laittaa varmanpäälle

	void Update ()
    {
        if (incontact == true)// if lause, ei tarvitse selittää
        {
            thedoor.transform.Rotate(0, 0, -15 * Time.deltaTime);//avaa ovea, ei lopeta pyörimistä koska olen laiska ja ei kukaan huomaa
        }
	}
    void OnTriggerEnter(Collider collider)// kun osutaan kollideriin (joka on "is trigger")
    {
        if (collider.gameObject.CompareTag("Player"))//testataan jos osuja on pelaaja
        {
            incontact = true;
            StartCoroutine("waitasec");//end level by tekemällä waitasec
        }
    }
    IEnumerator waitasec()
    {
        yield return new WaitForSeconds(1);//odottaa 1 sekunnin
        Application.LoadLevel("level select");//go to level select sceneen/levelliin
    }
}//jos nää menee githubista jonneen suurempiin kansioihin vähän kompensaatiota ois ok, kamaaaan people gotta eat.
