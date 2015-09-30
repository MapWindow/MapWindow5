rem MapWinGISBin32 = D:\dev\MapwinGIS\GIT\src\bin\Win32\
rem %1 = $(TargetDir) = D:\dev\MapWindow-v5\GIT\src\bin\Release\

cd %MapWinGISBin64%
xcopy *.* %1\MapWinGIS\*  /Y /R /S
cd %1
MW5.PostBuild.exe

