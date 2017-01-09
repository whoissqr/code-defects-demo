REM tested under windows CMD

REM initialize VS 2015 msbuild environment
call "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools\VsDevCmd.bat"

cd /d %~dp0
DEL /Q /F /S ..\idir

cov-build --dir ..\idir --return-emit-failures --fs-capture-search . msbuild t1.sln /t:rebuild
REM cov-import-scm --scm git --dir idir  --log scm-log.txt
cov-analyze --dir ..\idir --all --webapp-security --strip-path "%cd%"
REM cov-analyze --dir ..\idir  --disable-default -en CSRF --webapp-security --strip-path "%cd%"
cov-commit-defects --dir ..\idir --host shichao --port 8099 --user admin --password coverity --stream CSRF-ASP-MVC
