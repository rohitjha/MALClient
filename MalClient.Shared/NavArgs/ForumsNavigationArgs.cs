﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FontAwesome.UWP;
using MalClient.Shared.Utils.Enums;

namespace MalClient.Shared.NavArgs
{
    public class ForumsNavigationArgs
    {
        public ForumsPageIndex Page { get; set; }
    }

    public class ForumsBoardNavigationArgs : ForumsNavigationArgs
    {
        public ForumBoards TargetBoard { get; }
        public int AnimeId { get; }
        public bool IsAnimeBoard => AnimeId != 0;

        public ForumsBoardNavigationArgs(ForumBoards board)
        {
            TargetBoard = board;
            Page = ForumsPageIndex.PageBoard;
        }

        public ForumsBoardNavigationArgs(int animeId)
        {
            AnimeId = animeId;
            Page = ForumsPageIndex.PageBoard;
        }
    }

    public class ForumsTopicNavigationArgs : ForumsNavigationArgs
    {
        public string TopicId { get; set; }
        public ForumBoards SourceBoard { get; set; }

        public ForumsTopicNavigationArgs(string topicId, ForumBoards sourceBoard)
        {
            TopicId = topicId;
            Page = ForumsPageIndex.PageTopic;
            SourceBoard = sourceBoard;
        }
    }
}
