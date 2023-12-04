using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCanvasController : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float scrollSpeed = 100f;
    public Vector3 highlightColor = new Vector3(255, 165, 0);
    public List<GameObject> itemRowList;
    public GameObject itemRowInstance;
    public GameObject contentParent;
    public Transform spawnPos;
    List<GameObject> pooledItems = new List<GameObject>();
    private int maxInitItemCount = 10;
    private void OnEnable()
    {
        itemRowList = new List<GameObject>();
        for (int i = 0; i < maxInitItemCount; ++i)
        {
            GameObject newRow = Instantiate(itemRowInstance);
            newRow.transform.parent = contentParent.transform;
            newRow.SetActive(false);
            pooledItems.Add(newRow);

        }
    }
    public void AddRow(Collider collider)
    {
        string itemName = collider.gameObject.name;
        GameObject newRow = GetPooledItem();
        itemRowList.Add(collider.gameObject);
        Vector3 newSpawnPos;
        newSpawnPos = new Vector3(spawnPos.position.x, spawnPos.position.y + itemRowList.Count * -100);
        newRow.transform.position = newSpawnPos;
        newRow.transform.parent = contentParent.transform;
        newRow.GetComponent<ItemPickupRow>().InitItemRow(itemName);
    }
    void Update()
    {
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(scrollDelta);
        if (Mathf.Abs(scrollDelta) > 0.01f)
        {
            // Adjust the vertical position of the Scroll Rect's content based on the scroll wheel input.
            scrollRect.verticalNormalizedPosition += scrollDelta * scrollSpeed * Time.deltaTime;
        }
    }
    GameObject GetPooledItem()
    {
        if (pooledItems.Count > 0)
        {
            GameObject item = pooledItems[pooledItems.Count - 1];
            pooledItems.RemoveAt(pooledItems.Count - 1);
            item.SetActive(true);
            return item;
        }
        return null;
    }
}
