using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class controls : MonoBehaviour {
    void OnMouseDown() {
        SceneManager.LoadScene("Controls");
    }
}