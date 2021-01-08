call "%~dp0SetEnvironment.cmd"

set SourceDir=%~dp0..

del %SourceDir%\src\*.nupkg
del %SourceDir%\src\*.snupkg

msbuild %SourceDir%\ClientSdk.sln /t:pack /p:Configuration=Release

dotnet nuget push "%SourceDir%\src\*.nupkg" --skip-duplicate

pause
