﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("JudoPayDotNetDotNet")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Alternative Payments Ltd")]
[assembly: AssemblyProduct("JudoPay.Net SDK")]
[assembly: AssemblyCopyright("Alternative Payments Ltd")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("b7ce8eb0-2a18-43c5-b0b9-5c24ea89fb14")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly:
	InternalsVisibleTo("JudoPayDotNetTests"),
	InternalsVisibleTo("JudoPayDotNetIntegrationTests"),
	InternalsVisibleTo("JudoPayDotNetWindowsPhone"),
	InternalsVisibleTo("WindowsPhoneDotNetSDK"),
    InternalsVisibleTo("Judo.Tests.Base"),
    InternalsVisibleTo("Judo.Tests.Deployment"),
    InternalsVisibleTo("Judo.Tests.Regression"),
    InternalsVisibleTo("Judo.Tests.Smoke")]