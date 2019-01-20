# Android Sensors for Unity

## Overview
Want to get the light sensor inputs or other cool stuff of your android smartphone? This package provide you an easy access to the android sensor manager. You can get a full list of possible sensors on this [page](https://developer.android.com/guide/topics/sensors/sensors_overview)

Inspired by the talk of Ryan Hipple's ([twitter](https://twitter.com/roboryantron) | [github](https://github.com/roboryantron)) amazing talk from Unite Austin 2017, you can find part of that in the unity [blog post](https://unity3d.com/how-to/architect-with-scriptable-objects). I wrote a simple event system based on scriptable objects. So you can simple drag & drop variables and events around to get nice new behaviours.

I connected these both system to get the sensor values and transfered them into scriptable objects.

But wait... What is a scriptable object?
A scriptable object is an asset which you can create in the unity inspector. It can hold data and functionality. In our case the data part is important.

## Installation

* Grab unityAndroidSensors.unitypackage from the Releases page for everything you need!
* OR, use the git repository.
* Tested with Unity 2018.3 (New Prefab Workflow) or above.

## What you get

First the simple event system with some smart variables, you can create events and variables with the context menu in the project view.

<img src="https://imgur.com/Y5V1NwW.png" alt="How to create smart vars" width="480" height="80">

Second you get a bunch of preconfigured sensors. For every sensor you can choose the update interval (per frame) and the SmartVar in which the data is stored.

Here for example the light sensor:

<img src="https://imgur.com/EKwcR8B.png" alt="Light" width="480" height="160">

Current available sensor:
* Light
* Rotation
* Acceleration (calibrated)
* Gravity
* Gycroscope 
* Gyrooscope Raw
* Stepcount

## How To Use

WIP
