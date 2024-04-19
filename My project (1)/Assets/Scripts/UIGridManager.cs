using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGridManager : MonoBehaviour
{
    public GameObject gridContainer; // Reference to the grid container GameObject
    public GameObject uiPrefab; // Reference to the UI prefab
    public List<string> dataList; // List of data to display in the grid

    private List<GameObject> uiElements = new List<GameObject>(); // List to keep track of instantiated UI elements

    // Start is called before the first frame update
    void Start()
    {
        GenerateUI();
    }

    // Generates UI elements in the grid based on the data list
    void GenerateUI()
    {
        // Clear existing UI elements
        // ClearUI();

        // Instantiate UI elements for each item in the data list
        foreach (string data in dataList)
        {
            GameObject uiElement = Instantiate(uiPrefab, gridContainer.transform);
            uiElement.GetComponentInChildren<Text>().text = data;
            uiElements.Add(uiElement);
        }
    }

    // Removes UI elements in the specified row
    public void RemoveRow(int rowIndex)
    {
        int startIndex = rowIndex * Mathf.FloorToInt(gridContainer.GetComponent<GridLayoutGroup>().constraintCount);
        int endIndex = startIndex + Mathf.FloorToInt(gridContainer.GetComponent<GridLayoutGroup>().constraintCount);

        for (int i = startIndex; i < endIndex && i < uiElements.Count; i++)
        {
            Destroy(uiElements[i]);
            uiElements.RemoveAt(i);
        }
    }

    // Clears all UI elements
    void ClearUI()
    {
        foreach (GameObject uiElement in uiElements)
        {
            Destroy(uiElement);
        }
        uiElements.Clear();
    }
}
