using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class UnitTypeSelectedUI : MonoBehaviour
{
    [SerializeField] private Sprite arrowSprite;

    private Dictionary<SpawnTypeSO, Transform> buttonTransformDictionary;
    private void Awake()
    {
        Transform buttonTemplate = transform.Find("buttonTemplate");
        buttonTemplate.gameObject.SetActive(false);

        SpawnTypeListSO spawnTypeList = Resources.Load<SpawnTypeListSO>(typeof(SpawnTypeListSO).Name);

        buttonTransformDictionary = new Dictionary<SpawnTypeSO, Transform>();

        int index = 0;

        Transform buttonTransform = Instantiate(buttonTemplate, transform);
        buttonTransform.gameObject.SetActive(true);

        float offsetAmount = 130f;
        buttonTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

        buttonTransform.Find("image").GetComponent<Image>().sprite = spawnType.sprite;

        buttonTransform.GetComponent<Button>().onClick.AddListener(() =>
        {
            SpawnManager.Instance.SetActiveSpawnType(spawnType);
        });

        index++;

        foreach (SpawnTypeSO spawnType in spawnTypeList.list)
        {
            Transform buttonTransform = Instantiate(buttonTemplate, transform);
            buttonTransform.gameObject.SetActive(true);

            float offsetAmount = 130f;
            buttonTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

            buttonTransform.Find("image").GetComponent<Image>().sprite = spawnType.sprite;

            buttonTransform.GetComponent<Button>().onClick.AddListener(() =>
            {
                SpawnManager.Instance.SetActiveSpawnType(spawnType);
            });

            buttonTransformDictionary[spawnType] = buttonTransform;

            index++;
        }
    }
   
    private void Update()
    {
        UpdateActiveUnitTypeButton();
    }

    private void UpdateActiveUnitTypeButton()
    {
        foreach (SpawnTypeSO spawnType in buttonTransformDictionary.Keys)
        {
            Transform buttonTransform = buttonTransformDictionary[spawnType];
            buttonTransform.Find("selected").gameObject.SetActive(false);
        }

        SpawnTypeSO activeSpawnType = SpawnManager.Instance.GetActiveSpawnType();
        buttonTransformDictionary[activeSpawnType].Find("selected").gameObject.SetActive(true);
    }
}
