# demo how to use runtime razor compliation after deploy

1 add nuget package: Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
2 services.AddControllersWithViews().AddRazorRuntimeCompilation();
3 add copy razor target
           
<Target Name="CopyCustomContentOnPublish" AfterTargets="Publish">
    <ItemGroup>
        <Views Include="Views\**" />
    </ItemGroup>
    <Copy SourceFiles="@(Views)" DestinationFolder="$(PublishDir)%(Views.RelativeDir)" />
</Target>

4 If£º Cannot find reference assembly 'Microsoft.AspNetCore.Antiforgery.dll' file for package Microsoft.AspNetCore.Antiforgery£º    
<PreserveCompilationReferences>true</PreserveCompilationReferences>
<PreserveCompilationContext>true</PreserveCompilationContext>

## demo steps:

1 release and deploy 
2 run app
3 edit .cshtml, save and refresh page