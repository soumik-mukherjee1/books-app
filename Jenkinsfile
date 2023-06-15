pipeline {
    agent any

    tools {
        dotnet 'dotnet' // Assuming 'dotnet' tool is configured in Jenkins global tool configuration
    }

    stages {
        stage('Build') {
            steps {
                sh 'dotnet clean'
                sh 'dotnet build --configuration Debug'
            }
        }
        stage('Test') {
            steps {
                script {
                    def testResultsDir = "${env.WORKSPACE}/TestResults"
                    sh "dotnet test --configuration Debug --logger:trx --logger-output=${testResultsDir}"
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

    post {
        always {
            step([$class: 'MSTestPublisher', testResultsFile: '**/TestResults/*.trx'])
        }
    }
}
