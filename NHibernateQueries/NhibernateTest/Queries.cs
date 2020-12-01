using NHibernate;
using System.Linq;
using NhibernateTest.Domain;
using System;
using System.Collections;
using log4net;
using System.Diagnostics;
using System.Collections.Generic;

namespace NhibernateTest
{
    class Queries
    {
        
        public void Query()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    String query1 = "select postId, score, viewCount, acceptedAnswerId from Posts "
                        +" where score > 0 and viewCount > 0 and parentId is null "
                        +" and acceptedAnswerId is null order by viewCount asc ";
                    String query2 = "select u.accountId , count(*) as cnt"
                        + " from Users u, Posts p , "
                        + " PostLinks pl where p.postId=pl.postId and  p.ownerUserId= u.userId "
                        + " group by u.accountId order by cnt desc";

                    String query3 = "Select g.accountId, g.displayName , count(ph.postHistoryId) as cnt"
                        + " From Users u, Posts p ,"
                        + " PostHistory ph, GlobalUsers g "
                        + " where u.userId = p.ownerUserId and p.postId=ph.postId "
                        + " and ph.postHistoryTypeId = 5 and u.accountId= g.accountId "
                        + " group by g.accountId,g.displayName"
                        + " order by cnt DESC";

                    String query4 = "Select u.accountId , count(b.badgesId) as cnt"
                        + " From Users u, Badges b "
                        + " where u.userId = b.userId and u.communityId = 1"
                        + " and b.badgesdate between '01-jan-2015' and '01-jun-2017'"
                        + " group by u.accountId"
                        + " order by cnt DESC";

                    String query5 = "Select t.TagName , count(c.commentId) as cnt"
                        + " From Tags t, PostTages pt, Posts p,Comments c"
                        + " where  t.tagId = pt.tagId and pt.postId = p.postId "
                        + " and p.postId = c.postId"
                        + " group by t.TagName"
                        + " order by cnt DESC";

                    String query6 = "Select t.TagName , count(*) as upvotes"
                        + " From Tags t, PostTages pt, Posts p, Votes v "
                        + " where  t.tagId = pt.tagId and pt.postId = p.parentId "
                        + " and p.postId = v.postId and v.voteTypeId = 2 "
                        + " group by t.TagName"
                        + " order by upvotes DESC";


                    List<string> queries = new List<string>();

                    queries.Add(query1);
                    queries.Add(query2);
                    queries.Add(query3);
                    queries.Add(query4);
                    queries.Add(query5);
                    queries.Add(query6);

                    int queryCount = 5;
                    for (int q = 0; q < 3; q++)
                    {
                        if (q < 2) continue;

                        Double totaltime = 0;
                        for (int i = 0; i < queryCount; i++)
                        {
                            Stopwatch stopWatch = new Stopwatch();
                            stopWatch.Start();

                            IEnumerable res = session.CreateQuery(
                                queries[q]
                            ).Enumerable();


                            foreach (object[] tuple in res)
                            {

                            }

                            stopWatch.Stop();
                            TimeSpan ts = stopWatch.Elapsed;
                            Console.WriteLine("Querytime: " + ts.TotalSeconds);
                            totaltime += ts.TotalSeconds;
                        }

                        Console.WriteLine("Total Time " + totaltime);
                        Console.WriteLine("Avg Time " + totaltime / queryCount);
                    }
                    transaction.Commit();
                }

            }
        }

        
    }
}
