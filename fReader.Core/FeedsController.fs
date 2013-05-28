﻿namespace fReader.Core

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

type FeedsController() =
    inherit ApiController() 
    member this.Get() = Data.feeds
        