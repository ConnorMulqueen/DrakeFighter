using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public Slider slider;

	void Update() {
        slider.value = Mathf.MoveTowards(slider.value, GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().getHealth(), 0.3f);
    }
}
