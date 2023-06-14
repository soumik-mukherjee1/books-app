pipeline {
    agent any

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
                    sh "dotnet test --configuration Debug --logger:trx --results-directory ${testResultsDir}"
                }
            }
        }
        stage('Publish') {
            steps {
                script {
                    sh 'mkdir -p "C:\\Soumik\\.Net Course\\books-app\\build"'
                    sh 'dotnet publish --configuration Debug --output "C:\\Soumik\\.Net Course\\books-app\\build"'
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
