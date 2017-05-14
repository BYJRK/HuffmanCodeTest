using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;

namespace HuffmanCodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Alphabet> MyList = new List<Alphabet>();
            InputList(MyList);
            Console.WriteLine("Extend time: ");
            if (int.TryParse(Console.ReadLine(), out int exTime) && exTime >= 0)
            {
                for (int i = 0; i < exTime; i++)
                {
                    Extend(ref MyList);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. No extension by default.");
            }
            FindHuffmanCode(MyList);
            SortList(MyList);
            DisplayList(MyList.OrderBy((x) => (x.Content)).ToList());
            DisplayInfo(MyList);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(false);
        }
        static void InputList(List<Alphabet> AlphabetList)
        {
            Console.WriteLine("Input the symbol and its probability (e.g. A 0.5), use \".\" to stop:");
            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (input == ".") break;
                var segments = Regex.Split(input, @"\s+");
                if (segments.Count() != 2)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                else
                {
                    AlphabetList.Add(new Alphabet(segments[0], segments[1]));
                }
            }
        }
        static void DisplayList(List<Alphabet> AlphabetList)
        {
            foreach (var alphabet in AlphabetList)
            {
                Console.WriteLine(alphabet.ToString());
            }
            Console.WriteLine("--------------------------------------");
        }
        static void SortList(List<Alphabet> AlphabetList)
        {
            AlphabetList.Sort();
        }
        static void FindHuffmanCode(List<Alphabet> list)
        {
            if (list.Count <= 1) return;
            list = list.OrderBy((x) => (x.Probability)).ToList();

            list[0].AppendCode("1");
            list[1].AppendCode("0");

            //DisplayList(list);
            var combine = new Alphabet("node", list[0].Probability + list[1].Probability);
            combine.Append(list[0]);
            combine.Append(list[1]);
            combine.CurrentCode = combine.Container.OrderBy((x) => (-x.CurrentCode.Length)).ToList()[0].CurrentCode;
            list.RemoveRange(0, 2);
            list.Add(combine);
            FindHuffmanCode(list);
        }
        static void Extend(ref List<Alphabet> list)
        {
            var tempList = new List<Alphabet>();
            foreach (var item1 in list)
            {
                foreach (var item2 in list)
                {
                    tempList.Add(new Alphabet(item1.Content + item2.Content, item1.Probability * item2.Probability));
                }
            }
            list = tempList.OrderBy((x) => (x.Content)).ToList();
        }
        static void DisplayInfo(List<Alphabet> list)
        {
            // Average codeword length
            var acl = 0f;
            // Entropy
            var ent = 0f;
            foreach (var item in list)
            {
                acl += item.CurrentCode.Length * item.Probability;
                ent -= item.Probability * (float)Log(item.Probability, 2f);
            }
            Console.WriteLine($"Average Codeword Length = {acl}");
            Console.WriteLine($"Entropy = {ent}");
            Console.WriteLine($"Efficiency = {ent / acl}");
        }

        static DateTime Start;
        static void Tic()
        {
            Start = DateTime.Now;
        }
        static void Toc()
        {
            Console.WriteLine($"Time lapsed for {(DateTime.Now - Start).TotalSeconds} second(s)");
        }
    }

    class Alphabet : IComparable
    {
        public float Probability { get; set; }
        public string Content { get; set; }
        public string CurrentCode { get; set; }
        public Alphabet(string content, float p)
        {
            Content = content;
            Probability = p;
            CurrentCode = string.Empty;
        }
        public Alphabet(string content, string p)
        {
            Content = content;
            if (float.TryParse(p, out float fp))
            {
                Probability = fp;
            }
            else
                Probability = 0;
            CurrentCode = string.Empty;
        }
        public Alphabet(string content, float p, string current)
            : this(content, p)
        {
            CurrentCode = current;
        }
        public List<Alphabet> Container = new List<Alphabet>();
        public void GetProbabilityFromContainer()
        {
            var p = 0f;
            foreach (var item in Container)
            {
                p += item.Probability;
            }
            Probability = p;
        }
        public void AppendCode(string str)
        {
            if (Container.Count <= 1)
            {
                CurrentCode += str;
            }
            else
            {
                foreach (var item in Container)
                {
                    item.CurrentCode += str;
                }
            }
        }
        public void Append(Alphabet item)
        {
            if (item.Container.Count == 0)
                Container.Add(item);
            else
            {
                foreach (var i in item.Container)
                {
                    Container.Add(i);
                }
            }
        }
        public int CompareTo(object obj)
        {
            return Probability.CompareTo((obj as Alphabet).Probability);
        }
        public override string ToString()
        {
            var arr = CurrentCode.ToCharArray();
            Array.Reverse(arr);
            var code = new string(arr);
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Content.PadLeft(4)}, p={Probability:0.00000}");
            if (Container.Count > 0)
            {
                sb.Append($", Contains {Container.Count} symbol(s)");
            }
            else
                sb.Append($", Code={code}");
            return sb.ToString();
        }
    }
}
