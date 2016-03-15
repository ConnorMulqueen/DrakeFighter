using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour {

    void OnMouseDown() {
        SceneManager.LoadScene("Menu");
    }
}
