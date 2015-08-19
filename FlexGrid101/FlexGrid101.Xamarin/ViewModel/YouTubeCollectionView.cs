using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xuni.CollectionView;

namespace FlexGrid101
{
    public class YouTubeCollectionView : XuniCursorCollectionView<YouTubeVideo>
    {
        private string _q;
        private string _orderBy = "relevance";

        public YouTubeCollectionView()
        {
            PageSize = 10;
        }

        public int PageSize { get; set; }

        public async Task SearchAsync(string q)
        {
            _q = q;
            await RefreshAsync();
        }

        public async Task OrderAsync(string orderBy)
        {
            _orderBy = orderBy;
            if (_q != null)
                await RefreshAsync();
        }

        protected override async Task<Tuple<string, IReadOnlyList<YouTubeVideo>>> GetPageAsync(string pageToken, int? count = null)
        {
            return await LoadVideosAsync(_q, _orderBy, pageToken, PageSize);
        }

        public static async Task<Tuple<string, IReadOnlyList<YouTubeVideo>>> LoadVideosAsync(string q, string orderBy, string pageToken, int maxResults)
        {
            var searchResult = await SearchVideos(q, orderBy, pageToken, maxResults);
            var videos = await ListVideos(searchResult.Item2);
            return new Tuple<string, IReadOnlyList<YouTubeVideo>>(searchResult.Item1, videos);
        }

        private static async Task<Tuple<string, string[]>> SearchVideos(string q, string orderBy, string pageToken, int maxResults)
        {
            var youtubeUrl = string.Format("https://www.googleapis.com/youtube/v3/search?part=snippet&type=video&q={0}&order={1}&maxResults={2}{3}&key={4}", Uri.EscapeUriString(q), orderBy, maxResults, string.IsNullOrWhiteSpace(pageToken) ? "" : "&pageToken=" + pageToken, "AIzaSyDFz8V9U0ccKXQ5oSrcRSoHqpaursqOudo");

            var client = new HttpClient();
            var response = await client.GetAsync(youtubeUrl);
            if (response.IsSuccessStatusCode)
            {
                var videos = new List<string>();
                var serializer = new DataContractJsonSerializer(typeof(YouTubeSearchResult));
                var result = serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as YouTubeSearchResult;
                foreach (var item in result.Items)
                {
                    videos.Add(item.Id.VideoId);
                }
                return new Tuple<string, string[]>(result.NextPageToken, videos.ToArray());
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        private static async Task<IReadOnlyList<YouTubeVideo>> ListVideos(string[] ids)
        {
            var youtubeUrl = string.Format("https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id={0}&key={1}", string.Join(",", ids), "AIzaSyDFz8V9U0ccKXQ5oSrcRSoHqpaursqOudo");

            var client = new HttpClient();
            var response = await client.GetAsync(youtubeUrl);
            if (response.IsSuccessStatusCode)
            {
                var videos = new List<YouTubeVideo>();
                var serializer = new DataContractJsonSerializer(typeof(YouTubeVideoListResult));
                var result = serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as YouTubeVideoListResult;
                return result.Items;
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }
    }

    [DataContract]
    public class YouTubeSearchResult
    {
        [DataMember(Name = "nextPageToken")]
        public string NextPageToken { get; set; }
        [DataMember(Name = "items")]
        public YouTubeSearchItemResult[] Items { get; set; }
    }

    [DataContract]
    public class YouTubeSearchItemResult
    {
        [DataMember(Name = "id")]
        public YouTubeVideoId Id { get; set; }
        [DataMember(Name = "snippet")]
        public YouTubeSnippet Snippet { get; set; }
    }

    [DataContract]
    public class YouTubeVideoId
    {
        [DataMember(Name = "videoId")]
        public string VideoId { get; set; }
    }

    [DataContract]
    public class YouTubeSnippet
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "thumbnails")]
        public YouTubeThumbnails Thumbnails { get; set; }
        [DataMember(Name = "channelTitle")]
        public string ChannelTitle { get; set; }
    }

    [DataContract]
    public class YouTubeThumbnails
    {
        [DataMember(Name = "default")]
        public YouTubeThumbnail Default { get; set; }
        [DataMember(Name = "medium")]
        public YouTubeThumbnail Medium { get; set; }
        [DataMember(Name = "high")]
        public YouTubeThumbnail High { get; set; }
    }

    [DataContract]
    public class YouTubeThumbnail
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }

    [DataContract]
    public class YouTubeVideo
    {
        [DataMember(Name = "kind")]
        public string Kind { get; set; }
        [DataMember(Name = "etag")]
        public string Etag { get; set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "snippet")]
        public YouTubeVideoSnippet Snippet { get; set; }
        [DataMember(Name = "statistics")]
        public YouTubeVideoStatistics Statistics { get; set; }

        public string Link
        {
            get
            {
                return "http://www.youtube.com/watch?v=" + Id;
            }
        }
    }

    [DataContract]
    public class YouTubeVideoSnippet
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "thumbnails")]
        public YouTubeThumbnails Thumbnails { get; set; }
        [DataMember(Name = "channelTitle")]
        public string ChannelTitle { get; set; }
    }

    [DataContract]
    public class YouTubeVideoStatistics
    {
        [DataMember(Name = "viewCount")]
        public ulong ViewCount { get; set; }
        [DataMember(Name = "likeCount")]
        public ulong LikeCount { get; set; }
        [DataMember(Name = "dislikeCount")]
        public ulong DislikeCount { get; set; }
        [DataMember(Name = "favoriteCount")]
        public ulong FavoriteCount { get; set; }
        [DataMember(Name = "commentCount")]
        public ulong CommentCount { get; set; }
    }

    [DataContract]
    public class YouTubeVideoListResult
    {
        [DataMember(Name = "nextPageToken")]
        public string NextPageToken { get; set; }
        [DataMember(Name = "items")]
        public YouTubeVideo[] Items { get; set; }
    }
}
