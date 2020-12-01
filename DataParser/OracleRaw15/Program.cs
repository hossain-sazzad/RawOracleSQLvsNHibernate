using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace OracleRaw15
{
    class Program
    {
        private static List<Memory> postlist;
        private static List<Memory> userlist;
        private static List<TagMemory> taglist;
        static void Mains(string[] args)
        {
            //string data = "(If you ping me with '@[UserName]' I'll get a notification";
            //foreach (var str in tagSeperate(data).ToArray())
            //{

            //    //Console.WriteLine(str);
            //}

            // Console.WriteLine(StringExt.Truncate(data,4000));

            postlist = new List<Memory>();
            userlist = new List<Memory>();
            taglist = new List<TagMemory>();
            postlist.Add(new Memory { localId = 1, globalId = 101 });
            postlist.Add(new Memory { localId = 2, globalId = 102 });
            postlist.Add(new Memory { localId = 3, globalId = 103 });
            postlist.Add(new Memory { localId = 4, globalId = 104 });

            Console.WriteLine("Global ="+ findpost(5));
        }

        private static long findpost(long postid)
        {
            foreach (Memory m in postlist)
            {
                if (m.localId == postid) return m.globalId;
            }
            Console.WriteLine("Post not found !! for local id: " + postid);
            return -2;
        }

        public static List<string> tagSeperate(string data)
        {
            //string data = "&lt;plastic-filament&gt;&lt;finishing-techniques&gt;&lt;makerbot&gt;&lt;surface&gt;&lt;pla&gt;";
            Console.WriteLine(data);
            List<string> tags = new List<string>();
            var portion = data.Split(new string[] { "<" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in portion)
            {
                var tag = s.Split(new string[] { ">" }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(tag[0]);
                tags.Add(tag[0]);
            }
            return tags;
        }
    }

}
