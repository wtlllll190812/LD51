using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float currentTime;
    public float boardTime;
    public float GameTimer;
    public GameObject player;
    public GameObject board;
    public Transform boardPoint;
    public Text _text;
    public GameObject FailPanel;
    public Text _gradesText;
    public GameObject DiePanel;

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
                _text.text = $"{(int)currentTime}";
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

    private void Update()
    {
        if(player!=null)
        GameTimer += Time.deltaTime;
        if (player==null)
        {
            StartCoroutine(Fail());
        }
    }
    public IEnumerator Fail()
    {
        FailPanel.SetActive(true);
        _gradesText.text = $"Your Grades:{(int)GameTimer}";
        yield return new WaitForSeconds(3f);
        DiePanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

}
