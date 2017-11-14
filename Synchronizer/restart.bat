@echo off
echo  重启同步服务
jobs stop 
echo  正在关闭服务
jobs start
pause