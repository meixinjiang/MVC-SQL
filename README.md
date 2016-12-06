# MVC-SQL
Server-side paginations of a database viewed on browser

Allows users to view HTML pages of the server-side ordering of the Northwind database.

To view, please download all files to a Windows system. Created and tested on Windows 10.

    1. Run _packages_restore -- restores packages needed by the application using the nuget application
    
    2. Run _msbuild_build. Note: You may need to use Notepad++ to change the directory to where MSBuild.exe 
       is located in on your device. In my case, it was located in 
       "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"
       
    3. Run either _Service_IISExpress_x64_8181 or _Service_IISExpress_x86_8181 depending on whether your 
       version of Windows is 64-bit or 32-bit respectively. Note: You may need to use Notepad++ to change 
       the directory to where iisexpress.exe is located in on your device. In my case, it was located in 
       "C:\Program Files (x86)\IIS Express\iisexpress.exe"
       
    4. Double-click the WebGrid link to view the HTML page of the sorting
    
The headings of each column can be clicked to toggle between ordering the respective column in ascending or descending 
order with secondary ordering on Order ID. The order used can be shown by the arrows and by the "Order By:" heading 
under the table. 

The "Request SQL" heading shows that the ordering and pagination is being completed on the server.
