using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class HeapSort : MonoBehaviour
{
    struct Backup
    {
        public int[] arrNum;
        public int count;
        public bool oneClick;

        public Backup(int[] aN, int c, bool o)
        {
            arrNum = new int[aN.Length];
            for (int i = 0; i < aN.Length; i++)
            {
                arrNum[i] = aN[i];
            }

            count = c;
            oneClick = o;
        }
    }

    public int[] arrNum;
	public int size;

    int count;
    int count2;
    bool OneCick;

    private Stack<Backup> list = new Stack<Backup>();
    
    void Start()
    {
        arrNum = new int[size];
        OneCick = false;
        int select;

        for (int i = 0; i < size; i++)
        {
            do
            {
                select = Random.Range(1, 201);
            }
            while (arrNum.Contains(select));

            arrNum[i] = select;
        }

        count2 = (arrNum.Length - 1) / 2;
        count = arrNum.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HeapSortOneStep()
    {
        while(true)
        {
            list.Push(new Backup(arrNum, count, OneCick));

            if(count2 >= 0)
            {
                CalcHeap(arrNum, count2, arrNum.Length);
                count2--;
                break;
            }

            if (count > 0)
            {
                SwapHeap(ref arrNum[count], ref arrNum[0]);
                CalcHeap(arrNum, 0, count);
                count--;
                break;
            }
            break;
        }
    }

    public void SortHeap()
    {
        //int[] nArrData = { 20, 35, 15, 5, 40, 10, 25, 30 };

        for (int i = (arrNum.Length - 1) / 2; i >= 0; --i)
        {
            CalcHeap(arrNum, i, arrNum.Length);
        }
        for (int i = arrNum.Length - 1; i > 0; --i)
        {
            SwapHeap(ref arrNum[i], ref arrNum[0]);
            CalcHeap(arrNum, 0, i);
        }
    }

    void CalcHeap(int[] nArrData, int nRoot, int nMax)
    {
        while (nRoot < nMax)
        {
            int nChild = nRoot * 2 + 1;
            if (nChild + 1 < nMax && nArrData[nChild] < nArrData[nChild + 1])
                ++nChild; //오른쪽 노드

            if (nChild < nMax && nArrData[nRoot] < nArrData[nChild])
            {
                SwapHeap(ref nArrData[nRoot], ref nArrData[nChild]);
                nRoot = nChild;
            }
            else
                break;
        }
    }

    void SwapHeap(ref int nData1, ref int nData2)
    {
        int nTemp = nData1;
        nData1 = nData2;
        nData2 = nTemp;
    }

    public void Back()
    {
        Backup bu = new Backup();

        bu = list.Pop();

        for (int i = 0; i < bu.arrNum.Length; i++)
        {
            arrNum[i] = bu.arrNum[i];
        }
        count = bu.count;
    }
}
