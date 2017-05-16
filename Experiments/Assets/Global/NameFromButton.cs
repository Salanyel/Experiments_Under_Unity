using UnityEngine;
using UnityEngine.UI;

public class NameFromButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text>().text = transform.parent.name;
	}
}
