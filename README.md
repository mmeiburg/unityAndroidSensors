# Android Sensors for Unity

## Overview

Want to get the light sensor output or other cool stuff of your Android smartphone? This package provide you an easy access to the Android _Sensor Manager_. You can get a full list of possible sensors on this [page](https://developer.android.com/guide/topics/sensors/sensors_overview). Each output get stored in a smart variable.

Inspired by the talk of Ryan Hipple's ([twitter](https://twitter.com/roboryantron) | [github](https://github.com/roboryantron)) amazing talk from Unite Austin 2017, you can find part of that in the unity [blog post](https://unity3d.com/how-to/architect-with-scriptable-objects), I wrote a simple event system based on _Scriptable Objects_. These system alowes you to drag & drop variables and events around.
## Installation

* Grab unityAndroidSensors.unitypackage from the Releases page for everything you need!
* OR, use the git repository.
* Tested with Unity 2018.3 (New Prefab Workflow) or above.

## What you get

Firstly, You have access to every sensor value of the Android _Sensor Manager_.
Secondly, You get a simple extentable event system which allows you to create _SmartEvents_ and _SmartVars_ in the project view.

## Events and Variables
To create a new _SmartEvent_ or a _SmartVar_ you can use the _Create->SensorPlugin->SmartData_ context menu in the project view. 
<img src="https://imgur.com/GEdXIWy.png" alt="Sensor Reader" width="550" height="70">

Events are accessible via the ListenSmartEvent

<img src="https://imgur.com/rIUHGut.png" alt="Sensor Reader" width="250" height="145">

Here you can listen to _SmartEvent_'s. If a event gets fired all callbacks get called.

These are particularly useful for game-level events, such as starting, pausing the game, a player dying etc.

## Variables

Variables are just container of data, with the advantage that you can drag & drop them around like the events.

## Comparators

<img src="https://imgur.com/QTrOR0t.png" alt="Sensor Reader" width="250" height="115">

Float- and IntVars can be compared by the _Float_- or _IntVarComparator_. You can choose to compare with a constant or another smart variable.

### Unity Sensor Plugin

The heart of the plugin is the _UnitySensorPlugin_ class. You need the class just once in your scene to get the connection to your Android phone. All sensor readers communicate with the _UnitySensorPlugin_ to get the sensor data as a float[3] array.

### Sensor Reader

<img src="https://imgur.com/jv05QNT.png" alt="Sensor Reader" width="300" height="360">

The *Sensor Reader* provides you with some option to choose the right sensor, the output type and the update interval (per frame). The output is stored in a _SmartVar_. This can be of type float, int or Vector3.

If you choose int or float you have the option to select the specific axis of the output value otherwise you get all axis as a Vector3Var.

## Modifier

If you want to modifiy the output of a sensor before it is written into a _SmartVar_ you can create a modifier which can manipulate the raw float[3] array from the sensor.

An example of a modifier is in the Modifier folder.
It is applied to the preconfigured acceleration sensor.