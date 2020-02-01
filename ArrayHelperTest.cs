using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eses.ArrayHelpers;

namespace Eses.ArrayHelpers
{

    public class ArrayHelperTest : MonoBehaviour
    {

        public int[,] arr = new int[4, 3]
        {
            {0,0,1},
            {0,0,1},
            {0,1,1},
            {0,0,0}
        };

        public int[,] arr2 = new int[3, 3]
        {
            {0,0,0},
            {0,1,0},
            {0,0,1}
        };

        public int[,] arr3 = new int[4, 4]
        {
            {0,0,0,0},
            {0,0,0,0},
            {0,0,1,0},
            {0,0,0,0}
        };

        public int[] arr1D = new int[]
        {
            0, 0, 1,
            0, 0, 1,
            0, 1, 1,
            0, 0, 0
        };

        void Start()
        {
            var overlaps = ArrayHelper.ArrayOverlapsAt<int>(arr3, arr2, new Vector2Int(1, 1), 1);

            Debug.Log("overlap count:" + overlaps.Count);

            foreach (var c in overlaps)
            {
                Debug.Log("Arrays overlap at:" + c);
            }
        }
    }

}
