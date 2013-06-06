namespace fReader.Core

open System
open System.Net
open System.Web.Http
open System.Web.Mvc
open FSharpx
open QDFeedParser

type Feed = {
    id : int
    name : string
    url : string
}

module Data =
    let feeds = [ 
        { id = 1; name = "xkcd"; url = "http://xkcd.com/rss.xml" }
        { id = 2; name = "smbc"; url = "http://www.smbc-comics.com/rss.php" }
        { id = 3; name = "YC"; url = "http://feeds.feedburner.com/newsyc50" }
        { id = 4; name = "SO"; url = "http://blog.stackoverflow.com/feed" }
        { id = 5; name = "Troy Hunt"; url = "http://feeds.feedburner.com/TroyHunt" }
    ]

type FeedsDataController() =
    inherit ApiController() 
    member this.Get() = Data.feeds
    member this.Get id = 
        let feedFactory = QDFeedParser.HttpFeedFactory()
        let notFound : IFeed = upcast Rss20Feed()
        let client = new System.Net.Http.HttpClient()
        Data.feeds |> List.tryFind (fun x -> x.id = id)
                   |> Option.map (fun x -> feedFactory.CreateFeed(Uri(x.url)))
                   |> Option.getOrElse notFound

type FeedsController() =
    inherit Controller()
    member this.Details id = 
        let c = new FeedsDataController()
        this.View(c.Get id)
