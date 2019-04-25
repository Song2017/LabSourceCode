@echo [%date% %time%]
@echo Prepare Deploy Source Environment.
set source_path=%1
set server=%2
set tfs_path=%3

set tfs_pro_path=$/tfs/pro/path
set name=domain\name
set passwd=passwd


if "%source_path%" == "" set source_path=C:\AutoDeploy\WorkSpace\SourceCode
if "%server%" == "" set server=http://ip.address:8080/tfs/defaultcollection
if "%tfs_path%" == "" set tfs_path=C:\AutoDeploy\TFS


"%tfs_path%\TF.exe" workspace /new /noprompt /collection:%server% publish_workspace /permission:Private /login:"%name%","%passwd%"
"%tfs_path%\TF.exe" workfold /map "%tfs_pro_path%" %source_path%
@echo TFS WorkSpace and WorkFold configured successfully.
@echo [%date% %time%]

@echo Getting TFS SourceCode...
"%tfs_path%\TF.exe" get %source_path% /version:T /recursive /force > _getTFS.log
@echo SourceCode has been updated.