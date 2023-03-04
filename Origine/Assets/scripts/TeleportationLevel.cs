using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportationLevel : MonoBehaviour {

    public int indexLevel;
    public Animator levelAnim;

    void OnCollisionEnter2D(Collision2D other)
    {
        levelAnim.SetTrigger("FadeOut");
        DialogManager.isTalking = false;
        SceneManager.LoadScene(indexLevel);
    }

}