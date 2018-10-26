@echo off
set AppPath=%1
set ProjectId=%2
set JobDate=%3
set SystemCode=%4
set UserID=%5
set TFPath=C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\CommonExtensions\Microsoft\TeamFoundation\Team Explorer\tf.exe
set WorkSpacePath=%TEMP%\TestReport
goto FindTFexe
:FindTFexe
  IF not EXIST %TEMP%\%UserId%\TestReport goto CreateWorkSpace
  goto Do
:CreateWorkSpace
  call "%TFPath%" workspace /new /noprompt testReport%UserId%;%UserId% /collection:http://Win-2017.syscom.com.tw:8080/tfs/DefaultCollection /location:local /login:%UserId%,Syscom@123
  goto MapWorkSpace
:MapWorkSpace
mkdir %TEMP%\%UserId%\TestReport
 call "%TFPath%" workfold /map $/SyscomDocument/TestReport %TEMP%\%UserId%\TestReport /workspace:testReport%UserId% /login:%UserId%,Syscom@123
 call "%TFPath%" workspaces
 goto Do
:Do
  xcopy  %AppPath%\TestReport\%JobDate%\%SystemCode% %TEMP%\TestReport\%ProjectId%\%JobDate%\%SystemCode% /e /y /i
  call "%TFPath%" add %TEMP%\%UserId%\TestReport\%ProjectId%\%JobDate%\%SystemCode%  /r /login:%UserId%,Syscom@123
  call "%TFPath%" checkin %TEMP%\%UserId%\TestReport\%ProjectId%\%JobDate%\%SystemCode% /override:"1" /noprompt /comment:"Test Report Checkin" /r /login:%UserId%,Syscom@123 >>C:\Users\Will\Desktop\TEST\log.txt