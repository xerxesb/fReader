namespace fReader.Core

open System
open System.Web.Mvc

type HomeController() =
    inherit Controller() 
    member this.Index() = 
        let feeds = new FeedsDataController()
        this.View(feeds.Get())

