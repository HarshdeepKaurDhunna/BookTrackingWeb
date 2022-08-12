# BookTrackingWeb

OLD Project. https://github.com/HarshdeepKaurDhunna/BookTracking.git

#Issue When running add migrations command got the below issue unable to create common migeration folder
change your migrations assembly by using dbcontextoptionsbuilder. e.g. options.usesqlserver(connection, b => b.migrationsassembly("booktrackingweb")). by default, the migrations assembly is the assembly containing the dbcontext.

#solution 
Created Migration using Powershell Instead of Package Manager console with: command dotnet ef migrations add Initial

#Issue Running command dotnet ef migrations add Initial give error
Unable to create an object of type 'BookTrackingWebContext'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728

#solution Used --verbose and change Target Project
Command for migerations: dotnet ef migrations add InitDatabase --project BookTrackingWebData -s BookTrackingWeb -c BookTrackingWebContext --verbose 
Command for Database update: dotnet ef database update InitDatabase --project BookTrackingWebData -s BookTrackingWeb -c BookTrackingWebContext --verbose

We were unable to add a WebAPI project inside our existing project because it was already a WebMVC project. To fix this, we have created a new Web-API project and added all our changes from earlier project.

During this, we also faced migration issues as it was referring to old project. So cleaned up migrations, deleted all the residual files, restarted IDE and tried again which fixed migration problems.

