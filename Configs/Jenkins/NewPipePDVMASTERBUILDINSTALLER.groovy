pipeline {
    agent {
        label {
            label 'master'
            customWorkspace 'c:\\pdv\\'
        }
    }

    environment {
        def versions = jiraGetProjectVersions idOrKey: 'PDV', site: 'Default'
        def version = "${versions.data[versions.data.size() -1].name}"
        def revision = '0'
        
    }

    stages {
        stage('PDV - Checkout') {
            steps {
                checkout([$class: 'GitSCM', doGenerateSubmoduleConfigurations: false, extensions: [[$class: 'BuildChooserSetting', buildChooser: [$class: 'AncestryBuildChooser', ancestorCommitSha1: '', maximumAgeInDays: 1]], [$class: 'MessageExclusion', excludedMessage: '(?s).*SemVersao.*']], submoduleCfg: [], userRemoteConfigs: [[credentialsId: '4db2800a-7091-4d5e-bd66-a40e44d0241b', url: 'https://RCASistemasDEV@bitbucket.org/RCASistemasRepos/rca_pdv.git']]])
            }
        }

        stage('PDV - Resolvendo versão') {
            steps {
                    script {
                        

                        def localFullVersion = bat(script: '@echo off && git describe --match 1.3.* --tags', returnStdout: true)
                        def onlineFullVersion = version

                        def localSplitedVersion = localFullVersion.tokenize('.')
                        def onlineSplitedVersion = onlineFullVersion.tokenize('.')

                        def localSuffixVersion = "${localSplitedVersion[0]}.${localSplitedVersion[1]}.${localSplitedVersion[2]}"
                        def onlineSuffixVersion = "${onlineSplitedVersion[0]}.${onlineSplitedVersion[1]}.${onlineSplitedVersion[2]}"

                        def localRevision = localSplitedVersion[3].tokenize('-')[0]

                        version = onlineSuffixVersion

                        echo "Local: ${localSuffixVersion}"
                        echo "Online: ${onlineSuffixVersion}"

                        if (localSuffixVersion == onlineSuffixVersion) {
                        revision = localRevision.toInteger() + '1'.toInteger()
                        }
                        echo "A ser gerada: ${version}.${revision}"
                    }
            }
        }

        stage('PDV - Build') {
            steps {
                    
                    bat "c:\\nuget.exe restore c:\\pdv\\Comercio -SolutionDirectory c:\\pdv\\Comercio"
                    bat "del /S /Q c:\\arquivos\\pdv\\master\\*"
                    bat "VisualStudio2019DisableProcBuild.bat"
                    bat "\"C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe\" /t:restore,clean,rebuild /t:publish /p:deployonbuild=true /p:configuration=jenkins /p:publishdir=c:\\arquivos\\pdv\\ /p:Ambiente=c:\\arquivos\\pdv\\master /p:AmbienteDescricao=\"\" /p:ApplicationVersion=${version}.${revision} Comercio/Comercio/Comercio.csproj"
                    echo "Versao path: ${version}.${revision}"
                    bat "\"C:\\Program Files (x86)\\Windows Kits\\10\\App Certification Kit\\signtool.exe\" sign /f RCACERTIFICADO2021.pfx /fd SHA256 /p 1234 /t http://timestamp.sectigo.com \"C:\\arquivos\\pdv\\Application Files\\Comercio_${version.replace('.','_')}_${revision}\\Comercio.exe\""
                    script{
                    // bat "VisualStudio2019DisableProcBuild.bat"
                    bat "\"C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\Common7\\IDE\\devenv.com\" C:\\pdv\\Comercio\\Comercio\\Comercio.csproj /Project C:\\pdv\\Comercio\\InstaladorPDV\\InstaladorPDV.vdproj  /Build"
                    bat "\"C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\Common7\\IDE\\devenv.com\" C:\\pdv\\Comercio\\Comercio\\Comercio.csproj /Project C:\\pdv\\Comercio\\InstaladorRcaPdvServico\\InstaladorRcaPdvServico.vdproj /Build"
                    }
                    bat "\"C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe\" /p:configuration=jenkins /p:publishdir=c:\\arquivos\\pdv\\ /p:Ambiente=c:\\arquivos\\pdv\\master /p:AmbienteDescricao=\"\" /t:ZipOutputPath /p:ApplicationVersion=${version}.${revision} Comercio/Comercio/Comercio.csproj"
            }
        }

        stage('Deploy') {
            steps {
                bat "move c:\\arquivos\\pdv\\master\\* \\\\vpn.rcasistemas.com.br\\PDV\\"
                bat "move C:\\pdv\\Comercio\\InstaladorPDV\\Debug\\* \\\\vpn.rcasistemas.com.br\\INSTALADORPDV\\"
                bat "move C:\\pdv\\Comercio\\InstaladorRcaPdvServico\\Debug\\* \\\\vpn.rcasistemas.com.br\\INSTALADORPDV\\"
            }
        }
    }

    post {
        success {
            bat "git tag ${version}.${revision} || (git tag -d ${version}.${revision} && git tag ${version}.${revision})"
            bat "git push origin ${version}.${revision} || (git push --delete origin ${version}.${revision} && git push origin ${version}.${revision})"
        }
    }
}
