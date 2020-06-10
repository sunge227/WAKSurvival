using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Item item; //획득한 아이템
    public int itemCount; // 획득한 아이템의 개수
    public Image itemImage; // 아이템의 이미지

    //필요한 컴포넌트
    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    private ItemEffectDatabase theItemEffectDatabase;

    void Start()
    {
        theItemEffectDatabase = FindObjectOfType<ItemEffectDatabase>();
    }
    // 이미지의 투명도 조절
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;

    }

    // 아이템 획득
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        if(item.itemType != Item.ItemType.Equipment)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);       
        }


        SetColor(1);
    }

    // 아이템 갯수 조정
    public void SetSlotCount(int _count)
    { 
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }

    // 슬롯 초기화
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(item != null)
            {
                theItemEffectDatabase.UseItem(item);

                if(item.itemType == Item.ItemType.Used)
                    SetSlotCount(-1);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(item != null)
        {
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(itemImage);

            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
            DragSlot.instance.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.instance.SetColor(0);
        DragSlot.instance.dragSlot = null;
    }

    public void OnDrop(PointerEventData eventData)
    {


        if (DragSlot.instance.dragSlot != null)
        {
            
            ChangeSlot();
        }
           
    }

    private void ChangeSlot() 
    {
        Item _tempItem = item;
        int _tempItemCount = itemCount;

        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);
    
        if(_tempItem != null)
            DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);
        else
            DragSlot.instance.dragSlot.ClearSlot();
    }

    //마우스가 슬롯에 들어갈때 발동
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(item != null)
            theItemEffectDatabase.ShowToolTip(item,transform.position);
    }
    //마우스가 슬롯에서 빠져나갈 때 발동
    public void OnPointerExit(PointerEventData eventData)
    {
        theItemEffectDatabase.HideToolTip();
    }
}
