using UnityEngine;
using System.Collections;

public class buttons : MonoBehaviour//Made by Joni Silén
{
	void Start ()
    {
        UnityEngine.Cursor.visible = true;//tee kursor näkyväksi
    }
	void Update ()
    {
        if (Cursor.visible == false) { UnityEngine.Cursor.visible = true; }//varmista, että hiiri näkyy
    }
    public void levelselect() { Application.LoadLevel("level select"); }//buttons and what they do
    public void exit() { Application.Quit(); }
    public void l1() { Application.LoadLevel("level1"); }
    public void l2() { Application.LoadLevel("level2"); }
    public void l3() { Application.LoadLevel("level3"); }
    public void back() { Application.LoadLevel("title screen"); }// pitikö nää selitää, o god, että tää on tylsää..
}
