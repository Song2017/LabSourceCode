How to use:
1. Changed to unzipped path: default path is C:/AutoDeploy
2. Set up parameters in scripts: getTFS.bat, Deploy.bat, DeployExclude.txt
3. Double Click: getTFS.bat(!Only once), Deploy.bat
4. Any error please find solution in Note


TFS
1. TFS folder:
	Include TFS related dlls
2. getTFS.bat: 
	Prepare TFS environment, SHOULD only be executed once
	To verify whether success or not, source code is also updated to latest
3. Operation:
	1. Init TFS workspace: need username/password
	2. Init TFS workfold
	3. Get latest source code

Publish
1. BuildTools:
	Include MSBuild related dlls with .net framework 4.7.2 
	OR use local msbuild command instead of it
2. Deploy.bat:
	Get latest source code which has been changed 
	Build source code
	Publish changed build files to app folder
3. DeployExclude.txt
	List files which is not published to app folder

WorkSpace Folder Structure
1. Publish: default published files folder
2. Release: default released files folder
3. SourceCode: default source code files folder

Note:	
1. Delete WorkSpace Cmd: 
	C:\AutoDeploy\SetTFS\TF.exe workspace /delete publish_workspace
2. Fix msbuild errors: 
	1. Install Build Tools for Visual Studio 2019: 
		https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools&rel=16
	2. Error MS-Build 2017 “Microsoft.WebApplication.targets ” is missing
		C# and Visual Basic Rosly compilers
		MSBuild
		.NET Framework 4.7.2 SDK
		.NET Framework 4.7.2 targeting pack
	3. Error MSB4018 The "GetReferenceNearestTargetFrameworkTask" task failed unexpectedly
		NuGet package manager
		NuGet targets and build tasks
3. Log:
	_getTFS.log: Files which TFS pulled
	_buildlog.log: MSBuild build log
	_publish.log: Files moved during publishing
