using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GG : MonoBehaviour {

	int[, ] board = new int[3, 3];
	int turn;
	int remain = 9;
	int judge () {
		if (board[1, 1] == board[1, 0] && board[1, 1] == board[1, 2] && 0 != board[1, 1]) return board[1, 1];
		if (board[1, 1] == board[0, 1] && board[1, 1] == board[2, 1] && 0 != board[1, 1]) return board[1, 1];
		if (board[1, 1] == board[0, 0] && board[1, 1] == board[2, 2] && 0 != board[1, 1]) return board[1, 1];
		if (board[1, 1] == board[2, 0] && board[1, 1] == board[0, 2] && 0 != board[1, 1]) return board[1, 1];
		if (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] && 0 != board[1, 0]) return board[1, 0];
		if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] && 0 != board[0, 1]) return board[0, 1];
		if (board[2, 2] == board[1, 2] && board[1, 2] == board[0, 2] && 0 != board[1, 2]) return board[1, 2];
		if (board[2, 2] == board[2, 1] && board[2, 1] == board[2, 0] && 0 != board[2, 1]) return board[2, 1];
		if (remain == 0) return 2;
		return 0;
	}
	// Use this for initialization
	void Start () {
		reset ();
	}

	void reset () {
		turn = 1;
		int i, j;
		for (i = 0; i <= 2; ++i)
			for (j = 0; j <= 2; ++j)
				board[i, j] = 0;
		remain = 9;
	}
	void showRes () {
		if (judge () == 1)
			GUI.Label (new Rect (420 , 20, 100, 80), "O is winner!");
		else if (judge () == -1)
			GUI.Label (new Rect (420 , 20, 100, 80), "X is winner!");
		else if (judge () == 2)
			GUI.Label (new Rect (420 , 20, 100, 80), "Draw!");
		else GUI.Label (new Rect (420 , 20, 100, 80), "Running!");
	}
	void OnGUI () {

		if (GUI.Button (new Rect (400 , 450, 100, 80), "Reset")) {
			Start ();
		}
		showRes ();
		for (int i = 0; i < 3; i++)
			for (int j = 0; j < 3; j++) {
				if (board[i, j] == 1) GUI.Button (new Rect (i * 100 + 300, j * 100 + 100, 100, 100), "O");
				if (board[i, j] == -1) GUI.Button (new Rect (i * 100 + 300, j * 100 + 100, 100, 100), "X");
				// if (board[i, j] == 0) GUI.Button (new Rect (i * 100 + 400, j * 100 + 80, 100, 100), "");
				if (GUI.Button (new Rect (i * 100 + 300, j * 100+ 100, 100, 100), "")) {
					if (judge () == 0 && board[i, j] == 0) {
						board[i, j] = turn;
						remain--;
						turn = -turn;
						showRes ();
					}
				}
			}

	}
	// Update is called once per frame
	void Update () {

	}
}