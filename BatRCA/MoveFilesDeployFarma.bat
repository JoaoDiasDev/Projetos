SET current_path="%CD%"

MOVE C:\\arquivos\\farma\\master\\* \\\\vpn.rcasistemas.com.br\\FARMA\\"
MOVE C:\\rca_farmapro\\Comercio\\InstaladorFarmaPro\\Debug\\* \\\\vpn.rcasistemas.com.br\\INSTALADORFARMA\\"

ECHO: & ECHO Revert the previous current directory.
CD %current_path%
ECHO CD is set to %CD%


@ECHO End %~nx0 & ECHO:

