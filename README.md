# Comparison of Performance Between Raw Oracle SQL and NHibernate ORM 
**Introduction**

This is a project of Database Sessional (CSE-304) based on  Raw SQL and NHibernate ORM. We choose the dataset of "Stack Exchange" to run our query.
 
We ran some selected queries in both Raw sql and NHibernate ORM. Then we compare the execution time of both of these. And By this way we will show which one is better in what cases.
 
**Working Procedure**

- Download the Dataset: We downloaded the XML file of the dataset of "Stack Exchange".
                    
- Designing Schema: Then we design the schema for this dataset. After that we create the corresponding table for the database in ORACLE database management system.
  
  Here is the schema- 
  
  ![Alt text](/Sechema_Graphs/schema.png?raw=true "Schema")

- Inserting Data: We inserted the whole dataset in our database.We have imported 20.4 gb data in our database. The current state of total records of our database - 
 
        Community: 301 
        User: 3123793
        Posts: 4046670
        Tags: 85830 
        Badges: 5665372 
        PostLinkS: 473431
        Comments: 6821944 
        PostHistory: 11837446 
        Votes: 19628868  
 
 
- Writing Queries: We tried to write queries such that these can cover all the basic feature of DBMS as simple query with small query time comparison between  ORM and RAW SQL may not be authentic. THese queries are:
            
  a)   Which questions have score(upvote - downvotes) but have not been answered yet 
 
        select postId , Score, ViewCount, AcceptedAnswerId from Posts 
        where Score > 0 and ViewCount > 0 and ParentId is null and AcceptedAnswerId is null
        order by ViewCount asc;
   
  b)   Show the postlink counts of a global user sorted by total count
 
        select u.accountId , count(*) PostlinkCount from Users u, 
        Posts p ,
        PostLinks pl where p.postId=pl.postId and p.ownerUserId= u.userId
        group by u.accountId 
        ORDER BY PostlinkCount DESC
 
   c)   Sort the user according to their most post body edits [ who are the worst post writers.
 
        Select g.accountId, g.displayname, count(ph.postHistoryId) as cnt
        From Users u, Posts p , PostHistory ph , Gloubalusers g
        where u.userId = p.ownerUserId and p.postId=ph.postId
         and ph.postHistoryTypeId = 5 and u.accountId = g.accountId
        group by g.accountId
        order by cnt DESC
    d)   Find out the persons in sorted list who have earned the most badges in a specific     community between two given date.
 
         Select u.accountId , count(b.badgesId) as cnt
         From Users u, Badges b 
         where u.userId = b.userId and u.communityId = 1
         and b.badgesdate between '01-jan-2015' and '01-jun-2017’
         group by u.accountId
         order by cnt DESC
 
     e)   Find out tags in sorted list whose questions have earned  most upvotes.
 
        select t.tagname,count(c.commentid) cnt
        FROM Tags t, PostTages pt, Posts p, comments c 
        WHERE t.tagid=pt.tagid and pt.postid=p.postid and p.postid= c.postid 
        GROUP BY t.tagname
        order by cnt DESC
 
     f)   Find out tags in sorted list whose questions have most comments on them.
 
        select t.tagname,COUNT(*) AS UpVotes 
        FROM Tags t, PostTages pt, Posts p, Votes v
        WHERE t.tagid=pt.tagid and pt.postid=p.ParentId 
        and v.PostId = p.PostId and v.VoteTypeId = 2
        GROUP BY t.tagname
        order by UpVotes DESC
       
 - Writing code for ORM: we wrote code for ORM  for those 6 queries.

 
 
 
Raw Query Time

        Query 1
        76.339
        Query 2
        76.307
        Query 3
         222.275
        Query 4
        4.921
        Query 5
        40.507
        Query 6
        118.443

Nhibernate Query Time

        Query 1
        78.5227
        Query 2
         89.514
        Query 3
         235.626
        Query 4
        4.993
        Query 5
        42.813
        Query 6
        125.8699


   ![Alt text](/Sechema_Graphs/graph.png?raw=true "Schema")


**Conclusion**

Raw SQL performed better than NHibernate ORM and it also became evident that NHibernate ORM is less suitable for the large applications with a huge amount of data and where many requests to the database at a time is involved as it created ORM object for each request and consumed more memory and increased the CPU usage rather than executing the queries. On the other hand ORM provides benefits and advantages that one simply cannot miss, it can enhance maintainability, portability and productivity of the application.
