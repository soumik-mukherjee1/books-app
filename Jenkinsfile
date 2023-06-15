pipeline {
    agent any

    environment {  
        dotnet = 'C:\\Program Files\\dotnet\\dotnet.exe'  
    }

    stages {
        stage('Build') {
            steps {
                sh 'dotnet clean'
                bat 'rmdir /s /q "C:\\Soumik\\.Net Course\\books-app\\build" 2>null'
                sh 'dotnet build --configuration Debug'
            }
        }
        stage('Test') {
            steps {
                script {
                    //def testResultsDir = "${env.WORKSPACE}/TestResults"
                    sh "dotnet test --configuration Debug"
                }
            }
        }
        stage('Publish') {
            steps {
                script {
                    bat 'mkdir "C:\\Soumik\\.Net Course\\books-app\\build"'
                    bat 'dotnet publish --configuration Debug --output "C:\\Soumik\\.Net Course\\books-app\\build"'
                }
            }
        }
    }
}
