namespace fReader.Core

open System
open System.Web.Http
open System.Web.Mvc

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
    member this.Get id = sprintf "This is the data inside the feed with id %d. The next step is to get this data using System.Web.WebClient" id

type FeedsController() =
    inherit Controller()
    member this.Details id = 
        let c = new FeedsDataController()
        c.Get id
