call "%~dp0SetEnvironment.cmd"

set SourceDir=%~dp0..

del %SourceDir%\src\*.nupkg
del %SourceDir%\src\*.snupkg

msbuild %SourceDir%\ExactOnlineClientSdk.sln /t:pack /p:Configuration=Release
