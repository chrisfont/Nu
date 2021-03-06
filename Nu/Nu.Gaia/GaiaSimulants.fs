﻿// Gaia - The Nu Game Engine editor.
// Copyright (C) Bryan Edds, 2013-2017.

namespace Nu.Gaia
open System
open Prime
open Nu
open Nu.Gaia
module Simulants =

    let EditorScreen = !> Constants.Engine.DefaultScreenName
    let DefaultEditorLayer = EditorScreen => Constants.Engine.DefaultLayerName