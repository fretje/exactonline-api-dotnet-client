call "%~dp0Pack.cmd"

dotnet nuget push "%SourceDir%\src\*.nupkg" --skip-duplicate

pause
