using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingoltone : MonoBehaviour
{
    public static Player Player;

    public void SetPlayer(Player newPlayer)
    {
        if(Player == null)
            Player = newPlayer;
    }

    public Player GetPlayer()
    {
        return Player;
    }

    public static PlayerSingoltone SingoltonePlayer = new PlayerSingoltone();
}
