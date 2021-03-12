#!/bin/bash

msbuild StableLazerAPI.sln /p:Configuration=Release /p:OutputPath="$(pwd)/out"
dotnet publish LazerRunner -c=Release -o="out"
