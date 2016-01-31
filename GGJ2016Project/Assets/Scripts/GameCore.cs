using UnityEngine;
using System.Collections;

public enum GameStatus{
	Normal,
	End
}

public class GameCore : MonoBehaviour
{
	public static GameStatus currStatus = GameStatus.Normal;
	public static UILabel m_labelP1Win;
	public static UILabel m_labelP2Win;
	public static UIButton m_btnPlayAgain;
	public UILabel p1;
	public UILabel p2;
	public UIButton replayBtn;

	void Start(){
		m_labelP1Win = p1;
		m_labelP2Win = p2;
		m_labelP1Win.text = "";
		m_labelP2Win.text = "";
		m_btnPlayAgain = replayBtn;
		m_btnPlayAgain.gameObject.SetActive(false);
		currStatus = GameStatus.Normal;

		AudioControler.getInstance().playBGM();
	}

	public static void setWinner(int team){
		if (team == 0) {
			m_labelP1Win.text = "WINNER";
			m_labelP2Win.text = "LOSER";
		} else {
			m_labelP1Win.text = "LOSER";
			m_labelP2Win.text = "WINNER";
		}
		m_btnPlayAgain.gameObject.SetActive(true);
		currStatus = GameStatus.End;
	}

	public void playAgain(){
		Application.LoadLevel(0);
	}
}

