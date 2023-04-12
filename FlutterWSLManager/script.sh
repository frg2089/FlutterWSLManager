#!/usr/bin/env bash
DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
dotnet $DIR/FlutterWSLManager.dll "${BASH_SOURCE[0]}" $*
