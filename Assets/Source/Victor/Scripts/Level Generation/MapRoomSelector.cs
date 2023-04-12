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
    private int randomRoom;

    private GameObject generatedRoom;

    public GameObject GenerateRoom(Vector2 drawPos, bool[] doors)
    {
        up = doors[0];
        down = doors[1];
        right = doors[2];
        left = doors[3];


        if (up)
        {
            if (down)
            {
                if (right)
                {
                    if (left)
                    {
                        randomRoom = Random.Range(0, pfUDRL.Length);

                        generatedRoom = Instantiate(pfUDRL[randomRoom], drawPos, Quaternion.identity);
                    } else
                    {
                        randomRoom = Random.Range(0, pfUDR.Length);

                        generatedRoom = Instantiate(pfUDR[randomRoom], drawPos, Quaternion.identity);
                    }
                } else if (left)
                {
                    randomRoom = Random.Range(0, pfUDL.Length);

                    generatedRoom = Instantiate(pfUDL[randomRoom], drawPos, Quaternion.identity);
                } else
                {
                    randomRoom = Random.Range(0, pfUD.Length);

                    generatedRoom = Instantiate(pfUD[randomRoom], drawPos, Quaternion.identity);
                }
            } else
            {
                if (right)
                {
                    if (left)
                    {
                        randomRoom = Random.Range(0, pfURL.Length);

                        generatedRoom = Instantiate(pfURL[randomRoom], drawPos, Quaternion.identity);
                    } else
                    {
                        randomRoom = Random.Range(0, pfUR.Length);

                        generatedRoom = Instantiate(pfUR[randomRoom], drawPos, Quaternion.identity);
                    }
                } else if (left)
                {
                    randomRoom = Random.Range(0, pfUL.Length);

                    generatedRoom = Instantiate(pfUL[randomRoom], drawPos, Quaternion.identity);
                } else
                {
                    randomRoom = Random.Range(0, pfU.Length);

                    generatedRoom = Instantiate(pfU[randomRoom], drawPos, Quaternion.identity);
                }
            }
            return generatedRoom;
        }
        if (down)
        {
            if (right)
            {
                if (left)
                {
                    randomRoom = Random.Range(0, pfDRL.Length);

                    generatedRoom = Instantiate(pfDRL[randomRoom], drawPos, Quaternion.identity);
                } else
                {
                    randomRoom = Random.Range(0, pfDR.Length);

                    generatedRoom = Instantiate(pfDR[randomRoom], drawPos, Quaternion.identity);
                }
            } else if (left)
            {
                randomRoom = Random.Range(0, pfDL.Length);

                generatedRoom = Instantiate(pfDL[randomRoom], drawPos, Quaternion.identity);
            } else
            {
                randomRoom = Random.Range(0, pfD.Length);

                generatedRoom = Instantiate(pfD[randomRoom], drawPos, Quaternion.identity);
            }
            return generatedRoom;
        }
        if (right)
        {
            if (left)
            {
                randomRoom = Random.Range(0, pfRL.Length);

                generatedRoom = Instantiate(pfRL[randomRoom], drawPos, Quaternion.identity);
            } else
            {
                randomRoom = Random.Range(0, pfR.Length);

                generatedRoom = Instantiate(pfR[randomRoom], drawPos, Quaternion.identity);
            }
        } else
        {
            randomRoom = Random.Range(0, pfL.Length);

            generatedRoom = Instantiate(pfL[randomRoom], drawPos, Quaternion.identity);
        }

        return generatedRoom;
    }

}
