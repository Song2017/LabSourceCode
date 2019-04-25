@echo [%date% %time%]
@echo Deploy ASP.Net WebApp
set source_path=%1
set server=%2
set tfs_path=%3
set msbuild_path=%4
set release_path=%5

set release_app_path=C:\AutoDeploy\WorkSpace\Release\_PublishedWebsites\WebApp
set publish_path=C:\AutoDeploy\WorkSpace\Publish

if "%source_path%" == "" set source_path=C:\AutoDeploy\WorkSpace\SourceCode
if "%tfs_path%" == "" set tfs_path=C:\AutoDeploy\SetTFS
if "%msbuild_path%" == "" set msbuild_path=C:\AutoDeploy\BuildTools\MSBuild\15.0\Bin
if "%release_path%" == "" set release_path=C:\AutoDeploy\WorkSpace\Release


@echo [%date% %time%]
@echo Getting Source Code
"%tfs_path%\TF.exe" get %source_path% /version:T /recursive > _getTFS.log
@echo SourceCode has been updated.

@echo [%date% %time%]
@echo Building Source Code
"%msbuild_path%\MSBuild.exe" "%source_path%\WebApp.sln" /t:VKC_WebApp:rebuild /p:WarningLevel=0 /p:Configuration=Release /p:OutputPath="%release_path%" > _buildlog.log
find /I "Build succeeded." _buildlog.log
if %errorlevel% ==0 (
	goto publish
)
@echo SourceCode has been updated.

:publish
@echo stoping www service of IIS...
sc stop w3svc
@echo Publishing to website
xcopy %release_app_path% %publish_path%  /S /E /Y /R /D /EXCLUDE:DeployExclude.txt > _publish.log
@echo starting www service of IIS...
sc start w3svc
@echo Published