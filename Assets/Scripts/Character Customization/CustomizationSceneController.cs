using UnityEngine;
using UnityEngine.Events;

public class CustomizationSceneController : MonoBehaviour
{
    public UnityEvent ToPlayer2, OnSceneEnd;
    private enum CurrentPlayer
    {
        PLAYER1,
        PLAYER2
    }

    [SerializeField] private CurrentPlayer currentPlayer;

    private void Awake()
    {
        currentPlayer = CurrentPlayer.PLAYER1;
    }

    public void ToNext()
    {
        if (currentPlayer == CurrentPlayer.PLAYER1)
        {
            currentPlayer = CurrentPlayer.PLAYER2;
            ToPlayer2?.Invoke();
        }
        else if (currentPlayer == CurrentPlayer.PLAYER2)
        {
            Debug.Log("Scene ends");
            OnSceneEnd?.Invoke();
        }
    }
}
