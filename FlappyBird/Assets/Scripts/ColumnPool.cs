using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public GameObject columnPrefab;
    public float positioningRate = 1f;
    public float xPosition = 10f;
    public float columnMin = -3f;
    public float columnMax = 3f;

    private GameObject[] columns;
    private int numColumns;
    private Vector2 offScreenLocation;
    private int currentColumnIndex;
    private float lastPositioningTime;

    void Start()
    {
        numColumns = 5;
        columns = new GameObject[numColumns];

        currentColumnIndex = 0;

        //Generate all 5 columns at this offscreen location. And then they will be reused later.
        offScreenLocation = new Vector2(-12f, -10f);
        for (int i = 0; i < numColumns; i++)
        {
            //Quaternion.identity -> Means accept the rotation of the clumnPrefab.
            columns[i] = Instantiate(columnPrefab, offScreenLocation, Quaternion.identity);
        }
    }

    void Update()
    {
        lastPositioningTime += Time.deltaTime;
        if(!GameController.instance.is_gameOver && lastPositioningTime >= positioningRate)
        {
            lastPositioningTime = 0;

            float yPosition = Random.Range(columnMin, columnMax);
            columns[currentColumnIndex].transform.position = new Vector2(xPosition, yPosition);

            currentColumnIndex = (currentColumnIndex + 1) % numColumns;
            lastPositioningTime++;
        }
    }
}
