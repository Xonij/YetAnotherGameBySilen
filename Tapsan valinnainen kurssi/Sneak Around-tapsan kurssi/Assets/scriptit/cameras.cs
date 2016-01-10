using UnityEngine;
using System.Collections;

public class cameras : MonoBehaviour//Made by Joni Silén
{
    public int direction;
    public Transform toberotated,player,startingpoint;
    public bool hasseenplayer,stopmoving,rotateright,audiostopper;
    public static bool guardsalerted;
    public AudioClip clip;

    void Start (){ guardsalerted = false; audiostopper = false; }//guards alerted pakko laittaa false (koska static), ettei jää päälle
    void Update()
    {
        if (hasseenplayer == false)
        {//mihin asti kamerat saa katsoa, sen mukaan mihin ilman suuntaan osottavat (as asteina),hardcoded
            if (direction == 1)//z
            {
                if (toberotated.eulerAngles.y < 60) { rotateright = true; }
                else if (toberotated.eulerAngles.y > 120) { rotateright = false; }
            }
            else if (direction == 2)//z minus
            {
                if (toberotated.eulerAngles.y < 200) { rotateright = true; }
                else if (toberotated.eulerAngles.y > 320) { rotateright = false; }
            }
            else if (direction == 3)//x
            {
                if (toberotated.eulerAngles.y < 140) { rotateright = true; }
                else if (toberotated.eulerAngles.y > 220) { rotateright = false; }
            }
            else if (direction == 4)//x minus LITTLE OFF, CANT GO UNDER 0
            {
                if (toberotated.eulerAngles.y < 2) { rotateright = true; }
                else if (toberotated.eulerAngles.y > 60) { rotateright = false; }
            }

            //kameroiden animointi aka katsoo edestakaisin
            if (rotateright == true && stopmoving ==false) { toberotated.Rotate(0, 0, 20 * Time.deltaTime); }
            else if (rotateright == false && stopmoving == false) { toberotated.Rotate(0, 0, -20 * Time.deltaTime); }
        }
        else if (hasseenplayer == true)//simple but works nicely
        {
            stopmoving = true;//pysäyttää kameran sivuttaisliikkumisen

            if (audiostopper == false)
            {
                AudioSource audio = GetComponent<AudioSource>();//äänitehosteita
                AudioSource.PlayClipAtPoint(clip, toberotated.position);
            }
            audiostopper = true;//varmuuden vuoksi ettei ääni spämmää
        }      
        //kameroiden näkö
        RaycastHit hit;
        Ray myray = new Ray(startingpoint.position, Vector3.forward);
        if (Physics.Raycast(myray, out hit, 10))
        {
            if (hit.collider.tag == "Player")//jos näkee pelaajan
            {
                hasseenplayer = true;
                guardsalerted = true;//alert command, jonka guard ai't näkee
            }
        }
        Debug.DrawRay(startingpoint.position, Vector3.forward);
    }//aijai jai, taas sitä ollaan nuuskimassa, häpeäisit.
}
