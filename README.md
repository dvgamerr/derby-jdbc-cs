### I have figured out the issue.

1. two libraries `derbytools.jar` and `derby.jar` have to be compiled via ikvmc to `.dll` and add as reference 
2. need to add NuGet package `IKVM.OpenJDK.Jdbc` and `IKVM.OpenJDK.Core `
3. current code is `C#`

