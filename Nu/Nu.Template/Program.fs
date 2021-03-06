﻿namespace $safeprojectname$
open System
open FSharpx
open SDL2
open OpenTK
open Prime
open Prime.Stream
open Prime.Chain
open Nu

// this is the game dispatcher that is customized for our game. In here, we create screens and wire
// them up with subsciptions and transitions.
type $safeprojectname$Dispatcher () =
    inherit GameDispatcher ()
    
    override dispatcher.Register (_, world) =
        // TODO: start by creating and wiring up your game's screens in here! For an example, look
        // at BlazeDispatcher.fs in the BlazeVector project.
        world

// this is a plugin for the Nu game engine by which user-defined dispatchers, facets, and other
// sorts of types can be obtained by both your application and Gaia.
type $safeprojectname$Plugin () =
    inherit NuPlugin ()

    // make our game-specific game dispatcher...
    override this.MakeGameDispatcherOpt () =
        Some ($safeprojectname$Dispatcher () :> GameDispatcher)

    // specify the above game dispatcher to use
    override this.GetStandAloneGameDispatcherName () =
        typeof<$safeprojectname$Dispatcher>.Name
    
// this is the main module for our program.
module Program =

    // this the entry point for the your Nu application
    let [<EntryPoint; STAThread>] main _ =

        // initialize Nu
        Nu.init false

        // this specifies the window configuration used to display the game.
        let sdlWindowConfig = { SdlWindowConfig.defaultConfig with WindowTitle = "$safeprojectname$" }
        
        // this specifies the configuration of the game engine's use of SDL.
        let sdlConfig = { SdlConfig.defaultConfig with ViewConfig = NewWindow sdlWindowConfig }

        // this is a callback that attempts to make 'the world' in a functional programming
        // sense. In a Nu game, the world is represented as an abstract data type named World.
        let attemptMakeWorld sdlDeps =

            // an instance of the above plugin
            let plugin = $safeprojectname$Plugin ()

            // here is an attempt to make the world with the various initial states, the engine
            // plugin, and SDL dependencies.
            World.attemptMake true 1L () plugin sdlDeps

        // after some configuration it is time to run the game. We're off and running!
        World.run attemptMakeWorld id id sdlConfig