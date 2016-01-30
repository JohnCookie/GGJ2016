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
	public UILabel p1;
	public UILabel p2;

	void Start(){
		m_labelP1Win = p1;
		m_labelP2Win = p2;
		m_labelP1Win.text = "";
		m_labelP2Win.text = "";
		currStatus = GameStatus.Normal;
	}

	public static void setWinner(int team){
		if (team == 0) {
			m_labelP1Win.text = "WINNER";
			m_labelP2Win.text = "LOSER";
		} else {
			m_labelP1Win.text = "LOSER";
			m_labelP2Win.text = "WINNER";
		}
		currStatus = GameStatus.End;
	}
}

