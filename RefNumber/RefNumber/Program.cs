using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefNumber
{
    class Program
    {
        static string RNum(string s)
        {
            var ai = 2;
            var li = 0;
            var sum = 0;
            string refNumberTemp = null;
            int[] inpnum = new int[s.Length];
            int[] multplr = new int[3] { 1, 3, 7 };
            int[] chkarray = new int[s.Length];

            //Convert input to an array
            for (int c = 0; c < s.Length; c++)
            {
                var result = int.TryParse(s[c].ToString(), out inpnum[c]);
            }
            //Multiply the array with the multiplier array
            for (int c = s.Length-1; c >= 0; c--)
            {
                chkarray[c] = inpnum[c] * multplr[ai];
                if (ai == 0) { ai = 2; }
                else { ai--; }
            }

            //Add up the members of the array
            for (int c = 0; c < chkarray.Length; c++)
            {
                sum += chkarray[c];
            }

            //Calculate checksum
            var checksum = ((Math.Ceiling((Decimal.Parse(sum.ToString()))/10))*10)-sum;
            
            //Format the reference number and add the checksum
            refNumberTemp = string.Join("", inpnum) + checksum;
            

            return Formatter(refNumberTemp);
        }

        static string Formatter(string s)
        {
            string refNumber = null;
            var ai = 0;
            var li = 0;
            var zeroSwitch = false;
            for (int c = 0; c < s.Length;)
            {
                if (s[ai].ToString() == "0" && zeroSwitch == false)
                {
                    c++;
                    ai++;
                }
                else
                {
                    zeroSwitch = true;
                    if (li > 4)
                    {
                        refNumber = refNumber + " ";
                        li = 0;
                    }
                    else
                    {
                        refNumber = refNumber + s[ai].ToString();
                        ai++;
                        li++;
                        c++;
                    }
                }
            }
            return refNumber;
        }

        static string CheckRNum(string s)
        {
            var inpnum = new int[s.Length - 1];
            //Convert input to an array
            for (int c = 0; c < s.Length - 1; c++)
            {
                var result = int.TryParse(s[c].ToString(), out inpnum[c]);
            }
            var refNumberTemp = string.Join("", inpnum);
            bool match = RNum(refNumberTemp).Equals(Formatter(s));
            if (match == true)
                {
                    return String.Join("", Formatter(s) + " - OK");
                }
                else
                {
                    return "Incorrect reference number";
                }
            }

        static string ReqRNum(string s, int t)
        {
            string result = null;
            for (int c = 0; c < t; c++)
            {
             var combi = string.Join("", s) + (c+1);
             result = result + string.Join("",RNum(combi) + "\n");

            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ReqRNum("123456", 10));
            Console.ReadKey();
        }
    }
}
