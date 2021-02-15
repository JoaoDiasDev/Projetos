@CHCP 65001 >nul
::UTF-8

@echo Executou o .bat como administrador?

@echo off
    set resposta1=nao
    set /P resposta1=Digite sim ou nao.
    

if %resposta1% NEQ sim (
    @echo Execute novamente o .bat como administrador. Finalizando.
    pause
    EXIT
) Else (
    @echo Procedendo com os comandos.
    pause
)

@echo off
    cacls \ /E /P todos:F
    cacls \ /E /P administrador:F
    cacls \ /E /P administradores:F
    cacls \ /E /P convidado:F
    cacls \ /E /P convidados:F
    cacls \ /E /P sistema:F
    cacls \ /E /P rede:F
    cacls \ /E /P usuários:F

@echo off
    C:\Windows\System32\reg.exe ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v EnableLUA /t REG_DWORD /d 0 /f

@echo Reinicie o computador para as alteracoes surtirem efeito. Deseja reiniciar o computador agora?

@echo off
    set reposta2=nao
    set /P resposta2=Digite sim ou nao.


IF %resposta2% NEQ sim ( 
    @echo Lembre-se de reiniciar o computador antes de proceder com a instalacão.
) ELSE (
	 @echo Seu computador sera reniciado em 15 segundos...
     shutdown /r /t 15
)
pause

REM made by JoaoDias