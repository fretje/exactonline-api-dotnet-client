:: For this to work, you need to register your api key with nuget:
:: nuget setapikey <your api key>

call "%~dp0Pack.cmd"

dotnet nuget push "%SourceDir%\src\*.nupkg" --skip-duplicate

pause
