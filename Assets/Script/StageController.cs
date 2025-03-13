using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class StageController : MonoBehaviour
{
    [SerializeField] GameObject initialStage;
    [SerializeField] List<GameObject> stages;
    [SerializeField] float speed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private const int stageWidth = 40;
    private const int initialStageCount = 5;//初期に生成されるステージの数
    private List<GameObject> stageListInGame = new List<GameObject>();
    void Start()
    {
        stageListInGame.Add(initialStage);
        for (int i = 0; i < initialStageCount; i++)
        {
            int index = Random.Range(0, stages.Count);
            GameObject stage = Instantiate(stages[index], new Vector3((i + 1) * stageWidth, 0, 0), Quaternion.identity);
            stageListInGame.Add(stage);
        }
    }
    private void Update()
    {
        for (int i =0;i<stageListInGame.Count;i++)
        {
            stageListInGame[i].transform.position += Vector3.left * speed * Time.deltaTime;
            if (stageListInGame[i].transform.position.x < stageWidth * -2)
            {
                Destroy(stageListInGame[i]);
                stageListInGame.RemoveAt(i);
                int index = Random.Range(0, stages.Count);
                GameObject stage = Instantiate(stages[index], 
                                               new Vector3((stageListInGame.Count - 1) * stageWidth, 0, 0),
                                               Quaternion.identity);
                stageListInGame.Add(stage);
            }
        }
    }
}
