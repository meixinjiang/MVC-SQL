REM MSBuild.exe _.sln /t:clean /m

REM pause

SET EnableNuGetPackageRestore=true

"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" WebApplication1.sln /t:build /m

pause
