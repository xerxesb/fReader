﻿namespace fReader.Core

open System
open System.Web.Mvc

type HomeController() =
    inherit Controller() 
    member this.Index() = this.View("World! (Again)" :> Object)