![Package Publish](https://github.com/landscapeInstitute/LandscapeInstitute.WebAPI.Client/workflows/Package%20Publish/badge.svg)

# LandscapeInstitute.API.Client.Core
C# Dotnet Core Client for accessing the LI Swashbuckle API 

This is a class library which gives a dotnet application access to the LI API. 

It Provides a client and all the models required. 

# To Install

This is hosted on our organisations Nuget Source (Within GitHub)

to add. 

1) this is the Source URL **https://nuget.pkg.github.com/landscapeInstitute/index.json**
2) Create a new personal access token for your user (Must be a part of organisation with access to the repo)
3) Add in Visual Studio as a new Nuget Source. 
4) Add your username, but for password, use your access token. Click remember password
5) The Package can now be installe and updated (along with all LI Packages)

# Basic Usage

The service is added to your startup.cs using code for example

`
            services.AddLandscapeService(options =>
            {
                options.BaseUrl = Configuration.GetSection("API").Get<ApiSettings>().Url;
            });
`

#Authentication

You can define authentication used in 3 seperate ways

- Using a defined static authentication in startup 

`
            services.AddLandscapeService(options =>
            {
                options.BaseUrl = Configuration.GetSection("API").Get<ApiSettings>().Url;
				options.Authentication = new ClientAuthentication()
				{
					Type = ClientAuthenticationType.ApiKey,
					Token = "Configuration.GetSection("API").Get<ApiSettings>().ApiKey"
				};
            });
`

- Using an "Authentication Filter"

`
            services.AddLandscapeService(options =>
            {
                options.BaseUrl = Configuration.GetSection("API").Get<ApiSettings>().Url;
				options.AuthenticationFilter<MyAuthenticationClass>();
            });
`

- Manually Setting the services authentication within callerbase


`
CallerBase.LandscapeService.SetAuthentication =  new ClientAuthentication()
{
	Type = ClientAuthenticationType.ApiKey,
	Token = "Configuration.GetSection("API").Get<ApiSettings>().ApiKey"
}; 
`

#Authentication Filter

Authentication filter allows you put logic behind how your authentication is selected. 
Your authentication filter must be a class extended from 

`ILandscapeServiceAuthenticationFilter`

It must contain a void method called Apply which will set

`
 CallerBase.LandscapeService.SetAuthentication(AuthenticationType, Token);
`

Your filter will run before each and every API Call and thus is constantly loaded. Logic can be used to dictate how the Apply method chooses its tokens and where they come from. 