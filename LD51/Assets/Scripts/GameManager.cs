using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float currentTime;
    public float boardTime;
    public GameObject player;
    public GameObject board;
    public Transform boardPoint;

    public void Awake()
    {
        currentTime = 10.1f;
        instance = this;
    }

    public void Start()
    {
        StartCoroutine(Player());
    }

    public IEnumerator Player()
    {
        while(player!=null)
        {
            while (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                yield return null;
            }
            var newBoard = Instantiate(board, boardPoint.position, boardPoint.rotation, player.transform);
            newBoard.transform.parent = player.transform;
            newBoard.GetComponent<BounceBoard>().isActive = true;
            yield return new WaitForSeconds(boardTime);
            newBoard.GetComponent<BounceBoard>().isActive = false;
            newBoard.transform.parent = null;
            currentTime = 10;
        }
    }
}
