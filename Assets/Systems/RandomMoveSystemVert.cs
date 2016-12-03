﻿using UnityEngine;
using FYFY;

public class RandomMoveSystemVert : FSystem {
	//Faire des random move verticalement pour les éléments qui peuvent bouger
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move),typeof(RandomMove)));



	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _controllableGO) {

			RandomMove randomMoveAvg = go.GetComponent<RandomMove> ();



			float time;
			float reloadProgress;
			bool left;


			time = randomMoveAvg.reloadTimeLeft;
			randomMoveAvg.reloadProgressLeft += Time.deltaTime;
			reloadProgress = randomMoveAvg.reloadProgressLeft;
			left = randomMoveAvg.left;


			if (reloadProgress >= time){
				if (randomMoveAvg != null) {
					randomMoveAvg.randomRangeLeft ();
				} 

			}
			Transform tr = go.GetComponent<Transform> ();
			Move mv = go.GetComponent<Move> ();

			Vector3 movement = Vector3.zero;

			if (left) {
				movement += Vector3.left;
			}
			else {
				movement += Vector3.right;
			}
			tr.position += movement * mv.vitesse * mv.coefd * mv.coefv * Time.deltaTime;

		}
	}
}