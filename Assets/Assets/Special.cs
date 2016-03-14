using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Special : MonoBehaviour {
    public Slider slider;

    void Update() {
        slider.value = Mathf.MoveTowards(slider.value, GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().getSpecial(), 0.26f);
    }
}
