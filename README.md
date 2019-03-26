### I have figured out the issue.

1. two libraries `derbytools.jar` and `derby.jar` have to be compiled via [ikvmc](https://sourceforge.net/projects/ikvm/files/) to `.dll` and add as reference 
2. need to add NuGet package `IKVM.OpenJDK.Jdbc`, `IKVM.OpenJDK.Core` and `IKVM.OpenJDK.Management`
3. current code is `C#`
