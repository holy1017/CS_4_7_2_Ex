using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_4_7_2_Ex
{
    class FileEx
    {
        public void fileMake()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"TAPSONIC_TOP_");
            sb.Append(DateTime.Now.ToString("yyyyMMddHHmmss"));
            sb.Append(@".txt");
            Console.WriteLine(sb.ToString());

            using (StreamWriter textWrite = File.CreateText(sb.ToString()))//생성
            {
                textWrite.WriteLine("abcdefghijk"); //쓰기
            }
        }
    }
}
