# Run lambda function from CloudFormation stack
The final goal is to be able create cloudformation template that will run terraform from inside cloudformation stack.  
For example I need to create some external resources (that are not managed by aws) as a part of single deployment process.  
Or integrate already existing terraform modules and not rewrite them to cloudformation.  

Create stack should run terraform apply and delete stack should run terraform destroy.  
Because lambdas have 15 minutes runtime limit I wand to define in the template CodeBuild Project that runs terraform. And custom resource will execute lambda function that will start that codebuild project.  
Additional requirements:
* tf may assume role or able to run with predefined IAM role
* state saved in s3 but assumed role may not have permition to the bucket
* control inputs to tf. other resources attributes may be used as an inputs to tf
* tf outputs may be translated to cf stack outputs or used as inputs to other resources

Stuff to learn:  
https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-custom-resources.html
https://tech.energyhelpline.com/cloudformation-custom-resources/ 
https://github.com/aws/aws-lambda-dotnet/issues/26 
https://gist.github.com/NeilBostrom/97048a42e536a3b94f37dce2e4ac0c38 
https://github.com/stufox/CloudFormationCustomResource 
https://serverlesscode.com/post/cloudformation-deploy-lambda-resources/