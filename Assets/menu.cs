using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

    void OnMouseDown() {
        SceneManager.LoadScene("Game");
    }
}
