using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double?[] arr1 = new double?[] { null, null, -23.9, -23.9, -18.4, null, 51.31, -28.45, -74.66, 67.75, 11.42 };
            //double?[] arr1 = new double?[] { null, null};
            var stalinList = new List<double?>();
            double?[] stalinArr;
            var reverseList = new List<double?>();
            double?[] reverseArr;
            var arrList = new ArrayList() { null, arr1 };
            var arrListIndex = 1;

            while (true)
            {
                var listCount = arrList.Count;
                var currentArr = (double?[])arrList[arrListIndex];
                Console.Clear();
                Console.WriteLine($"Array {arrListIndex}:");

                for (int i = 0; i < currentArr.Length; i++)
                {
                    Console.WriteLine($"index {i}: {currentArr[i]}");
                }
                Console.WriteLine();
                Console.WriteLine("1. Change array");
                Console.WriteLine("2. Calculate");
                Console.WriteLine("3. Edit value");
                Console.WriteLine("4. Stalin sort");
                Console.WriteLine("5. Reverse sort");
                Console.WriteLine("6. Search value");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.Write("Select an option number: ");
                string selectMain = Console.ReadLine();

                switch (selectMain)
                {
                    default:
                        {
                            Console.Write("Invalid input!");
                            Console.ReadKey(true);
                            break;
                        }
                    case "0":
                        {
                            Console.WriteLine();
                            Console.WriteLine("Closing...");
                            return;
                        }
                    case "1":
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Arrays count: {listCount - 1}");
                            Console.WriteLine("(none to back)");
                            Console.Write("Select array number: ");
                            string selectArrSTR = Console.ReadLine();

                            if (selectArrSTR == "")
                            {
                                Console.WriteLine();
                                Console.Write("Going back...");
                                Console.ReadKey(true);
                                break;
                            }
                            else if (int.TryParse(selectArrSTR, out int selectArr) && selectArr < listCount && selectArr > 0)
                            {
                                arrListIndex = selectArr;
                                Console.WriteLine();
                                Console.Write($"Done!");
                                Console.ReadKey(true);
                                break;
                            }
                            else
                            {
                                Console.Write("Invalid value!");
                                Console.ReadKey(true);
                                Console.WriteLine();
                                goto case "1";
                            }
                        }
                    case "2":
                        {
                            double? sum = 0;
                            int sumCount = 0;
                            var min = currentArr[0];
                            var max = currentArr[0];

                            for (int i = 0; i < currentArr.Length; i++)
                            {
                                if (currentArr[i] == null)
                                {
                                    try
                                    {
                                        min = currentArr[i + 1];
                                        max = currentArr[i + 1];
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Array is empty.");
                                        break;
                                    }
                                }
                                else
                                {
                                    if (currentArr[i] != null)
                                    {
                                        sum += currentArr[i];
                                        sumCount++;
                                    }
                                    if (currentArr[i] < min)
                                    {
                                        min = currentArr[i];
                                    }
                                    if (currentArr[i] > max)
                                    {
                                        max = currentArr[i];
                                    }
                                }
                            }
                            var average = sum / sumCount;
                            var averageFormated = string.Format("{0:0.00}", average);
                            Console.WriteLine();
                            Console.WriteLine($"Sum: {sum}");
                            Console.WriteLine($"Min: {min}");
                            Console.WriteLine($"Max: {max}");
                            Console.Write($"Average: {averageFormated}");
                            Console.ReadKey(true);
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine();
                            Console.WriteLine("(none to back)");
                            Console.Write("Select index: ");
                            string indexSTR = Console.ReadLine();

                            if (indexSTR == "")
                            {
                                Console.WriteLine();
                                Console.Write("Going back...");
                                Console.ReadKey(true);
                                break;
                            }
                            else if (int.TryParse(indexSTR, out int index) && index < currentArr.Length && index >= 0)
                            {
                                Console.Write("Insert value: ");
                                string valueSTR = Console.ReadLine();

                                if (valueSTR == "" || valueSTR == "null")
                                {
                                    currentArr[index] = null;
                                    Console.WriteLine();
                                    Console.Write("Done!");
                                    Console.ReadKey(true);
                                    break;
                                }
                                else
                                {
                                    try
                                    {
                                        var ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                                        ci.NumberFormat.NumberDecimalSeparator = ".";
                                        var value = double.Parse(valueSTR, ci);
                                        currentArr[index] = value;
                                        Console.WriteLine();
                                        Console.Write("Done!");
                                        Console.ReadKey(true);
                                        break;
                                    }
                                    catch
                                    {
                                        Console.Write("Invalid value!");
                                        Console.ReadKey(true);
                                        Console.WriteLine();
                                        goto case "3";
                                    }
                                }
                            }
                            else
                            {
                                Console.Write("Invalid value!");
                                Console.ReadKey(true);
                                Console.WriteLine();
                                goto case "3";
                            }
                        }
                    case "4":
                        {
                            stalinList.Clear();
                            var prevValue = currentArr[0];

                            for (int i = 0; currentArr[i] == null; i++)
                            {
                                prevValue = currentArr[i + 1];
                            }
                            stalinList.Add(prevValue);

                            for (int i = 1; i < currentArr.Length; i++)
                            {
                                var currentValue = currentArr[i];
                                if (prevValue <= currentValue)
                                {
                                    stalinList.Add(currentValue);
                                    prevValue = currentValue;
                                }
                            }
                            stalinArr = stalinList.ToArray();
                            arrList.Add(stalinArr);
                            arrListIndex = arrList.Count - 1;
                            Console.WriteLine();
                            Console.Write("Well done, comrade!");
                            Console.ReadKey(true);
                            break;
                        }
                    case "5":
                        {
                            reverseList.Clear();
                            for (int i = currentArr.Length - 1; i >= 0; i--)
                            {
                                reverseList.Add(currentArr[i]);
                            }
                            reverseArr = reverseList.ToArray();
                            arrList.Add(reverseArr);
                            arrListIndex = arrList.Count - 1;
                            Console.WriteLine();
                            Console.Write("Done!");
                            Console.ReadKey(true);
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine();
                            Console.WriteLine("(none to back)");
                            Console.Write("Value to search: ");
                            string valueSTR = Console.ReadLine();

                            if (valueSTR == "")
                            {
                                Console.WriteLine();
                                Console.Write("Going back...");
                                Console.ReadKey(true);
                                break;
                            }
                            else if (valueSTR == "null")
                            {
                                for (int i = 0; i < currentArr.Length; i++)
                                {
                                    if (currentArr[i] == null)
                                    {
                                        Console.Write($"Matches index {i}!");
                                        Console.ReadKey(true);
                                        Console.WriteLine();
                                        goto case "6";
                                    }
                                }
                                Console.Write("No matches!");
                                Console.ReadKey(true);
                                Console.WriteLine();
                                goto case "6";
                            }
                            else
                            {
                                try
                                {
                                    var ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                                    ci.NumberFormat.NumberDecimalSeparator = ".";
                                    var value = double.Parse(valueSTR, ci);

                                    for (int i = 0; i < currentArr.Length; i++)
                                    {
                                        if (currentArr[i] == value)
                                        {
                                            Console.Write($"Matches index {i}!");
                                            Console.ReadKey(true);
                                            Console.WriteLine();
                                            goto case "6";
                                        }
                                    }
                                    Console.Write("No matches!");
                                    Console.ReadKey(true);
                                    Console.WriteLine();
                                    goto case "6";
                                }
                                catch
                                {
                                    Console.Write("Invalid value!");
                                    Console.ReadKey(true);
                                    Console.WriteLine();
                                    goto case "6";
                                }
                            }
                        }
                }
            }
        }
    }
}