using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            /* Splitting the values  */
            string[] tok = equation.Split("=");
            string[] val = tok[0].Split("*");
            
           /* Assigning operands */
            string op1=val[0],op2=val[1],op3=tok[1];
             int first,second,third;
             string str;
            
            /* Checking if third operand contains "?" */
            if(op3.Contains("?"))                      
            { 
                /* Calculating result */
               first=Convert.ToInt32(op1);
               second=Convert.ToInt32(op2);
               first=first*second;
               str=first.ToString();
               return getVal(str,op3);
            }
            else 
            {
                /* if first operator contains "?" then swap value with second operator */
                if(op1.Contains("?"))
                {
                    string temp=op1;
                    op1=op2;
                    op2=temp;
                }   
                first=Convert.ToInt32(op1);
                third=Convert.ToInt32(op3);
                
                /* Return -1 if it is not divisible else compute value */
                
                if(third%first!=0) return -1;
                
                first=third/first;
                str=first.ToString();
                return getVal(str,op2);
            }

            throw new NotImplementedException();
        }
        /* Finding the missing value */
        public static int getVal(string a, string b)
        {
            if(a.Length!=b.Length) 
               return -1;
            for(int i=0;i<a.Length;i++)
            {
                if(b[i].Equals('?')) return a[i]-48;
            }
            return -1;
        }
    }
}
