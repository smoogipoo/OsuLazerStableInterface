# OsuStableLazerInterface

This is a small proof-of-concept to create an interface between osu!stable (.NETFramework 4.0) and osu!lazer (.NET 5).

## `ILazer`

The interface. Implemented by both parties.

## `StableLazerAPI`

A .NETFramework 4.0 library and containing the single `LazerAdapter` class. Invoking methods of this class posts them to `LazerRunner` for further processing.

This library is intended to be consumed by osu!stable.

## `LazerRunner`

A .NET 5 executable for processing incoming messages (from `StableLazerAPI`) with osu!lazer.

# Building

```
./build.sh
# Outputs to ./out
```
