using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Wd
{
        public string word=null;
        public int word_num=0 ;

        /*public override string ToString()
        {
            return String.Format("单词：{0} 词频：{1}", word, word_num);
        }*/
}
namespace WordCount
{

    public class Countmodel
    {
        //属性：字符数，单词数，文本行数

        public int Char_num = 0;
        public int Word_num = 0;
        public int Line_num = 0;
        //分隔后的词语
        public string str;
        //判断后单词字符串集合
        public List<string> Word_str=new List<string>();
        //拼接好的词组
        public string[] Words_str =null;
        //存储单词及词频
        public List<Wd> wd_group = new List<Wd>();
        
        //构造函数
        public Countmodel(string txt_name)
        {
            this.str = File.ReadAllText(txt_name);
            this.str = str.ToLower();
            string[] tmp_str;
            tmp_str = str.Split(new char[] { '\r', '\n', '\t', ' ', '\'', '`', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '=', '<', '>', '/', '?', ':', ';', '"', '[', ']', '{', '}', '|',',' ,'.'});
            foreach(string T in tmp_str)
            {
                Word_str.Add(T);
            }
        }

        //拼接词组并计数
        public void CountWords(int m)
        {
            
            this.Words_str = new string[(Word_str.Count+1)/2-m+1];
            StringBuilder _str = new StringBuilder();
            int k = 0;
            //循环拼接词组
            for (int i = 0; i < this.Word_str.Count - 2*(m-1); i+=2)
            {
                
                for (int a = 0; a < m; a++)
                {
                    this.Words_str[k] += this.Word_str[i + 2*a];
                    if(a<m-1)
                    {
                        this.Words_str[k] +=" ";
                    }
                }
                k++;
            }
            //统计词组词频，并加入集合
            for (int i=0;i<Words_str.Length;i++)
            {
                int j;
                for(j=0;j<wd_group.Count;j++)
                {
                    if(this.Words_str[i]==wd_group[j].word)
                    {
                        wd_group[j].word_num++;
                        break;
                    }
                }
                if(j==wd_group.Count)
                {
                    Wd tmp = new Wd();
                    tmp.word = this.Words_str[i];
                    tmp.word_num = 1;
                    wd_group.Add(tmp);
                }

            }
        }

        //字符计数
        public int CountChar()
        {
            Char_num = Regex.Matches(str, "[A-Za-z+\\d+\\u0020+\\t+\\r]").Count;
            return Char_num;
        }

        //单词计数
        public int CountWord()
        {
            for (int i = 0; i < Word_str.Count; i++)
            {

                string Regexg = "^[A-Za-z]{4}.*";
                if (!Regex.IsMatch(Word_str[i], Regexg))
                {
                    Word_str.Remove(Word_str[i]);
                    i--;
                }
                else
                {
                    Word_num++;
                }
                /*char[] cm = Word_str[i].ToArray();
                if (cm.Length >= 4)
                {
                    int j;
                    for (j = 0; j < 4; j++)
                    {
                        if (cm[j] < 'a' || cm[j] > 'z')
                        {
                            Word_str.Remove(Word_str[i]);
                            i--;
                            break;
                        }
                    }
                    if (j == 4)
                    {
                        Word_num++;
                        
                    }
                }
                else
                {
                    Word_str.Remove(Word_str[i]);
                    i--;
                }*/
            }
            return Word_num;
        }

        //行数计数
        public int CountLine()
        {
            this.Line_num = Regex.Matches(str, @"\r+\n").Count + 1;//行数
            return Line_num;
        }

        //交换函数
        public void Change(Wd wd1, Wd wd2)
        {

            Wd tempwd = new Wd();
            tempwd.word_num = wd1.word_num;
            tempwd.word = wd1.word;
            wd1.word_num = wd2.word_num;
            wd1.word = wd2.word;
            wd2.word_num = tempwd.word_num;
            wd2.word = tempwd.word;
        }

        //词组排序函数
        public void SortWords()
        {
            for (int i = 0; i < wd_group.Count-1; i++)
            {
                int temp = i;
                for (int j = i + 1; j < wd_group.Count; j++)
                {
                    if (wd_group[temp].word_num < wd_group[j].word_num)
                    {
                        temp = j;
                        
                    }
                    else if(wd_group[temp].word_num == wd_group[j].word_num)
                    {
                        if(string.Compare(wd_group[temp].word,wd_group[j].word)>0)
                        {
                            temp = j;
                        }
                        /*char[] tempc1 = wd_group[temp].word.ToArray<Char>();
                        char[] tempc2 = wd_group[j].word.ToArray<Char>();
                        int m = 0, n = 0;
                        while (true)j
                        {
                            if (tempc1[m] > tempc2[n])
                            {
                                temp = j;
                                break;
                            }
                            else if(tempc1[m] < tempc2[n])
                            {
                                break;
                            }
                            else
                            {
                                m++;
                                n++;
                            }
                            
                            if (m == tempc1.Length || n == tempc2.Length)
                            {
                                break;
                            }
                        }*/

                    }

                }
                if(temp!=i)
                {
                    Change(wd_group[i], wd_group[temp]);
                }
            }
        }

        //打印函数
        public void print(int n)
        {
            //wd_group.Reverse();
            int print_num = 0;
            foreach (Wd w in wd_group)
            {
                
                Console.WriteLine("单词：{0,-14}词频：{1}", w.word, w.word_num);
                print_num++;
                if(print_num.Equals(n))
                {
                    break;
                }
            }
        }

        //输出内容到文件
        public void Out_file(string filename)
        {
            List<string> print_file = new List<string>();
            string file_str="characters: "+this.Char_num.ToString();
            print_file.Add(file_str);
            file_str = "words: " + this.Word_num.ToString();
            print_file.Add(file_str);
            file_str = "lines: " + this.Line_num.ToString();
            print_file.Add(file_str);
            foreach(Wd T in wd_group)
            {
                //string ss=
                file_str = "单词："+T.word.PadRight(20)+ "词频：" + T.word_num;
                print_file.Add(file_str);
            }
            File.WriteAllLines(filename, print_file);
            
        }
    }
}
