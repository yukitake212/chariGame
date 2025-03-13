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
    private const int initialStageCount = 5;//�����ɐ��������X�e�[�W�̐�
    private List<GameObject> stageListGame = new List<GameObject>();
    void Start()
    {
        stageListGame.Add(initialStage);
        for (int i = 0; i < initialStageCount; i++)
        {
            int index = Random.Range(0, stages.Count);
            GameObject stage = Instantiate(stages[index], new Vector3((i + 1) * stageWidth, 0, 0), Quaternion.identity);
            stageListGame.Add(stage);
        }
    }
    private void Update()
    {
        for (int i =0;i<stageListGame.Count;i++)
        {
            stageListGame[i].transform.position += Vector3.left * speed * Time.deltaTime;
            if (stageListGame[i].transform.position.x < stageWidth * -2)
            {
                Destroy(stageListGame[i]);
                stageListGame.RemoveAt(i);
                int index = Random.Range(0, stageListGame.Count);
                GameObject stage = Instantiate(stages[index], 
                                               new Vector3((stageListGame.Count - 1) * stageWidth, 0, 0),
                                               Quaternion.identity);
                stageListGame.Add(stage);
            }
        }
    }
}
