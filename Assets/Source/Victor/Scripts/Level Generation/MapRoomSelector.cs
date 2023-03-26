using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRoomSelector : MonoBehaviour
{
    public GameObject[]
        pfU, pfD, pfR, pfL,
        pfUD, pfRL, pfUR, pfUL, pfDR, pfDL,
        pfUDR, pfUDL, pfURL, pfDRL,
        pfUDRL;
    private bool up, down, right, left;
    private int type;
    private int randomRoom;

    public void GenerateRoom(Vector2 drawPos, int _type, bool _up, bool _down, bool _right, bool _left)
    {
        type = _type;
        up = _up;
        down = _down;
        right = _right;
        left = _left;


        if (up)
        {
            if (down)
            {
                if (right)
                {
                    if (left)
                    {
                        randomRoom = Random.Range(0, pfUDRL.Length);

                        Instantiate(pfUDRL[randomRoom], drawPos, Quaternion.identity);
                    } else
                    {
                        randomRoom = Random.Range(0, pfUDR.Length);

                        Instantiate(pfUDR[randomRoom], drawPos, Quaternion.identity);
                    }
                } else if (left)
                {
                    randomRoom = Random.Range(0, pfUDL.Length);

                    Instantiate(pfUDL[randomRoom], drawPos, Quaternion.identity);
                } else
                {
                    randomRoom = Random.Range(0, pfUD.Length);

                    Instantiate(pfUD[randomRoom], drawPos, Quaternion.identity);
                }
            } else
            {
                if (right)
                {
                    if (left)
                    {
                        randomRoom = Random.Range(0, pfURL.Length);

                        Instantiate(pfURL[randomRoom], drawPos, Quaternion.identity);
                    } else
                    {
                        randomRoom = Random.Range(0, pfUR.Length);

                        Instantiate(pfUR[randomRoom], drawPos, Quaternion.identity);
                    }
                } else if (left)
                {
                    randomRoom = Random.Range(0, pfUL.Length);

                    Instantiate(pfUL[randomRoom], drawPos, Quaternion.identity);
                } else
                {
                    randomRoom = Random.Range(0, pfU.Length);

                    Instantiate(pfU[randomRoom], drawPos, Quaternion.identity);
                }
            }
            return;
        }
        if (down)
        {
            if (right)
            {
                if (left)
                {
                    randomRoom = Random.Range(0, pfDRL.Length);

                    Instantiate(pfDRL[randomRoom], drawPos, Quaternion.identity);
                } else
                {
                    randomRoom = Random.Range(0, pfDR.Length);

                    Instantiate(pfDR[randomRoom], drawPos, Quaternion.identity);
                }
            } else if (left)
            {
                randomRoom = Random.Range(0, pfDL.Length);

                Instantiate(pfDL[randomRoom], drawPos, Quaternion.identity);
            } else
            {
                randomRoom = Random.Range(0, pfD.Length);

                Instantiate(pfD[randomRoom], drawPos, Quaternion.identity);
            }
            return;
        }
        if (right)
        {
            if (left)
            {
                randomRoom = Random.Range(0, pfRL.Length);

                Instantiate(pfRL[randomRoom], drawPos, Quaternion.identity);
            } else
            {
                randomRoom = Random.Range(0, pfR.Length);

                Instantiate(pfR[randomRoom], drawPos, Quaternion.identity);
            }
        } else
        {
            randomRoom = Random.Range(0, pfL.Length);

            Instantiate(pfL[randomRoom], drawPos, Quaternion.identity);
        }
    }

}
