@echo off

:: Load the vcvars if that hasn't already happened
:: First check for Visual Studio 2019, then for Visual Studio 2017, then for Visual Studio 2015, then for Visual Studio 2013
if not defined DevEnvDir (
	if exist "%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Enterprise\Common7\Tools\vsMSBuildCmd.bat" (
		call "%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Enterprise\Common7\Tools\vsMSBuildCmd.bat"
	) else if exist "%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Community\Common7\Tools\vsMSBuildCmd.bat" (
		call "%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Community\Common7\Tools\vsMSBuildCmd.bat"
	) else if exist "%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Community\Common7\Tools\vsMSBuildCmd.bat" (
		call "%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Community\Common7\Tools\vsMSBuildCmd.bat"
	) else if exist "%ProgramFiles(x86)%\Microsoft Visual Studio 14.0\Common7\Tools\vsMSBuildCmd.bat" (
		call "%ProgramFiles(x86)%\Microsoft Visual Studio 14.0\Common7\Tools\vsMSBuildCmd.bat"
	) else (
		call "%ProgramFiles(x86)%\Microsoft Visual Studio 12.0\VC\vcvarsall.bat"
	)
)
