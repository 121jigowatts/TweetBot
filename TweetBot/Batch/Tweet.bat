@echo off

REM 設定
Call Env.bat

REM 自動ツイートアプリ起動
Call D:\s\data\projects\TweetBot\TweetBot\bin\Release\TweetBot.exe %apiKey% %apiSecret% %accessToken% %accessTokenSecret%
REM Call D:\s\data\projects\TweetBot\TweetBot\bin\Release\TweetBot.exe
if %errorlevel% neq 0 echo %date% %time% Error >> Tweet.log
if %errorlevel% equ 0 echo %date% %time% Success >> Success.log