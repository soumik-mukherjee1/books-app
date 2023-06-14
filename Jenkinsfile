pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                script {
                    bat 'dotnet clean'
                    bat 'dotnet build --configuration Debug'
                }
            }
        }
        stage('Test') {
            steps {
                script {
                    bat 'dotnet test --configuration Debug --logger "trx;LogFileName=test_results.trx"'
                }
            }
        }
        stage('Publish') {
            when {
                allOf {
                    expression { currentBuild.result == 'SUCCESS' }
                    fileExists 'TestResults\\test_results.trx'
                }
            }
            steps {
                script {
                    // Create a new 'build' directory inside the project directory
                    bat 'mkdir "C:\\Soumik\\.Net Course\\books-app\\build"'

                    // Publish the DLLs to the 'build' directory
                    bat 'dotnet publish --configuration Debug --output "C:\\Soumik\\.Net Course\\books-app\\build"'
                }
            }
        }
    }
}
