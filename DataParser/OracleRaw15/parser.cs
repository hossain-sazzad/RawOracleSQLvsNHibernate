using Oracle.ManagedDataAccess.Client;
using OracleRaw15.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OracleRaw15
{
    public class Parser
    {
        //private static string inputUrl = "F:\\ai.stackexchange.com\\Tags.xml";
        //private static bool debugging=false;

        //static void Main(string[] args)
        //{
        //    string oradb = "Data Source=ORCL;User Id=hr;Password=hr;";
        //    OracleConnection conn = new OracleConnection(oradb);
        //    // C#
        //    //XDocument doc = XDocument.Load("F:\\ai.stackexchange.com\\Tags.xml");

        //    //int count = 0;
        //    //int communityCount = 1;
        //    //int userCount = 1;
        //    //int postCount = 1;
        //    //int badgeCount = 1;
        //    //int commentCount = 1;
        //    //int postHistoryCount = 1;
        //    //int postLinkCount = 1;
        //    //int tagCount = 1;
        //    //int voteCount = 1;
        //    //int tagCommunity = 0;

        //    int count = 0;
        //    int communityCount = 4;
        //    int userCount = 196012;
        //    int postCount = 181038;
        //    int badgeCount = 315936;
        //    int commentCount = 304618;
        //    int postHistoryCount = 542234;
        //    int postLinkCount = 30833;
        //    int tagCount = 2979;
        //    int voteCount = 1044028;
        //    int tagCommunity = 2979;
            

        //    XmlReader reader;
        //    var directories = Directory.GetDirectories("D:\\Datasource");
        //    foreach (String dir in directories)
        //    {
        //        count++;
        //        if (count <=3) continue;
        //        if (count == 5) break;
        //        Console.WriteLine(new DirectoryInfo(dir).Name);
        //        //Community
        //        //conn.Open();
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.Connection = conn;
        //        cmd.CommandText = "INSERT into communities VALUES(" + communityCount + ",'" + new DirectoryInfo(dir).Name + "') ";
        //        cmd.CommandType = CommandType.Text;
        //        OracleDataReader dr ;
        //        //dr = cmd.ExecuteReader();
        //        //dr.Read();
        //        //conn.Close();


        //        Console.WriteLine(dir + "\\Users.xml");
        //        reader = XmlReader.Create(dir + "\\Users.xml");
        //        while (!reader.Read())
        //        {
        //            Users user = new Users();
        //            GlobalUsers globalUser = new GlobalUsers();

        //            if (reader.NodeType == XmlNodeType.Element && reader.Name == "row")
        //            {
        //                user.localId = Convert.ToInt32(reader.GetAttribute("Id"));
        //                user.reputation = Convert.ToInt32(reader.GetAttribute("Reputation"));
        //                user.creationDate = reader.GetAttribute("CreationDate");
        //                globalUser.displayName = reader.GetAttribute("DisplayName");
        //                user.lastAccessDate = reader.GetAttribute("LastAccessDate");
        //                globalUser.websiteUrl = reader.GetAttribute("WebsiteUrl");
        //                globalUser.userLocation = reader.GetAttribute("Location");
        //                globalUser.aboutMe = reader.GetAttribute("AboutMe");
        //                user.views = Convert.ToInt32(reader.GetAttribute("Views"));
        //                globalUser.profileImageUrl = reader.GetAttribute("ProfileImageUrl");
        //                globalUser.accountId = Convert.ToInt32(reader.GetAttribute("AccountId"));
        //                //if (globalUser.accountId == -1) globalUser.accountId = 1;
        //                user.accountId = globalUser.accountId;
        //                user.accountId = Convert.ToInt32(reader.GetAttribute("AccountId"));
        //                globalUser.age = Convert.ToInt32(reader.GetAttribute("Age"));

        //                conn.Open();
        //                cmd.CommandText = "SELECT COUNT(*) FROM GLOBALUSERS WHERE ACCOUNTID = " + globalUser.accountId;
        //                cmd.CommandType = CommandType.Text;
        //                dr = cmd.ExecuteReader();


        //                while (dr.Read())
        //                {

        //                    if (dr.GetInt32(0) == 0)
        //                    {
        //                        try
        //                        {
        //                            cmd.CommandText = "INSERT INTO GLOBALUSERS VALUES(" + globalUser.accountId
        //                                + ",q'[" + globalUser.displayName + "]',q'[" + globalUser.websiteUrl + "]',q'[" +
        //                                globalUser.userLocation + "]',q'[" + StringExt.Truncate(globalUser.aboutMe, 3000) + "]',q'["
        //                                + globalUser.profileImageUrl + "]'," + globalUser.age + " ) ";
        //                            if(debugging)Console.WriteLine(cmd.CommandText);
        //                            cmd.CommandType = CommandType.Text;
        //                            dr = cmd.ExecuteReader();
        //                        }
        //                        catch (Exception e)
        //                        {
        //                            cmd.CommandText = "INSERT INTO GLOBALUSERS VALUES(" + globalUser.accountId
        //                               + ",q'[" + globalUser.displayName + "]',q'[" + globalUser.websiteUrl + "]',q'[" +
        //                               globalUser.userLocation + "]',q'[]',q'["
        //                               + globalUser.profileImageUrl + "]'," + globalUser.age + " ) ";
        //                            if (debugging)Console.WriteLine(cmd.CommandText);
        //                            cmd.CommandType = CommandType.Text;
        //                            dr = cmd.ExecuteReader();
        //                        }
        //                        //conn.Close();

        //                    }
        //                    //conn.Open();
        //                    cmd.CommandText = "INSERT INTO USERS VALUES(" + userCount + "," + communityCount + "," + user.accountId + "," + user.localId + "," + user.reputation + ",to_timestamp('" + user.creationDate + "','yyyy-mm-dd\"T\"hh24:mi:ss.ff3'),to_timestamp('" + user.lastAccessDate + "','yyyy-mm-dd\"T\"hh24:mi:ss.ff3')," + user.views + ") ";
        //                    if (debugging)Console.WriteLine(cmd.CommandText);
        //                    cmd.CommandType = CommandType.Text;
        //                    dr = cmd.ExecuteReader();
        //                    conn.Close();
        //                    break;
        //                }

        //                userCount++;
        //            }


        //        }

        //        Console.WriteLine(dir + "\\Tags.xml");
        //        reader = XmlReader.Create(dir + "\\Tags.xml");
        //        while (!reader.Read())
        //        {
        //            Tags tag = new Tags();
        //            if (reader.NodeType == XmlNodeType.Element && reader.Name == "row")
        //            {
        //                if (debugging)Console.WriteLine("Id: " + reader.GetAttribute("Id"));
        //                //tag.Id = Convert.ToInt32(reader.GetAttribute("Id"));
        //                tag.TagName = reader.GetAttribute("TagName");
        //                tag.Count = Convert.ToInt32(reader.GetAttribute("Count"));
        //                tag.ExcerptPostId = (reader.GetAttribute("ExcerptPostId") == null) ? -2 : Convert.ToInt32(reader.GetAttribute("ExcerptPostId"));
        //                tag.WikiPostId = (reader.GetAttribute("WikiPostId") == null) ? -2 : Convert.ToInt32(reader.GetAttribute("WikiPostId"));
        //                if (debugging)
        //                {
        //                    Console.Write(tag.Id + " " + tag.TagName + " " + tag.Count);
        //                    if (tag.ExcerptPostId != -1) Console.Write(" " + tag.ExcerptPostId);
        //                    if (tag.WikiPostId != -1) Console.Write(" " + tag.WikiPostId);
        //                    Console.WriteLine();
        //                }

        //                conn.Open();
        //                cmd.CommandText = "INSERT into tags VALUES(" + tagCount +",q'[" + tag.TagName + "]'," + tag.Count + "," + validate(tag.ExcerptPostId) + "," + validate(tag.WikiPostId) + ") ";
        //                cmd.CommandType = CommandType.Text;
        //                dr = cmd.ExecuteReader();
        //                dr.Read();
        //                conn.Close();

        //                tagCount++;
        //            }

        //        }

        //        Console.WriteLine(dir + "\\Posts.xml");
        //        reader = XmlReader.Create(dir + "\\Posts.xml");
        //        while (!reader.Read())
        //        {
        //            Posts post = new Posts();
        //            GlobalUsers globalUser = new GlobalUsers();

        //            if (reader.NodeType == XmlNodeType.Element && reader.Name == "row")
        //            {
        //                post.localId = Convert.ToInt32(reader.GetAttribute("Id"));
        //                post.postTypeId = Convert.ToInt32(reader.GetAttribute("PostTypeId"));
        //                post.acceptedAnswerId = reader.GetAttribute("AcceptedAnswerId") == null ? -2 : Convert.ToInt32(reader.GetAttribute("AcceptedAnswerId"));
        //                post.parentId = reader.GetAttribute("ParentId") == null ? -2 : Convert.ToInt32(reader.GetAttribute("ParentId"));
        //                post.creationDate = reader.GetAttribute("CreationDate");
        //                post.score = Convert.ToInt32(reader.GetAttribute("Score"));
        //                post.viewCount = reader.GetAttribute("ViewCount") == null ? -2 : Convert.ToInt32(reader.GetAttribute("ViewCount"));
        //                post.postBody = StringExt.Truncate(reader.GetAttribute("Body"), 3500);
        //                post.ownerUserId = reader.GetAttribute("OwnerUserId") == null ? -2 : Convert.ToInt32(reader.GetAttribute("OwnerUserId"));
        //                post.ownerDisplayName = reader.GetAttribute("OwnerDisplayName");
        //                post.lastEditorUserId = reader.GetAttribute("LastEditorUserId") == null ? -2 : Convert.ToInt32(reader.GetAttribute("LastEditorUserId"));
        //                post.lastEditorDisplayName = reader.GetAttribute("LastEditorDisplayName");
        //                post.lastEditDate = reader.GetAttribute("LastEditDate");
        //                post.lastActivityDate = reader.GetAttribute("LastActivityDate");

        //                post.title = reader.GetAttribute("Title");
        //                string tagstring = reader.GetAttribute("Tags");
        //                post.answerCount = Convert.ToInt32(reader.GetAttribute("AnswerCount"));
        //                post.commentCount = Convert.ToInt32(reader.GetAttribute("CommentCount"));
        //                post.favoriteCount = Convert.ToInt32(reader.GetAttribute("FavoriteCount"));
        //                post.closedDate = reader.GetAttribute("ClosedDate");
        //                post.communityOwnedDate = reader.GetAttribute("CommunityOwnedDate");

                        
        //                if (post.ownerUserId != -2)
        //                {
        //                    conn.Open();
        //                    cmd.CommandText = "SELECT USERID from USERS WHERE COMMUNITYID= " + communityCount+ " AND LOCALID = " + post.ownerUserId;
        //                    cmd.CommandType = CommandType.Text;
        //                    dr = cmd.ExecuteReader();
        //                    while (dr.Read())
        //                    {
        //                        post.ownerUserId = dr.GetInt32(0);
        //                        break;
        //                    }
        //                    conn.Close();
        //                }
        //                if (post.lastEditorUserId != -2)
        //                {
        //                    conn.Open();
        //                    cmd.CommandText = "SELECT USERID from USERS WHERE  COMMUNITYID= " + communityCount + " AND LOCALID = " + post.lastEditorUserId;
        //                    cmd.CommandType = CommandType.Text;
        //                    dr = cmd.ExecuteReader();
        //                    while (dr.Read())
        //                    {
        //                        post.lastEditorUserId = dr.GetInt32(0);
        //                        break;
        //                    }
        //                    conn.Close();
        //                }

        //                conn.Open();
        //                try
        //                {
        //                    cmd.CommandText = "INSERT INTO POSTS VALUES(" + postCount + "," + communityCount + ","
        //                        + post.localId + "," + post.postTypeId + "," + validate(post.acceptedAnswerId) + "," + validate(post.parentId)
        //                        + "," + formDate(post.creationDate) + "," + post.score + "," + post.viewCount + ",q'["
        //                        + StringExt.Truncate(post.postBody, 3500) + "]'," + validate(post.ownerUserId) + ",q'[" + post.ownerDisplayName + "]',"
        //                        + validate(post.lastEditorUserId) + ",q'[" + post.lastEditorDisplayName + "]'," + formDate(post.lastEditDate)
        //                        + "," + formDate(post.lastActivityDate) + ",q'[" + post.title + "]'," + post.answerCount + ","
        //                        + post.commentCount + "," + post.favoriteCount + "," + formDate(post.closedDate) + ","
        //                        + formDate(post.communityOwnedDate) + ") ";
        //                    if (debugging)Console.WriteLine(cmd.CommandText);
        //                    cmd.CommandType = CommandType.Text;
        //                    dr = cmd.ExecuteReader();
        //                }
        //                catch(Exception e)
        //                {
        //                    cmd.CommandText = "INSERT INTO POSTS VALUES(" + postCount + "," + communityCount + ","
        //                        + post.localId + "," + post.postTypeId + "," + validate(post.acceptedAnswerId) + "," + validate(post.parentId)
        //                        + "," + formDate(post.creationDate) + "," + post.score + "," + post.viewCount + ",q'[]'," + validate(post.ownerUserId) + ",q'[" + post.ownerDisplayName + "]',"
        //                        + validate(post.lastEditorUserId) + ",q'[" + post.lastEditorDisplayName + "]'," + formDate(post.lastEditDate)
        //                        + "," + formDate(post.lastActivityDate) + ",q'[" + post.title + "]'," + post.answerCount + ","
        //                        + post.commentCount + "," + post.favoriteCount + "," + formDate(post.closedDate) + ","
        //                        + formDate(post.communityOwnedDate) + ") ";
        //                    if (debugging)Console.WriteLine(cmd.CommandText);
        //                    cmd.CommandType = CommandType.Text;
        //                    dr = cmd.ExecuteReader();
        //                }
                        
        //                conn.Close();


        //                //insert tags of posts
        //                if (tagstring != null)
        //                {
        //                    foreach (string str in tagSeperate(tagstring))
        //                    {
        //                        int tagid = -2;
        //                        if (debugging)Console.WriteLine(str);
        //                        conn.Open();
        //                        cmd.CommandText = "SELECT TAGID from TAGS WHERE TAGID >=" + tagCommunity + " and TAGNAME like q'[" + str + "]'";
        //                        if (debugging)Console.WriteLine(cmd.CommandText);
        //                        cmd.CommandType = CommandType.Text;
        //                        dr = cmd.ExecuteReader();
        //                        while (dr.Read())
        //                        {
        //                            tagid = dr.GetInt32(0);
        //                            break;
        //                        }
        //                        conn.Close();

        //                        conn.Open();
        //                        cmd.CommandText = "INSERT into POSTTAGES VALUES(" + tagid + "," + postCount + ") ";
        //                        if (debugging)Console.WriteLine(cmd.CommandText);
        //                        cmd.CommandType = CommandType.Text;
        //                        dr = cmd.ExecuteReader();
        //                        dr.Read();
        //                        conn.Close();
        //                    }
        //                }
        //                postCount++;

        //            }

        //        }

        //        //Update post table
        //        Console.WriteLine("Updating Posts");
        //        if (false)
        //        {
        //            conn.Open();
        //            cmd.CommandText = "SELECT POSTID,COMMUNITYID,PARENTID,ACCEPTEDANSWERID from POSTS WHERE PARENTID is not NULL or ACCEPTEDANSWERID is not NULL";
        //            if (debugging)Console.WriteLine(cmd.CommandText);
        //            cmd.CommandType = CommandType.Text;
        //            dr = cmd.ExecuteReader();
        //            while (dr.Read())
        //            {
                        
        //                Posts post = new Posts();
        //                post.postId = dr.GetInt32(0);
        //                post.communityId = dr.GetInt32(1);
        //                try
        //                {
        //                    post.parentId = dr.GetInt32(2);
        //                }
        //                catch
        //                {
        //                    post.parentId = -2;
        //                }
        //                try
        //                {
        //                    post.acceptedAnswerId = dr.GetInt32(3);
        //                }
        //                catch
        //                {
        //                    post.acceptedAnswerId = -2;
        //                }

                        
        //                if (post.acceptedAnswerId != -2)
        //                {
        //                    OracleConnection conn2 = new OracleConnection(oradb);
        //                    cmd.Connection = conn2;
        //                    conn2.Open();
        //                    cmd.CommandText = "SELECT POSTID from POSTS WHERE LOCALID=" + post.acceptedAnswerId + " AND COMMUNITYID= " + communityCount;
        //                    cmd.CommandType = CommandType.Text;
        //                    OracleDataReader dr2 = cmd.ExecuteReader();
        //                    while (dr2.Read())
        //                    {
        //                        post.acceptedAnswerId = dr2.GetInt32(0);
        //                        break;
        //                    }
        //                    conn2.Close();
        //                }
        //                if (post.parentId != -2)
        //                {
        //                    OracleConnection conn2 = new OracleConnection(oradb);
        //                    cmd.Connection = conn2;
        //                    conn2.Open();
        //                    cmd.CommandText = "SELECT POSTID from POSTS WHERE LOCALID=" + post.acceptedAnswerId + " AND COMMUNITYID= " + communityCount;
        //                    cmd.CommandType = CommandType.Text;
        //                    OracleDataReader dr2 = cmd.ExecuteReader();
        //                    while (dr2.Read())
        //                    {
        //                        post.parentId = dr2.GetInt32(0);
        //                        break;
        //                    }
        //                    conn2.Close();
        //                }
        //                OracleConnection conn3 = new OracleConnection(oradb);
        //                cmd.Connection = conn3;
        //                conn3.Open();
        //                cmd.CommandText = "UPDATE POSTS SET ACCEPTEDANSWERID=" + validate(post.acceptedAnswerId)
        //                    + " , PARENTID=" + validate(post.parentId) + " WHERE POSTID=" + post.postId;
        //                if (debugging)Console.WriteLine(cmd.CommandText);
        //                cmd.CommandType = CommandType.Text;
        //                OracleDataReader dr3 = cmd.ExecuteReader();
        //                conn3.Close();
        //                //conn.Open();

        //            }
        //            conn.Close();
        //        }

        //        cmd.Connection = conn;

        //        Console.WriteLine(dir + "\\Badges.xml");
        //        reader = XmlReader.Create(dir + "\\Badges.xml");
        //        while (!reader.Read())
        //        {
        //            Badges badge = new Badges();
        //            if (reader.NodeType == XmlNodeType.Element && reader.Name == "row")
        //            {
        //                if (debugging)Console.WriteLine("Id: " + reader.GetAttribute("Id"));
        //                //tag.Id = Convert.ToInt32(reader.GetAttribute("Id"));
        //                badge.badgesName = reader.GetAttribute("Name");
        //                badge.userId = Convert.ToInt32(reader.GetAttribute("UserId"));
        //                badge.date =reader.GetAttribute("Date");
        //                badge.badgesClass = Convert.ToInt32(reader.GetAttribute("Class"));
        //                badge.tagbased = reader.GetAttribute("TagBased");

        //                conn.Open();
        //                cmd.CommandText = "SELECT USERID from USERS WHERE COMMUNITYID= " + communityCount + " AND LOCALID = " + badge.userId;
        //                cmd.CommandType = CommandType.Text;
        //                dr = cmd.ExecuteReader();
        //                while (dr.Read())
        //                {
        //                    badge.userId = dr.GetInt32(0);
        //                    break;
        //                }
        //                conn.Close();


        //                conn.Open();
        //                cmd.CommandText = "INSERT into Badges VALUES(" + badgeCount + "," + badge.userId + "," 
        //                    + communityCount + ",q'[" + badge.badgesName + "]'," +formDate(badge.date) + "," 
        //                    + badge.badgesClass + ",q'[" + badge.tagbased+ "]') ";
        //                if (debugging)Console.WriteLine(cmd.CommandText);
        //                cmd.CommandType = CommandType.Text;
        //                dr = cmd.ExecuteReader();
        //                dr.Read();
        //                conn.Close();

        //                badgeCount++;
        //            }

        //        }

        //        Console.WriteLine(dir + "\\PostLinks.xml");
        //        reader = XmlReader.Create(dir + "\\PostLinks.xml");
        //        while (!reader.Read())
        //        {
        //            PostLinks link = new PostLinks();
        //            if (reader.NodeType == XmlNodeType.Element && reader.Name == "row")
        //            {
        //                if (debugging)Console.WriteLine("Id: " + reader.GetAttribute("Id"));
        //                link.creationDate = reader.GetAttribute("CreationDate");
        //                link.postId = Convert.ToInt32(reader.GetAttribute("PostId"));
        //                link.releatedPostId = Convert.ToInt32(reader.GetAttribute("RelatedPostId"));
        //                link.linkTypeId = Convert.ToInt32(reader.GetAttribute("LinkTypeId"));

        //                conn.Open();
        //                cmd.CommandText = "SELECT POSTID from POSTS WHERE LOCALID=" + link.postId + " AND COMMUNITYID= " + communityCount;
        //                cmd.CommandType = CommandType.Text;
                       
        //                dr = cmd.ExecuteReader();
        //                link.postId = -2;
        //                while (dr.Read())
        //                {
        //                    link.postId = dr.GetInt32(0);
        //                    break;
        //                }
        //                conn.Close();

        //                conn.Open();
        //                cmd.CommandText = "SELECT POSTID from POSTS WHERE LOCALID=" + link.releatedPostId + " AND COMMUNITYID= " + communityCount;
        //                cmd.CommandType = CommandType.Text;
                        
        //                 dr = cmd.ExecuteReader();
        //                link.releatedPostId = -2;
        //                while (dr.Read())
        //                {
        //                    link.releatedPostId = dr.GetInt32(0);
        //                    break;
        //                }
        //                conn.Close();

        //                conn.Open();
        //                cmd.CommandText = "INSERT into POSTLINKS VALUES(" + postLinkCount + "," 
        //                    + formDate(link.creationDate) + ","
        //                    +validate(link.postId) +  "," +validate(link.releatedPostId )+ "," + link.linkTypeId + ") ";
        //                if (debugging)Console.WriteLine(cmd.CommandText);
        //                cmd.CommandType = CommandType.Text;
        //                dr = cmd.ExecuteReader();
        //                dr.Read();
        //                conn.Close();

        //                postLinkCount++;
        //            }
        //        }

        //        Console.WriteLine(dir + "\\Comments.xml");
        //        reader = XmlReader.Create(dir + "\\Comments.xml");
        //        while (!reader.Read())
        //        {
        //            Comments comment = new Comments();
        //            if (reader.NodeType == XmlNodeType.Element && reader.Name == "row")
        //            {
        //                if (debugging)Console.WriteLine("Id: " + reader.GetAttribute("Id"));
        //                comment.postId = Convert.ToInt32(reader.GetAttribute("PostId"));
        //                comment.score = Convert.ToInt32(reader.GetAttribute("Score"));
        //                comment.text = reader.GetAttribute("Text");
        //                comment.creationDate = reader.GetAttribute("CreationDate");
        //                comment.userDisplayName = reader.GetAttribute("UserDisplayName");
        //                comment.userId = reader.GetAttribute("UserId") == null ? -2 : Convert.ToInt32(reader.GetAttribute("UserId"));

        //                conn.Open();
        //                cmd.CommandText = "SELECT POSTID from POSTS WHERE LOCALID=" + comment.postId + " AND COMMUNITYID= " + communityCount;
        //                cmd.CommandType = CommandType.Text;

        //                dr = cmd.ExecuteReader();
        //                comment.postId = -2;
        //                while (dr.Read())
        //                {
        //                    comment.postId = dr.GetInt32(0);
        //                    break;
        //                }
        //                conn.Close();

        //                if (comment.userId != -2)
        //                {
        //                    conn.Open();
        //                    cmd.CommandText = "SELECT USERID from USERS WHERE COMMUNITYID= " + communityCount + " AND LOCALID = " + comment.userId;
        //                    cmd.CommandType = CommandType.Text;
        //                    dr = cmd.ExecuteReader();
        //                    while (dr.Read())
        //                    {
        //                        comment.userId = dr.GetInt32(0);
        //                        break;
        //                    }
        //                    conn.Close();
        //                }

        //                conn.Open();
        //                cmd.CommandText = "INSERT into COMMENTS VALUES(" + commentCount + ","
        //                    + validate(comment.postId) + "," + comment.score 
        //                    + ",q'[" +StringExt.Truncate(comment.text,3500) + "]'," 
        //                    + formDate(comment.creationDate) + ",q'[" + comment.userDisplayName + "]',"
        //                    + validate(comment.userId) + ") ";
        //                if (debugging)Console.WriteLine(cmd.CommandText);
        //                cmd.CommandType = CommandType.Text;
        //                dr = cmd.ExecuteReader();
        //                dr.Read();
        //                conn.Close();

        //                commentCount++;
        //            }
        //        }

        //        conn.Open();
        //        Console.WriteLine(dir + "\\PostHistory.xml");
        //        reader = XmlReader.Create(dir + "\\PostHistory.xml");
        //        while (!reader.Read())
        //        {
        //            PostHistory history = new PostHistory();
        //            if (reader.NodeType == XmlNodeType.Element && reader.Name == "row")
        //            {
        //                if (Convert.ToInt32(reader.GetAttribute("Id")) <= 134359) {
        //                    continue;
        //                }
                        
        //                if (debugging)Console.WriteLine("Id: " + reader.GetAttribute("Id"));
        //                history.postHistoryTypeId = Convert.ToInt32(reader.GetAttribute("PostHistoryTypeId"));
        //                history.postId = Convert.ToInt32(reader.GetAttribute("PostId"));
        //                history.revisionGuid = reader.GetAttribute("RevisionGUID");
        //                history.creationDate = reader.GetAttribute("CreationDate");
        //                history.userDisplayName = reader.GetAttribute("UserDisplayName");
        //                history.userId = reader.GetAttribute("UserId") == null ? -2 : Convert.ToInt32(reader.GetAttribute("UserId"));
        //                history.postHistoryComment= reader.GetAttribute("Comment");
        //                history.text = reader.GetAttribute("Text");

        //                //conn.Open();
        //                cmd.CommandText = "SELECT POSTID from POSTS WHERE LOCALID=" + history.postId + " AND COMMUNITYID= " + communityCount;
        //                cmd.CommandType = CommandType.Text;

        //                dr = cmd.ExecuteReader();
        //                history.postId = -2;
        //                while (dr.Read())
        //                {
        //                    history.postId = dr.GetInt32(0);
        //                    break;
        //                }
        //                //conn.Close();

        //                if (history.userId != -2)
        //                {
        //                    //conn.Open();
        //                    OracleCommand cmd2 = new OracleCommand();
        //                    cmd2.Connection = conn;
        //                    cmd2.CommandText = "SELECT USERID from USERS WHERE COMMUNITYID= " + communityCount + " AND LOCALID = " + history.userId;
        //                    cmd2.CommandType = CommandType.Text;
        //                    dr = cmd2.ExecuteReader();
        //                    while (dr.Read())
        //                    {
        //                        history.userId = dr.GetInt32(0);
        //                        break;
        //                    }
        //                    cmd2.Dispose();
        //                    //conn.Close();
        //                }

        //                //conn.Open();
        //                try
        //                {
        //                    cmd.CommandText = "INSERT into POSTHISTORY VALUES(" + postHistoryCount + ","
        //                    + history.postHistoryTypeId + ","
        //                    + validate(history.postId)
        //                    + ",q'[" + StringExt.Truncate(history.revisionGuid, 3500) + "]',"
        //                    + formDate(history.creationDate) + ","
        //                    + validate(history.userId) + ",q'[" + history.userDisplayName
        //                    + "]',q'[" + StringExt.Truncate(history.postHistoryComment, 3500)
        //                    + "]',q'[" + StringExt.Truncate(history.text, 3500) + "]')";

        //                    if (debugging) Console.WriteLine(cmd.CommandText);
        //                    cmd.CommandType = CommandType.Text;
        //                    dr = cmd.ExecuteReader();
        //                    dr.Read();
        //                }
        //                catch (Exception e)
        //                {
        //                    cmd.CommandText = "INSERT into POSTHISTORY VALUES(" + postHistoryCount + ","
        //                    + history.postHistoryTypeId + ","
        //                    + validate(history.postId)
        //                    + ",q'[" + StringExt.Truncate(history.revisionGuid, 3500) + "]',"
        //                    + formDate(history.creationDate) + ","
        //                    + validate(history.userId) + ",q'[" + history.userDisplayName
        //                    + "]',q'[" + StringExt.Truncate(history.postHistoryComment, 3500)
        //                    + "]',q'[]')";

        //                    if (debugging) Console.WriteLine(cmd.CommandText);
        //                    cmd.CommandType = CommandType.Text;
        //                    dr = cmd.ExecuteReader();
        //                    dr.Read();
        //                } 
        //                    //conn.Close();
                        

        //                postHistoryCount++;
        //            }
        //        }

        //        Console.WriteLine(dir + "\\Votes.xml");
        //        reader = XmlReader.Create(dir + "\\Votes.xml");
        //        while (reader.Read())
        //        {
        //            Votes vote = new Votes();
        //            if (reader.NodeType == XmlNodeType.Element && reader.Name == "row")
        //            {
        //                if (Convert.ToInt32(reader.GetAttribute("Id")) <= 720)
        //                {
        //                    continue;
        //                }
        //                if (debugging)Console.WriteLine("Id: " + reader.GetAttribute("Id"));
        //                vote.postId = Convert.ToInt32(reader.GetAttribute("PostId"));
        //                vote.voteTypeId = Convert.ToInt32(reader.GetAttribute("VoteTypeId"));
        //                vote.voterUserId = reader.GetAttribute("UserId") == null ? -2 : Convert.ToInt32(reader.GetAttribute("UserId"));
        //                vote.creationDate = reader.GetAttribute("CreationDate");
        //                vote.bountyAmount = reader.GetAttribute("BountyAmount") == null ? -2 : Convert.ToInt32(reader.GetAttribute("BountyAmount"));

        //                // conn.Open();
        //                OracleCommand cmd3 = new OracleCommand();
        //                cmd3.Connection = conn;
        //                cmd3.CommandText = "SELECT POSTID from POSTS WHERE LOCALID=" + vote.postId + " AND COMMUNITYID= " + communityCount;
        //                cmd3.CommandType = CommandType.Text;
        //                dr = cmd3.ExecuteReader();
        //                vote.postId = -2;
        //                while (dr.Read())
        //                {
        //                    vote.postId = dr.GetInt32(0);
        //                    break;
        //                }
        //                cmd3.Dispose();
        //                //conn.Close();

        //                if (vote.voterUserId != -2)
        //                {
        //                    //conn.Open();
        //                    OracleCommand cmd2 = new OracleCommand();
        //                    cmd2.Connection = conn;
        //                    cmd2.CommandText = "SELECT USERID from USERS WHERE COMMUNITYID= " + communityCount + " AND LOCALID = " + vote.voterUserId;
        //                    cmd2.CommandType = CommandType.Text;
        //                    dr = cmd2.ExecuteReader();
        //                    while (dr.Read())
        //                    {
        //                        vote.voterUserId = dr.GetInt32(0);
        //                        break;
        //                    }
        //                    cmd2.Dispose();
        //                    //conn.Close();
        //                }
        //                OracleCommand cmd4 = new OracleCommand();
        //                try
        //                {
        //                    //conn.Open();
                           
        //                    cmd4.Connection = conn;
        //                    cmd4.CommandText = "INSERT into VOTES VALUES(" + voteCount + ","
        //                        + validate(vote.postId) + "," + vote.voteTypeId + ","
        //                        + validate(vote.voterUserId) + "," + formDate(vote.creationDate) + ","
        //                        + validate(vote.bountyAmount) + ")";

        //                    if (debugging) Console.WriteLine(cmd4.CommandText);
        //                    cmd4.CommandType = CommandType.Text;
        //                    dr = cmd4.ExecuteReader();
        //                    dr.Read();
        //                    cmd4.Dispose();
        //                }catch
        //                {
        //                    Console.WriteLine(cmd4.CommandText);
        //                }
        //                //conn.Close();

        //                voteCount++;
        //            }
        //        }
        //        tagCommunity = tagCount;
        //        communityCount++;

        //    }
        //    conn.Close();
        //    conn.Dispose();


        //    //XmlReader reader = XmlReader.Create(inputUrl);
        //    //while(reader.Read())
        //    //{
        //    //    if (reader.NodeType == XmlNodeType.Element && reader.Name == "row")
        //    //    {
        //    //        if (reader.GetAttribute("ExcerptPostId") != null)
        //    //        {
        //    //            Console.WriteLine("Count " + (count++) + " TagName: " + reader.GetAttribute("ExcerptPostId"));
        //    //        }
        //    //    }
        //    //}

        //    //XmlNodeList nodeList = testDoc.SelectNodes("/details/row/var[@name='account']");
        //    //foreach (XmlNode no in nodeList)
        //    //{
        //    //    test.actual = no.Attributes["value"].Value;

        //    //}
        //    //conn.Open();
        //    //OracleCommand cmd = new OracleCommand();
        //    //cmd.Connection = conn;
        //    //cmd.CommandText = "Drop table tags ";
        //    //cmd.CommandType = CommandType.Text;
        //    //OracleDataReader dr = cmd.ExecuteReader();
        //    //cmd.CommandText = "Create table Tags( id NUMBER primary key, TagName VARCHAR2(80), Count NUMBER, ExcerptPostId NUMBER, WikiPostId NUMBER) ";
        //    //cmd.CommandType = CommandType.Text;
        //    //dr = cmd.ExecuteReader();
        //    ////dr.Read();
        //    ////Console.WriteLine(dr.GetString(0));

        //    //foreach (Tag tag in tags)
        //    //{
        //    //    Console.Write(tag.Id + " " + tag.TagName+" "+tag.Count);
        //    //    if (tag.ExcerptPostId != -1) Console.Write(" " + tag.ExcerptPostId);
        //    //    if (tag.WikiPostId != -1) Console.Write(" " + tag.WikiPostId);
        //    //    Console.WriteLine();
        //    //    cmd.CommandText = "INSERT into tags VALUES("+tag.Id+ ",'" + tag.TagName + "'," + tag.Count + "," + tag.ExcerptPostId + "," + tag.WikiPostId + ") ";
        //    //    cmd.CommandType = CommandType.Text;
        //    //    dr = cmd.ExecuteReader();
        //    //    dr.Read();
        //    //}
        //    //conn.Dispose();
        //}

        //public static string formDate(string date)
        //{
        //    return "to_timestamp('" + date + "','yyyy-mm-dd\"T\"hh24:mi:ss.ff3')";
        //}

        //public static List<string> tagSeperate(string data)
        //{
        //    //string data = "&lt;plastic-filament&gt;&lt;finishing-techniques&gt;&lt;makerbot&gt;&lt;surface&gt;&lt;pla&gt;";
        //    List<string> tags = new List<string>() ;
        //    if (debugging)Console.WriteLine(data);
        //    var portion = data.Split(new string[] { "<" }, StringSplitOptions.RemoveEmptyEntries);
        //    foreach (string s in portion)
        //    {
        //        var tag = s.Split(new string[] { ">" }, StringSplitOptions.RemoveEmptyEntries);
        //        if (debugging)Console.WriteLine(tag[0]);
        //        tags.Add(tag[0]);
        //    }
        //    return tags;
        //}

        //public static String validate(int n)
        //{
        //    if (n == -2) return "NULL";
        //    return Convert.ToString(n);
        //}
    }
}
