using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    Controls controls;
    public Image blackSquare;
    public Animator anim;
    GameObject introMusic;
    int sceneId;
    void Awake() {

        sceneId = SceneManager.GetActiveScene().buildIndex;
        controls = new Controls();
        controls.UIActions.Enter.performed += ctx => StartCoroutine(Fade());
        controls.UIActions.Escape.performed += ctx => ExitGame();
        introMusic = GameObject.FindGameObjectWithTag("IntroMusic");
        if (sceneId == 3) {
            Destroy(introMusic);
        }
    }
    IEnumerator Fade() {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => blackSquare.color.a >= 1);
        if (sceneId < 5) {
            SceneManager.LoadScene(sceneId + 1);
        }
        if(sceneId == 4) {
            SceneManager.LoadScene(0);
        }
    }

    void ExitGame() {
        if(sceneId == 4) {
            Application.Quit();
        }
    }
    void OnTriggerEnter2D(Collider2D collision) {
        SceneManager.LoadScene(4);
    }
    private void OnEnable() {
        controls.Enable();
    }
    private void OnDisable() {
        controls.Disable();
    }
}
