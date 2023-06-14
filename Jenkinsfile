pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                script {
                    sh 'dotnet clean'
                    sh 'dotnet build --configuration Debug'
                }
            }
        }
        stage('Test') {
            steps {
                script {
                    sh 'dotnet test --configuration Debug --logger "trx;LogFileName=test_results.trx"'
                }
            }
        }
        stage('Publish') {
            when {
                allOf {
                    previousBuilds().success
                    fileExists 'TestResults/test_results.trx'
                }
            }
            steps {
                script {
                    // Create a new 'build' directory inside the project directory
                    sh 'mkdir -p "C:/Soumik/.Net Course/books-app/build"'

                    // Publish the DLLs to the 'build' directory
                    sh 'dotnet publish --configuration Debug --output "C:/Soumik/.Net Course/books-app/build"'
                }
            }
        }
    }
}