# XSLT Transform Tool
A command line interface to transform XSLT templates and parse XML data.

# Installation
* Download the Zipped package.
    * Unzip the package somewhere it won't get deleted.
* Create a system path environmental variable that links to the directory where the package was unzipped.
* Open a Terminal and type "transformtool -help" and press enter.

If all of the above steps were followed correctly you will see the the available commands listed.

# Deploy for Mac
> dotnet publish -c Release -r osx-x64 --self-contained

# Install for Mac
* Open Finder 
* Press Command+Shift+G
* /usr/local/bin
* Throw the exec ifs file in here.