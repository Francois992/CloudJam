using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public static Hud instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private Image Coco1Fill = null;
    [SerializeField] private Image Coco2Fill = null;
    [SerializeField] private Image Coco3Fill = null;
    [SerializeField] private Image Coco4Fill = null;

    [HideInInspector] public List<Image> cocoFills = new List<Image>();

    private float CocoCooldown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        cocoFills.Add(Coco1Fill);
        cocoFills.Add(Coco2Fill);
        cocoFills.Add(Coco3Fill);
        cocoFills.Add(Coco4Fill);

        for(int i = 0; i < cocoFills.Count; i++)
        {
            cocoFills[i].gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cocoFills.Count; i++)
        {
            if(cocoFills[i].fillAmount < 1)
            {
                cocoFills[i].fillAmount += CocoCooldown * Time.deltaTime;
            }
            else
            {
                cocoFills[i].gameObject.SetActive(false);
            }
        }
    }
}
