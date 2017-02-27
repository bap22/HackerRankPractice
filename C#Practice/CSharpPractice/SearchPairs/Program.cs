﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchPairs
{

    /// <summary>
    /// given array of numbers, find how many pairs have the difference k
    /// </summary>
    class Program
    {
        /* Head ends here */
        static int pairs(int[] a, int k)
        {
            var len = a.Length;
            var ret = 0;

            //TOO SLOW!
            //foreach (IEnumerable<int> permutation in PermuteUtils.Permute<int>(a, 2))
            //{
            //    if(permutation.ElementAt(0) - permutation.ElementAt(1) == k)
            //    {
            //        ret++;
            //    }
            //}

            //also to slow, 2 loops without a sort and breaks;

            //faster way is to sort the array (perhaps with a quicksort?) then continue and break when we can. PASSES
            //speed: .8460911
            //Array.Sort(a);
            //for (int i = 0; i < len - 1; i++)
            //{
            //    for (int j = i + 1; j < len; j++)
            //    {
            //        if ((a[j] - a[i]) < k) continue;
            //        if ((a[j] - a[i]) == k) { ret++; break; }
            //        if ((a[j] - a[i]) > k) break;
            //    }

            //}


            //speed: 1.33607
            //foreach(int i in a)
            //{
            //    var lookingFor =  i + k;
            //    if (a.Contains(lookingFor))
            //        ret++;
            //}


            //how about hash map?
            //speed: 1.23413
            //var MAX = 1000000000;//10^9 per requirements DOESNT PASS

            //// Initialize empty hashmap.
            //bool[] hashmap = new bool[MAX];

            //// Insert array elements to hashmap
            //for (int i = 0; i < len; i++)
            //    hashmap[a[i]] = true;

            //for (int i = 0; i < len; i++)
            //{
            //    int x = a[i];
            //    if (x - k >= 0 && hashmap[x - k])
            //        ret++;
            //    if (x + k < MAX && hashmap[x + k])
            //        ret++;
            //    hashmap[x] = false;
            //}


            //hashmappiish intersect version ALSO PASSES...
            //speed: 2.2371... but somehow passes hackerrank... run times on hacker rank show as faster. 
            int[] hashmap = new int[len];
            for(int i = 0; i< len; i++)
            {
                var lookingFor = a[i] + k;
                hashmap[i] = lookingFor;
            }
            var intersect = a.Intersect(hashmap);
            ret = intersect.Count();

            return ret;
        }

        /* Tail starts here */
        static void Main(String[] args)
        {
            int res;
            DateTime start = DateTime.Now;

            String line = Console.ReadLine();
            String[] line_split = line.Split(' ');
            int _a_size = Convert.ToInt32(line_split[0]);
            int _k = Convert.ToInt32(line_split[1]);
            int[] _a = new int[_a_size];
            int _a_item;
            String move = Console.ReadLine();
            String[] move_split = move.Split(' ');
            for (int _a_i = 0; _a_i < move_split.Length; _a_i++)
            {
                _a_item = Convert.ToInt32(move_split[_a_i]);
                _a[_a_i] = _a_item;
            }


            DateTime end = DateTime.Now;
            TimeSpan duration = end - start;
            
            res = pairs(_a, _k);
            Console.WriteLine(res);
            Console.WriteLine("SPEED:" + duration.ToString());
            //ShowPermutations<int>(_a, 2);
            Console.ReadLine();

        }

        // Print out the permutations of the input 
        static void ShowPermutations<T>(IEnumerable<T> input, int count)
        {
            foreach (IEnumerable<T> permutation in PermuteUtils.Permute<T>(input, count))
            {
                foreach (T i in permutation)
                {
                    Console.Write(" " + i);
                }
                Console.WriteLine();
            }
        }

    }

    public class PermuteUtils
    {
        // Returns an enumeration of enumerators, one for each permutation
        // of the input.
        public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> list, int count)
        {
            if (count == 0)
            {
                yield return new T[0];
            }
            else
            {
                int startingElementIndex = 0;
                foreach (T startingElement in list)
                {
                    IEnumerable<T> remainingItems = AllExcept(list, startingElementIndex);

                    foreach (IEnumerable<T> permutationOfRemainder in Permute(remainingItems, count - 1))
                    {
                        yield return Concat<T>(
                            new T[] { startingElement },
                            permutationOfRemainder);
                    }
                    startingElementIndex += 1;
                }
            }
        }

        // Enumerates over contents of both lists.
        public static IEnumerable<T> Concat<T>(IEnumerable<T> a, IEnumerable<T> b)
        {
            foreach (T item in a) { yield return item; }
            foreach (T item in b) { yield return item; }
        }

        // Enumerates over all items in the input, skipping over the item
        // with the specified offset.
        public static IEnumerable<T> AllExcept<T>(IEnumerable<T> input, int indexToSkip)
        {
            int index = 0;
            foreach (T item in input)
            {
                if (index != indexToSkip) yield return item;
                index += 1;
            }
        }
    }
}

/*
 * sample input for speed test:
520 1341
480247 690951 368650 575544 932592 321567 652970 963956 746702 824511 980999 242171 75168 144120 203281 992812 430432 46770 566884 92507 792622 718045 789412 790753 802355 881533 612820 506671 502468 665638 66191 951403 922175 881334 291814 742679 370213 713716 14949 629095 91166 894145 178277 835114 896011 824973 920015 269023 234465 402146 357349 395469 910656 176710 711413 726112 433114 96368 686702 297662 135664 95027 998231 820113 699691 528591 250234 797555 199258 688762 783282 281335 190961 349489 587162 850086 639235 74994 718529 123181 552080 250564 403128 431140 442349 16543 502801 701950 456529 772458 91184 654812 193933 347157 933933 870810 400418 127204 318247 348498 406169 15202 918819 102695 150771 918674 90677 710072 823632 856234 906310 160235 506824 510573 836828 901556 699472 500897 403487 510915 141438 148591 312882 801014 954648 281117 1106 262483 252916 841213 623621 794873 957677 657494 394128 810582 914651 798332 391446 755404 505150 679777 822795 314223 389594 606607 125863 17631 344343 458427 259089 989403 181599 593315 988512 580598 936534 367309 799673 271705 320929 360031 503809 846577 22595 641086 535783 494704 68552 338979 807411 64529 368075 428458 717392 466549 476353 686973 923116 821454 429091 934899 794776 97519 632949 41245 995494 172116 959858 681118 118915 293202 248893 344475 156419 212590 492022 124522 826314 682459 692292 561421 238980 498215 205666 403923 94837 552521 792094 716398 188802 619598 632016 543965 329954 207226 569425 157760 392787 2447 14066 715057 385708 84803 233616 242362 970989 17784 406600 190058 631608 516318 580430 53746 3374 279019 855452 996890 748043 813264 313625 97709 772158 369416 485470 678410 900215 195274 634290 491797 949301 496874 833604 821829 431773 717739 807900 43509 173457 3788 201940 465658 120256 311541 413762 75343 642456 700813 317648 159101 559156 88502 781591 740587 315015 521764 832196 635631 708731 741928 356008 346807 316356 716867 894513 496804 797970 130748 586503 642427 646069 957903 444465 707390 633357 656993 237639 11826 316906 103685 356856 494122 838169 486757 843895 270364 750395 793435 463867 242694 365968 87148 689298 491556 878640 416615 200599 854111 356584 328613 490899 315564 88484 490456 991956 658127 736560 197956 349839 404828 523105 483347 584480 995549 312333 585821 16934 975304 896546 874617 693633 365715 244874 492781 318962 234957 13861 645179 315565 568084 492240 893522 881838 552193 658334 129149 314966 654311 13769 576885 40072 115125 879156 403659 228762 453847 324249 744020 238238 407941 306587 771117 148637 598738 17884 48869 560284 794644 356657 594656 251575 596308 869469 895486 812515 260602 877299 222492 525909 662368 965297 706240 88489 358526 187258 502238 875958 490681 915992 588503 12520 643941 762594 98860 504941 319588 126516 897533 334149 996835 130213 316905 145461 180976 170775 570766 537124 998176 506491 729202 493581 103764 655652 359018 411918 77428 974422 313674 125341 744610 578226 236298 935274 494479 482006 883179 484688 465208 121597 459553 310411 208567 811923 93848 493138 505483 357998 174798 226999 222733 892181 962615 94822 451165 683431 591974 15593 473717 845236 775340 348699 524446 18972 842554 148147 527250 65870 656153 353975 692 354667 318989 331295 340320 287289 366734 175369 350830 142779 894555 471557 643768 674387 478608 856793 390002 355316 809241 877815 196615 994153 471101 677069 574203 938399 796214 316307 534142 322908 211249 459768 101003 577077 358690 673046 990184 309958 451388 712375 455188 206055 527236 92525 54848 879981 935193 620939 4902 921883 461109

*/

