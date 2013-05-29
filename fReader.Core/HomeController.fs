namespace fReader.Core

open System
open System.Web.Mvc

type HomeController() =
    inherit Controller() 
    member this.Index() = 
        let feeds = new FeedsController()
        this.View(feeds.Get())
