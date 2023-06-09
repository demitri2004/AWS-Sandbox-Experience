What I learned with tis project: (https://www.youtube.com/watch?v=6_Q3Nr2AFJE&t=234s)
1. Created user with Admin permissions, generated security key for the user.
2. Created aws profile in VS AWS Toolkit, to be able to see aws services in VS, added keys to profile
3. Created VS project from AWS Serverless Application(.NET Core) template
4. aws-lambda-tools-default.json has info where to deploy the app (profile is important!)
5. serverless.template is for CloudFormation to build our Lambda function in aws
6. Created S3 bucket and deployed app via cmd aws command
7. Deployment process pushed the app to S3 bucket and using CloudFormation file built Lambda Function from the app



# Empty AWS Serverless Application Project

This starter project consists of:
* serverless.template - an AWS CloudFormation Serverless Application Model template file for declaring your Serverless functions and other AWS resources
* Function.cs - class file containing the C# method mapped to the single function declared in the template file
* aws-lambda-tools-defaults.json - default argument settings for use with Visual Studio and command line deployment tools for AWS

You may also have a test project depending on the options selected.

The generated project contains a Serverless template declaration for a single AWS Lambda function that will be exposed through Amazon API Gateway as a HTTP *Get* operation. Edit the template to customize the function or add more functions and other resources needed by your application, and edit the function code in Function.cs. You can then deploy your Serverless application.

## Here are some steps to follow from Visual Studio:

To deploy your Serverless application, right click the project in Solution Explorer and select *Publish to AWS Lambda*.

To view your deployed application open the Stack View window by double-clicking the stack name shown beneath the AWS CloudFormation node in the AWS Explorer tree. The Stack View also displays the root URL to your published application.

## Here are some steps to follow to get started from the command line:

Once you have edited your template and code you can deploy your application using the [Amazon.Lambda.Tools Global Tool](https://github.com/aws/aws-extensions-for-dotnet-cli#aws-lambda-amazonlambdatools) from the command line.

Install Amazon.Lambda.Tools Global Tools if not already installed.
```
    dotnet tool install -g Amazon.Lambda.Tools
```

If already installed check if new version is available.
```
    dotnet tool update -g Amazon.Lambda.Tools
```

Execute unit tests
```
    cd "InverntoryManager/test/InverntoryManager.Tests"
    dotnet test
```

Deploy application
```
    cd "InverntoryManager/src/InverntoryManager"
    dotnet lambda deploy-serverless
```
## Arm64

Arm64 support is provided by the AWS Graviton2 processor. For many Lambda workloads Graviton2 provides the best price performance.

If you want to run your Lambda on a Graviton2 Arm64 processor, all you need to do is replace `x86_64` with `arm64` under `"Architectures": ` in the `serverless.template` file. Then deploy as described above. 