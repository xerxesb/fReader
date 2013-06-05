namespace fReader.Core

open System
open System.Net
open System.Web.Http
open System.Web.Mvc
open FSharpx

type Feed = {
    id : string
    name : string
    url : string
}

module Data =
    let feeds = [ 
        { id = "1"; name = "xkcd"; url = "http://xkcd.com/rss.xml" }
        { id = "2"; name = "smbc"; url = "http://www.smbc-comics.com/rss.php" }
    ]

type FeedsDataController() =
    inherit ApiController() 
    member this.Get() = Data.feeds
    member this.Get id = 
        let client = new System.Net.Http.HttpClient()
        Data.feeds |> List.tryFind (fun x -> x.id = id)
                   |> Option.map (fun x -> client.GetStringAsync(x.url).Result) 
                   |> Option.getOrElse "Can't find feed"

type FeedsController() =
    inherit Controller()
    member this.Details id = 
        let c = new FeedsDataController()
        c.Get id
