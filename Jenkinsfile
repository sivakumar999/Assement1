pipeline {
    agent any
   environment {
    PATH = "C:\\Windows\\System32;C:\\Program Files\\dotnet"
}
    
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        
        stage('Build') {
            steps {
                script {
                    // Restore dependencies and build the project
                    bat 'dotnet restore'
                    bat 'dotnet build'
                }
            }
        }
        
        stage('Test') {
            steps {
                script {
                    // Run tests
                    bat 'dotnet test'
                }
            }
        }
        
        stage('Publish') {
            steps {
                script {
                    // Publish the application
                    bat 'dotnet publish -c Release -o ./publish'
                }
            }
        }
    }
    
    post {
        failure {
            emailext (
                subject: "Pipeline Failed",
                body: "There was an error in the Jenkins pipeline. Please investigate.",
                to: "sivakumar59498@gmail.com"
            )
        }
    }
}
