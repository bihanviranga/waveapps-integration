# Make sure to change the access token.
It is in `Client/WaveappsClient.cs`

## Instructions
- Create an account on Waveapps, and add a business. Note the business ID because we need this later on.
- Go to the [Manage applications](https://developer.waveapps.com/hc/en-us/articles/360019762711-Manage-Applications) page and create an application.
- Generate a full access token. Add this to `Client/WaveappsClient.cs` class' constructor.
- In the same class, replaces the 2 occurences of `businessId` with the ID from step 1.

## Code
- This is a Razor Pages app with 1 page added. All the query code is in the WaveappsClient class.
- On page load, it executes the GET query.
- Since the Waveapps API is a GraphQL api, there should be appropriate 'type' classes to contain the results.
- These classes are in `Client/CustomerModels.cs` file.
- In order to work with GraphQL queries, mutations, and responses, we have used the nuget packages `GraphQL.Client` and `GraphQL.Client.Serializer.NewtonSoft`
- The GET, POST, and DELETE requests are self-explanatory. Just making requests according to their API specifications.
- If we need to include additional details in queries, we have to modify the query and update the class as well.
- Similarly, there are seperate classes for create and delete mutations too.

