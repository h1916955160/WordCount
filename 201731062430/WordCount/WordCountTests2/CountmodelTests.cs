using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordCount.Tests
{
    [TestClass()]
    public class CountmodelTests
    {
        [TestMethod()]
        public void CountmodelTest()
        {
            Countmodel wc = new Countmodel("input.txt");
            Assert.AreNotEqual(null, wc.str);
            Assert.AreNotEqual(null, wc.Word_str);

            //Assert.Fail();
        }

        [TestMethod()]
        public void CountWordsTest()
        {
            Countmodel wc = new Countmodel("input.txt");
            Assert.AreEqual(8,wc.CountWord()) ;
            wc.CountWords(3);
            Assert.AreNotEqual(null,wc.wd_group);
            //Assert.Fail();
        }

        [TestMethod()]
        public void CountCharTest()
        {
            Countmodel wc = new Countmodel("input.txt");
            Assert.AreEqual(46, wc.CountChar());
            //Assert.Fail();
        }

        [TestMethod()]
        public void CountWordTest()
        {
            Countmodel wc = new Countmodel("input.txt");
            Assert.AreEqual(8, wc.CountWord());
            //Assert.Fail();
        }

        [TestMethod()]
        public void CountLineTest()
        {
            Countmodel wc = new Countmodel("input.txt");
            Assert.AreEqual(8, wc.CountLine());
            //Assert.Fail();
        }

        [TestMethod()]
        public void ChangeTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void SortWordsTest()
        {
            Countmodel wc = new Countmodel("input.txt");
            wc.CountWord();
            wc.CountWords(1);
            wc.SortWords();
            Assert.AreEqual(3,wc.wd_group[0].word_num);
            Assert.AreEqual("world", wc.wd_group[0].word);
            //Assert.Fail();
        }

        [TestMethod()]
        public void printTest()
        {
            
            //Assert.Fail();
        }

        [TestMethod()]
        public void Out_fileTest()
        {
            Countmodel wc = new Countmodel("input.txt");
            wc.CountChar();
            wc.CountLine();
            wc.CountWord();
            wc.CountWords(1);
            wc.Out_file("output.txt");
            string str1 = File.ReadAllText("output.txt");
            str1 = str1.ToLower();
            Assert.IsNotNull(str1);
            //Assert.Fail();
        }
    }
}