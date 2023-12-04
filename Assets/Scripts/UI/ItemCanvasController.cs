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
    public int activeRow = 0;
    List<GameObject> uiRowPool = new List<GameObject>();
    List<GameObject> uiRowActive = new List<GameObject>();
    private int maxInitItemCount = 20;
    private void OnEnable()
    {
        itemRowList = new List<GameObject>();
        for (int i = 0; i < maxInitItemCount; ++i)
        {
            GameObject newRow = Instantiate(itemRowInstance);
            newRow.transform.parent = contentParent.transform;
            newRow.SetActive(false);
            uiRowPool.Add(newRow);

        }
        scrollRect.verticalNormalizedPosition = 1.05f;
    }
    public void AddRow(Collider collider)
    {
        string itemName = collider.gameObject.name;
        GameObject newRow = GetPooledItem();
        Vector3 newSpawnPos;
        newSpawnPos = new Vector3(spawnPos.position.x, spawnPos.position.y + itemRowList.Count * -60);
        itemRowList.Add(collider.gameObject);
        newRow.transform.position = newSpawnPos;
        newRow.transform.SetParent(contentParent.transform, false);
        newRow.GetComponent<ItemPickupRow>().InitItemRow(itemName);

    }
    void Update()
    {
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scrollDelta) > 0.01f || uiRowActive.Count > 0)
        {
            // Adjust the vertical position of the Scroll Rect's content based on the scroll wheel input.
            scrollRect.verticalNormalizedPosition += scrollDelta * scrollSpeed * Time.deltaTime;
            //Debug.Log("vertNormPos " + scrollRect.verticalNormalizedPosition);
        }
        else
        {
            scrollRect.verticalNormalizedPosition = 1;
        }
        // Convert verticalNormalizedPosition to content position
        float contentPosY = Mathf.Lerp(contentParent.GetComponent<RectTransform>().rect.height - scrollRect.viewport.rect.height, 0f, scrollRect.verticalNormalizedPosition);

        // Do something with contentPosY
        activeRow = (int)(contentPosY / 100);
        Debug.Log(activeRow);
    }
    GameObject GetPooledItem()
    {
        if (uiRowPool.Count > 0)
        {
            GameObject item = uiRowPool[uiRowPool.Count - 1];
            uiRowPool.RemoveAt(uiRowPool.Count - 1);
            uiRowActive.Add(item);
            item.SetActive(true);
            return item;
        }
        return null;
    }
    public void RemoveItem(GameObject item)
    {
        if (item != null)
        {
            int index = itemRowList.FindIndex(a => a == item);
            itemRowList.Remove(item);
            uiRowPool.Add(uiRowActive[index]);
            uiRowActive[index].SetActive(false);
            uiRowActive.RemoveAt(index);
        }
        for (int i = 0; i < uiRowActive.Count; ++i)
        {
            Vector3 newSpawnPos = spawnPos.position;
            newSpawnPos.y = spawnPos.position.y + (-60 * i);
            uiRowActive[i].transform.position = newSpawnPos;
        }
    }
}
