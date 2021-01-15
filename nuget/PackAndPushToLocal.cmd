call "%~dp0Pack.cmd"

%~dp0nuget init "%SourceDir%\src" c:\Temp\LocalPackageFeed

pause
