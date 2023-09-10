using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using PositionOrder;
using TMPro;



public class QuickSort : MonoBehaviour
{
    struct Backup
    {
        public int pivot;
        public int left;
        public int right;
        public bool pivotsel;
        public bool compLeft;
        public Stack<int> lastLeft;
        public int L, R;
        public int[] arrNum;

        public Backup(int p, int l, int r, bool ps, bool c, Stack<int> las, int ll, int rr, int[] aN)
        {
            arrNum = new int[aN.Length];

            pivot = p;
            left = l;
            right = r;
            pivotsel = ps;
            compLeft = c;
            lastLeft = las;
            L = ll;
            R = rr;
            for(int i = 0; i < aN.Length; i++)
            {
                arrNum[i] = aN[i];
            }
        }
    }
    public GameObject pivotArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;

    public NumBox numPrefab;
    public TextMeshPro swapcountText;
    public int index;

    public int swapcount;

    private Stack<Backup> list = new Stack<Backup>();
    private Stack<int> lastLeft = new Stack<int>();
    private PositionOrderer orderer = new PositionOrderer();

    public int pivot;
    public int left;
    public int right;
    private bool pivotsel;
    private bool compLeft;

    private int L, R;

    public int[] arrNum;
    private Transform[] transforms;

    void Start()
    {
        arrNum = new int[index];
        transforms = new Transform[index];

        int select;

        for (int i = 0; i< index; i++)
        {
            do
            {
                select = Random.Range(1, 201);
            }
            while (arrNum.Contains(select));

            arrNum[i] = select;

            NumBox obj = MonoBehaviour.Instantiate(numPrefab);
            Vector3 pos = new Vector3((-(1.5f * (index / 2) + 0.5f)), 0, 0);
            obj.transform.position = pos;
            obj.index = i;
            obj.name = (i + 1).ToString();

            transforms[i] = obj.transform;
        }
        
        orderer.Transforms.Clear();
        orderer.Transforms.AddRange(transforms);

        orderer.Distance_X = -(transforms[0].position.x * 2) / (index - 1);
        orderer.Distance_Y = 0f;
        orderer.Distance_Z = 0f;

        orderer.ApplyLineOrder(LineAnchor.Start); //Line Type Á¤·Ä

        list.Push(new Backup(pivot, left, right, pivotsel, compLeft, lastLeft, L, R, arrNum));

        pivotsel = false;
        compLeft = false;

        left = 0;
        right = arrNum.Length - 1;
        L = 0;
        R = 0;
    }

    // Update is called once per frame
    void Update()
    {
        swapcountText.text = "SWAP : " + swapcount.ToString();

        int pivotIndex = 0;
        for(int i = 0; i < index; i++)
        {
            if (pivot == arrNum[i])
                pivotIndex = i;
        }

        if(pivotsel)
            pivotArrow.transform.position = new Vector3(transforms[pivotIndex].transform.position.x, transforms[pivotIndex].transform.position.y + 1.5f, transforms[pivotIndex].transform.position.z);

        leftArrow.transform.position = new Vector3(transforms[left].transform.position.x, transforms[left].transform.position.y - 1.5f, transforms[left].transform.position.z);
        rightArrow.transform.position = new Vector3(transforms[right].transform.position.x, transforms[right].transform.position.y - 1.5f, transforms[right].transform.position.z);
    }

    private void swap(int index1, int index2)
    {
        int temp;
        temp = arrNum[index1];
        arrNum[index1] = arrNum[index2];
        arrNum[index2] = temp;

        swapcount++;
    }

    public void QSort_OneStep()
    {
        list.Push(new Backup(pivot, left, right, pivotsel, compLeft, lastLeft, L, R, arrNum));

        while (true)
        {
            if (!pivotsel)
            {
                pivotsel = true;
                //SelectPivot(left, right);
                //arrNum = arrNum.Where(var => var != pivot).ToArray();
                //AddNum(pivot);

                pivot = arrNum[(left + right) / 2];
                break;
            }

            if (left == right)
            {
                if (R == 0) R = right;

                if (L == R && !compLeft)
                {
                    compLeft = true;

                    right = arrNum.Length - 1;
                    left = L;
                    SelectPivot(left, right);
                    lastLeft.Push(right);

                    break;
                }

                if (left == L)
                {
                    if(compLeft)
                    {
                        L = lastLeft.Pop();
                        right = arrNum.Length - 1;
                    }
                    else
                    {
                        L = lastLeft.Pop();
                        right = lastLeft.Last();
                    }
                }
                left = L;
                SelectPivot(left, right);
                lastLeft.Push(right);

                break;
            }


            if (arrNum[left] >= pivot)
            {
                if (arrNum[right] > pivot)
                {
                    right--;
                }
                else
                {
                    swap(left, right);
                }
                break;
            }
            else
            {
                left++;
                break;
            }
        }
    }

    public void Back()
    {
        Backup bu = new Backup();

        bu = list.Pop();

        pivot = bu.pivot;
        left = bu.left;
        right = bu.right;
        pivotsel = bu.pivotsel;
        compLeft = bu.compLeft;
        lastLeft = bu.lastLeft;
        L = bu.L;
        R = bu.R;
        for (int i = 0; i < bu.arrNum.Length; i++)
        {
            arrNum[i] = bu.arrNum[i];
        }
    }

    private void SelectPivot(int min, int max)
    {
        pivot = arrNum[(min + max) / 2];

        //int ran1 = 0;
        //int ran2 = 0;
        //int ran3 = 0;

        //int p;
        //if(max > 2)
        //{
        //    ran1 = Random.Range(min, max + 1);

        //    for (int i = 0; i < 1; i++)
        //    {
        //        ran2 = Random.Range(min, max + 1);
        //        if (ran1 == ran2) i--;
        //    }

        //    for (int i = 0; i < 1; i++)
        //    {
        //        ran3 = Random.Range(min, max);
        //        if (ran1 == ran3 || ran2 == ran3) i--;
        //    }
        //}

        //if (arrNum[ran1] < arrNum[ran2])
        //    p = (arrNum[ran2] < arrNum[ran3]) ? ran2 : ((arrNum[ran3] < arrNum[ran1]) ? ran1 : ran3);
        //else
        //    p = (arrNum[ran1] < arrNum[ran3]) ? ran1 : ((arrNum[ran3] < arrNum[ran2]) ? ran2 : ran3);

        //pivot = arrNum[p];

        //arrNum = arrNum.Where(var => var != arrNum[p]).ToArray();
        //InsertNum(pivot, max);
    }

    private void AddNum(int num)
    {
        List<int> ls = arrNum.ToList();
        ls.Add(num);
        arrNum = ls.ToArray();
    }

    private void InsertNum(int num, int index)
    {
        arrNum = arrNum.Where(var => var != num).ToArray();
        List<int> ls = arrNum.ToList();
        ls.Insert(index, num);
        arrNum = ls.ToArray();
    }
}
