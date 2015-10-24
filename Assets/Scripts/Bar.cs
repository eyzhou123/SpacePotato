using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour {
	public float barDisplay = 0;
	Vector2 pos = new Vector2(20,40);
	Vector2 size = new Vector2(200,30);
	Texture2D progressBarEmpty;
	Texture2D progressBarFull;

	void OnGUI()
	{
		Texture2D progressBarEmpty = new Texture2D(200, 30);
		Color green = new Color(0, 255, 0);
		int i, j;
		for(i = 0;i<size.x;i++)
		{
			for(j = 0;j<size.y;j++)
			{
				progressBarEmpty.SetPixel(i, j, green);
			}
		}
		progressBarEmpty.Apply();

		Texture2D progressBarFull = new Texture2D(200, 30);
		Color black = new Color(0, 0, 0);
		int k, l;
		for(k = 0;k<size.x;k++)
		{
			for(l = 0;l<size.y;l++)
			{
				progressBarFull.SetPixel(k, l, black);
			}
		}
		progressBarFull.Apply();

		// draw the background:
		GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
		GUI.Box (new Rect (0,0, size.x, size.y),progressBarEmpty);
		
		// draw the filled-in part:
		GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
		GUI.Box (new Rect (0,0, size.x, size.y), progressBarFull);
		GUI.EndGroup ();
		
		GUI.EndGroup ();
		
	} 
	
	void Update()
	{
		// for this example, the bar display is linked to the current time,
		// however you would set this value based on your desired display
		// eg, the loading progress, the player's health, or whatever.
		if (barDisplay >= 1) {
			GameObject potato = GameObject.Find("Potato");
			Move move_script = potato.GetComponent<Move>();
			Debug.Log("no fuel");
			move_script.noFuel();
//			barDisplay = 200;
		} else {
			barDisplay += 0.001f;
		}
	}


}
