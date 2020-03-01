using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;//IPointerClickHandler
using UnityEngine.EventSystems;//IPointerClickHandler
using UnityEngine.SceneManagement;

public class LevelSlider : MonoBehaviour, IBeginDragHandler,IEndDragHandler
{
    ScrollRect rect;
    //方法1 计算
    //页面：0，1，2  索引从0开始
    //每页占的比列：0/2=0  1/2=0.5  2/2=1
    float[] pages = { 0f, 0.5f, 1f };
    //方法2  通用
    //List<float> pages = new List<float>();
    int currentPageIndex = -1;

    //滑动速度
    public float smooting = 16;

    //滑动的目标坐标
    float targetHorizontal = 0;

    //是否拖拽结束
    bool isDrag = false;

    //索引  假设初始时是第一张图片
    int index = 0;

    /// <summary>
    /// 用于返回一个页码，-1说明page的数据为0
    /// </summary>
    public System.Action<int, int> OnPageChanged;

    //float startime = 0f;
    //float delay = 0.1f;

    void Awake()
    {
        rect = GameObject.Find("TopPanel").GetComponent<ScrollRect>();
    }
    void Start()
    {
        rect.horizontalNormalizedPosition = 0;
        //UpdatePages();      
        //startime = Time.time;
    }

    void Update()
    {
        //if (Time.time < startime + delay) return;
        //UpdatePages();
        //如果不判断。当在拖拽的时候要也会执行插值，所以会出现闪烁的效果
        //这里只要在拖动结束的时候。在进行插值
        if (!isDrag && pages.Length > 0)
        {
            rect.horizontalNormalizedPosition = Mathf.Lerp(rect.horizontalNormalizedPosition, targetHorizontal, Time.deltaTime * smooting);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        float posX = rect.horizontalNormalizedPosition;
        Debug.Log("pox"+posX);
        float offset = posX - pages[index];//为正右移 为负左移
        Debug.Log("offset" + offset);
        if (offset > 0 && index < pages.Length - 1)//防止越界
            index++;
        else if (offset < 0 && index > 0)
            index--;

        /*法2
        float offset = Mathf.Abs(pages[index] - posX);
        for (int i = 1; i < pages.Length; i++) 
        {
            float temp = Mathf.Abs(pages[i] - posX);
            if (temp < offset)
            {
                index = i;
                //保存当前的偏移量
                //如果到最后一页。反翻页。所以要保存该值，如果不保存。你试试效果就知道
                offset = temp;
            }
        }
        if (index != currentPageIndex)
        {
            currentPageIndex = index;
            OnPageChanged(pages.Count, currentPageIndex);
        }*/
        targetHorizontal = pages[index];
    }

    /*void UpdatePages()
    {
        // 获取子对象的数量
        int count = this.rect.content.childCount;
        int temp = 0;
        for(int i=0; i<count; i++)
        {
            if(this.rect.content.GetChild(i).gameObject.activeSelf)
            {
                temp++;
            }
        }
        count = temp;
        
        if (pages.Count!=count)
        {
            if (count != 0)
            {
                pages.Clear();
                for (int i = 0; i < count; i++)
                {
                    float page = 0;
                    if(count!=1)
                        page = i / ((float)(count - 1));
                    pages.Add(page);
                    //Debug.Log(i.ToString() + " page:" + page.ToString());
                }
            }
            OnEndDrag(null);
        }
    }*/

    public void OnButtonClick(int value)
    {
        switch (value)
        {
            case 1:
                index = 0;
                break;
            case 2:
                index = 1;
                break;
            case 3:
                index = 2;
                break;
            default:
                Debug.LogError("!!!!!");
                break;
        }
        isDrag = false;
        targetHorizontal = pages[index];
    }

    public void OnButtonClickWater()
    {
        newLevel();
        GameManager.getInstance().level = "waterfall";
        SceneManager.LoadScene("waterfall");
    }
    public void OnButtonClickcave()
    {
        newLevel();
        GameManager.getInstance().level = "cave";
        SceneManager.LoadScene("cave");
    }
    public void OnButtonClickvolcanocave()
    {
        newLevel();
        GameManager.getInstance().level = "volcanocave";
        SceneManager.LoadScene("volcanocave");
    }
    void newLevel()
    {
        GameManager.getInstance().GAMESTATE = GameManager.getInstance().PREPARING;
    }
}