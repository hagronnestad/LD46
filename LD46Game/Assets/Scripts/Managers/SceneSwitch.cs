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
    int sceneId;
    void Awake() {

        sceneId = SceneManager.GetActiveScene().buildIndex;
        controls = new Controls();
        controls.UIActions.Enter.performed += ctx => StartCoroutine(Fade());
    }
    IEnumerator Fade() {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => blackSquare.color.a >= 1);
        SceneManager.LoadScene(sceneId + 1);
    }
    private void OnEnable() {
        controls.Enable();
    }
    private void OnDisable() {
        controls.Disable();
    }
}
