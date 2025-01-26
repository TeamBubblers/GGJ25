using UnityEngine;
using System.Collections.Generic;

public class NewMonoBehaviour : MonoBehaviour
{
    [SerializeField]
    public List<float> SectionsYPositions;
    [SerializeField]
    public int generatedSectionCounter = 4;
    [SerializeField]
    public List<GameObject> SectionOne;// = new List<GameObject>();
    [SerializeField]
    public List<GameObject> SectionTwo;// = new List<GameObject>();
    [SerializeField]
    public List<GameObject> SectionThree;// = new List<GameObject>();
    [SerializeField]
    public List<GameObject> SectionFour;// = new List<GameObject>();

    private List<List<GameObject>> Sections = new List<List<GameObject>>();
    private List<GameObject> ResultSequence = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        Sections.Add(SectionOne);
        Sections.Add(SectionTwo);
        Sections.Add(SectionThree);
        Sections.Add(SectionFour);

        CreateSequence();
        SpawnResultSequence();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateSequence()
    {
        for(int i = 0; i < Sections.Count; ++i)
        {
            int currentIndex = Random.Range(0, 2); // hardcoded for 2 prefabs per section
            Debug.Log(currentIndex);
            ResultSequence.Add(Sections[i][currentIndex]);
        }
    }

    void SpawnResultSequence()
    {
        GameObject newGameObject = new GameObject("NewObject");
        Transform SectionTransform = newGameObject.transform;

        for(int i = 0; i < Sections.Count; ++i)
        {
            SectionTransform.rotation = Quaternion.identity;
            SectionTransform.position = new Vector3(0, SectionsYPositions[i], 0);
            SectionTransform.localScale = new Vector3(1, 1, 1);

            ResultSequence[i].transform.position = SectionTransform.position;
            ResultSequence[i].transform.rotation = SectionTransform.rotation;
            ResultSequence[i].transform.localScale = SectionTransform.localScale;
            Instantiate(ResultSequence[i]);
        }
    }
}
