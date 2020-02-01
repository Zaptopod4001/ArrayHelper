using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eses.ArrayHelpers
{

    public class ArrayHelper
    {

        // Does a smaller array overlap some area of bigger array? 
        // Smaller array can cross borders of bigger array.
        public static bool ArrayOverlaps<T>(T[,] arr, T[,] arr2, Vector2Int arr2Origin, T solid) where T : IComparable
        {
            var w = arr.GetLength(1);
            var h = arr.GetLength(0);
            var w2 = arr2.GetLength(1);
            var h2 = arr2.GetLength(0);
            var px = arr2Origin.x;
            var py = arr2Origin.y;

            for (int y = 0; y < h2; y++)
            {
                for (int x = 0; x < w2; x++)
                {
                    if (px + x >= 0 && px + x < w && py + y >= 0 && py + y < h)
                    {
                        if (arr[py + y, px + y].Equals(arr2[y, x]) && (arr[py + y, px + y].Equals(solid)))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        // Does a smaller array overlap some area of bigger array? 
        // Smaller array can cross borders of bigger array.
        public static List<Vector2> ArrayOverlapsAt<T>(T[,] arr, T[,] arr2, Vector2Int arr2Origin, T solid) where T : IComparable
        {
            var w = arr.GetLength(1);
            var h = arr.GetLength(0);
            var w2 = arr2.GetLength(1);
            var h2 = arr2.GetLength(0);
            var px = arr2Origin.x;
            var py = arr2Origin.y;
            List<Vector2> overlaps = new List<Vector2>();

            for (int y = 0; y < h2; y++)
            {
                for (int x = 0; x < w2; x++)
                {
                    if (px + x >= 0 && px + x < w && py + y >= 0 && py + y < h)
                    {
                        if (arr[py + y, px + y].Equals(arr2[y, x]) && (arr[py + y, px + y].Equals(solid)))
                        {
                            overlaps.Add(new Vector2(x, y));
                        }
                    }
                }
            }

            return overlaps;
        }


        // Do same size arrays overlap?
        public static bool ArraysOverlap<T>(T[,] arr, T[,] arr2, T solid) where T : IComparable
        {
            var w = arr.GetLength(1);
            var h = arr.GetLength(0);

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    if (arr[y, x].Equals(arr2[y, x]) && (arr[y, x].Equals(solid)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Cells overlapping in same size arrays
        public static List<Vector2> ArraysOverlapAt<T>(T[,] arr, T[,] arr2, T solid) where T : IComparable
        {
            var w = arr.GetLength(1);
            var h = arr.GetLength(0);
            List<Vector2> overlaps = new List<Vector2>();

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    if (arr[y, x].Equals(arr2[y, x]) && (arr[y, x].Equals(solid)))
                    {
                        overlaps.Add(new Vector2(x, y));
                    }
                }
            }

            return overlaps;
        }



        // 1D / 2D array conversion

        public static T[,] ToArr2D<T>(T[] arr, int w, int h)
        {
            var nArr = new T[h, w];

            for (int i = 0; i < arr.Length; i++)
            {
                var x = i % w;
                var y = i / w;
                Debug.Log("y:" + y);

                nArr[y, x] = arr[i];
            }

            return nArr;
        }

        public static T[] ToArr1D<T>(T[,] arr)
        {
            var len = arr.GetLength(0) * arr.GetLength(1);
            var nArr = new T[len];
            var idx = 0;

            for (int y = 0; y < arr.GetLength(0); y++)
            {
                for (int x = 0; x < arr.GetLength(1); x++)
                {
                    nArr[idx] = arr[y, x];
                    idx++;
                }
            }

            return nArr;
        }



        // 2D array transforms

        public static T[,] RotateCWise<T>(T[,] arr)
        {
            int h = arr.GetLength(0);
            int w = arr.GetLength(1);
            T[,] rot = new T[w, h];

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    var c = arr[y, x];
                    var nx = (h - 1) - y;
                    var ny = x;
                    rot[ny, nx] = c;
                }
            }

            return rot;
        }

        public static T[,] RotateCCWise<T>(T[,] arr)
        {
            int h = arr.GetLength(0);
            int w = arr.GetLength(1);
            T[,] rot = new T[w, h];

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    var c = arr[y, x];
                    var nx = y;
                    var ny = (w - 1) - x;
                    rot[ny, nx] = c;
                }
            }

            return rot;
        }

        public static T[,] Rotate180<T>(T[,] arr)
        {
            return RotateCWise(RotateCWise(arr));
        }

        public static T[,] FlipX<T>(T[,] arr)
        {
            int h = arr.GetLength(0);
            int w = arr.GetLength(1);
            T[,] rot = new T[h, w];

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    var c = arr[y, x];
                    var nx = (w - 1) - x;
                    var ny = y;
                    rot[ny, nx] = c;
                }
            }

            return rot;
        }

        public static T[,] FlipY<T>(T[,] arr)
        {
            int h = arr.GetLength(0);
            int w = arr.GetLength(1);
            T[,] rot = new T[h, w];

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    var c = arr[y, x];
                    var nx = x;
                    var ny = (h - 1) - y;
                    rot[ny, nx] = c;
                }
            }

            return rot;
        }



        // Array to string

        public static string DebugDraw(int[,] arr)
        {
            var str = "";

            for (int y = 0; y < arr.GetLength(0); y++)
            {
                for (int x = 0; x < arr.GetLength(1); x++)
                {
                    str += arr[y, x];
                }

                str += "\n";
            }

            return str;
        }

        public static string DebugDraw(int[] arr)
        {
            var str = "";

            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i];
            }

            return str;
        }

    }

}
