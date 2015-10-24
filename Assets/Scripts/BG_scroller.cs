using UnityEngine;
using System.Collections;

public class BG_scroller : MonoBehaviour {

	public float scroll_speed;
	public float tile_width;
	private Vector3 start_pos;


	// Use this for initialization
	void Start () {
		start_pos = transform.position;
		scroll_speed = -0.05f;
		tile_width = -13.0f;
	}
	
	// Update is called once per frame
	void Update () {
//		float new_position = Mathf.Repeat (Time.time * scroll_speed, tile_height);
//		transform.position = start_pos + Vector3.forward * new_position;

		Vector3 new_position = transform.position += new Vector3 (scroll_speed, 0.0f, 0.0f);
		if (new_position.x < tile_width) {
			new_position.x = 0.5f;
		}
		transform.position = new_position;


	}
}
