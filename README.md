# Android Sensors for Unity

## Overview

Want to get the light sensor output or other cool stuff of your Android smartphone? This package provide you an easy access to the Android sensor manager. You can get a full list of possible sensors on this [page](https://developer.android.com/guide/topics/sensors/sensors_overview)

Inspired by the talk of Ryan Hipple's ([twitter](https://twitter.com/roboryantron) | [github](https://github.com/roboryantron)) amazing talk from Unite Austin 2017, you can find part of that in the unity [blog post](https://unity3d.com/how-to/architect-with-scriptable-objects). I wrote a simple event system based on scriptable objects. So you can simple drag & drop variables and events around.

I connected these both system to get the sensor values transfered into scriptable objects.

But wait... What is a scriptable object?
A scriptable object is an asset which you can create in the unity inspector. It can hold data and functionality. In our case the data part is important.

## Installation

* Grab unityAndroidSensors.unitypackage from the Releases page for everything you need!
* OR, use the git repository.
* Tested with Unity 2018.3 (New Prefab Workflow) or above.

## What you get

You get the simple extentable event system which allowes you to create events and variables within the project view.

### Event-System

The strength of the event system is, that you can drag & drop events in the editor. Thats cool because you dont have to change code to get new behaviour.

#### Events

Events are accessible via ListenSmartEvent is just a Scriptable Object which stores a list of listener. If you fire the event all listeners get called.
These are particularly useful for game-level events, such as starting, pausing the game, a player dying etc.

#### Listener

To add listeners you can add the SmartEventListener component to a GameObject, the component automaticly listens to the selected event and if the event gets fired it invoke a UnityEvent.

#### Variables

Variables are just container of data, with the VORTEIL that you can drag & drop them around like the events. Encouppeld... bla

#### Comparators


### Unity Sensor Plugin

The heart of the plugin is the UnitySensorPlugin class. You need the class just once in your scene to get the connection to your Android phone. All Sensor Readers communicate with the UnitySensorPlugin to get the sensor data as a float[3] array.

#### Sensor Reader

The Sensor Reader provides you with some option to choose the right sensor, the output type and the update interval (per frame). The output is stored in a SmartVar. This can be of type float, int or Vector3.

If you choose int or float you have the option to select the specific axis of the output value otherwise you get all axis as a Vector3Var.

#### Modifier

If you want to modifiy the output of a sensor befor it is written into a SmartVar you can create a modifier which can manipulate the raw float[3] array from the sensor.

An example of a modifier is in the Modifier folder.
That modifier is used to apply a low pass filter to the acceleration sensor.

<img src="https://imgur.com/Y5V1NwW.png" alt="How to create smart vars" width="480" height="80">


Here for example the light sensor:

<img src="https://imgur.com/EKwcR8B.png" alt="Light" width="480" height="160">

## How To Use

### Unity Sensor Plugin Class (its the heart)
