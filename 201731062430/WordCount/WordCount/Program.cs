using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        public static void Pmr_juge(string[] ags,string[] pr)
        {
            for(int i=0;i<ags.Length;i+=2)
            {
                switch (ags[i])
                {
                    case "-i":
                        pr[0] = ags[i + 1];
                        string Regexh = ".txt$";
                        if (!Regex.IsMatch(ags[i + 1], Regexh) || !ags[i + 1].Equals("input.txt")) //
                        {
                            Console.WriteLine("导入文件格式或者文件名错误(设定导入文件是input.txt)");
                            Environment.Exit(0);
                        }
                        break;
                    case "-m":
                        pr[1] = ags[i + 1];
                        break;
                    case "-n":
                        pr[2] = ags[i + 1];
                        break;
                    case "-o":
                        pr[3] = ags[i + 1];
                        string Regexg = ".txt$";
                        if (!Regex.IsMatch(ags[i + 1], Regexg))
                        {
                            Console.WriteLine("导出文件格式错误");
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        Console.WriteLine("输入参数格式错误,无{0}格式参数",ags[i]);
                        Environment.Exit(0);
                        break;
                }
            }
            if(string.IsNullOrEmpty(pr[1]))
            {
                pr[1] = "1";
            }
            if(string.IsNullOrEmpty(pr[2]))
            {
                pr[2] = "0";
            }

        }
        static void Main(string[] args)
        {
            string[] pmr = new string[4];
            Pmr_juge(args, pmr);
            
            Countmodel wc = new Countmodel(pmr[0]);//

            Console.WriteLine("characters:{0}", wc.CountChar());
            Console.WriteLine("words:{0}", wc.CountWord());
            Console.WriteLine("lines:{0}", wc.CountLine());
            wc.CountWords(int.Parse(pmr[1]));
            wc.SortWords();
            wc.print(int.Parse(pmr[2]));
            wc.Out_file(pmr[3]);//
            //Console.ReadKey();
        }
    }
}
