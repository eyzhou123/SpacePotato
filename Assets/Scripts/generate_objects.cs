using UnityEngine;
using System.Collections;

public class generate_objects : MonoBehaviour {

	public int max_fuel = 5;
	private int num_game_objects;
	private float min_x = 0.0f;
	private float max_x = 5.0f;
	private float min_y = -3.8f;
	private float max_y = 3.8f;
	
	// probability of getting: [bird, lightning, nothing]
	private string[] objects = new string[] {"Fuel", ""};
	private string[] object_tags = new string[]{"fuel", ""};
	private float[] probs = new float[] {0.5f, 99.5f};
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int index = chooseObject (probs);
		Debug.Log (objects[index]);
		createObject (objects[index], object_tags[index]);
		
		num_game_objects = GameObject.FindGameObjectsWithTag("fuel").Length;
		//		Debug.Log (num_game_objects);
		
		if (num_game_objects < 2) {
			createObject ("Fuel", "fuel");
		}
	}
	
	int chooseObject (float[] probs) {
		float total = 0;
		
		foreach (float elem in probs) {
			total += elem;
		}
		
		float randomPoint = Random.value * total;
		
		for (int i= 0; i < probs.Length; i++) {
			if (randomPoint < probs[i]) {
				return i;
			} else {
				randomPoint -= probs[i];
			}
		}
		return probs.Length - 1;
	}
	
	
	public void createObject(string name, string tag) {
		if (name == "") {
			return;
		}
		GameObject newObject = GameObject.Instantiate(Resources.Load(name)) as GameObject;
		Vector3 generated_pos = new Vector3 (Random.Range(min_x, max_x), Random.Range(min_y, max_y), 0);
		newObject.gameObject.tag = tag;
		newObject.name = name;
		if (name == "Fuel") {
			newObject.gameObject.transform.position = generated_pos;
			//		} else if (name == "Bird") {
			//			Vector3 generated_bird_pos = new Vector3 (4.7f, Random.Range(-3.8f, 7.5f), 0);
			//			newObject.gameObject.transform.position = generated_bird_pos;
			//		} else if (name == "Bolt") {
			//			Vector3 generated_bolt_pos = new Vector3 (Random.Range(min_x, max_x), Random.Range(-min_y, 7.5f), 0);
			//			newObject.gameObject.transform.position = generated_bolt_pos;
			//		}
		}
	}
}